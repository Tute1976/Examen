using Examen.Suport.Classes;
using Examen.Suport.Formularis;
using Examen.Suport.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming

namespace Examen.Suport.Funcions
{
    public static class Helper
    {
        public static string SyncfusionLicense => Settings.Default.SyncfusionLicense;

        public const int BufferSize = 81920;

        private static readonly Dictionary<string, Bitmap> _Icones = [];
        private static readonly Dictionary<string, string> _Descripcions = [];

        public static readonly List<string> _Notificades = [];

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();
        [DllImport("kernel32.dll")]
        private static extern uint WTSGetActiveConsoleSessionId();
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public static void Pitar()
        {
            ShowToast("Reproduint so ...", 5);

            for (var i = 0; i < 5; i++)
                Beep();
        }

        public static void Bloquejar()
        {
            ShowToast("Bloquejant ...", 5);
            LockWorkStation();
        }

        public static void Aturar()
        {
            ShowToast("Aturant ...", 5);

            Beep();

            var shutdown = Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\shutdown.exe");
            const string arguments = "/s /t 30 /c \"Aturant estació per petició del professor\"";
            Executar(shutdown, arguments);
        }

        public static void ShowToast(string missatge, int interval)
        {
            new ToastForm(missatge, interval).Show();
        }

        public static void Beep()
        {
            new Thread(Beep_).Start();
        }

        private static void Beep_()
        {
            Console.Beep(1000, 500);
            Thread.Sleep(50);
        }

        public static bool Executar(string programa, string arguments)
        {
            try
            {
                var psi = new ProcessStartInfo(programa)
                {
                    UseShellExecute = false,
                    Arguments = arguments,
                    CreateNoWindow = true
                };
                var process = new Process
                {
                    StartInfo = psi
                };
                process.Start();

                return process.WaitForExit(5000);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static List<AplicacioEnUs> LlistarAplicacionsEnUs()
        {
            var ret = new List<AplicacioEnUs>();

            try
            {
                var sessionId = WTSGetActiveConsoleSessionId();

                var query = $"SELECT Name, ExecutablePath, CommandLine FROM Win32_Process WHERE SessionId = {sessionId} AND Priority = 8";

                using var searcher = new ManagementObjectSearcher(query);
                foreach (var o in searcher.Get())
                {
                    var process = (ManagementObject)o;

                    var name = process["Name"]?.ToString();
                    var path = process["ExecutablePath"]?.ToString();
                    var cmd = process["CommandLine"]?.ToString();

                    if (string.IsNullOrEmpty(cmd))
                        continue;

                    if (string.IsNullOrEmpty(path))
                        continue;

                    if (path.StartsWith(@"C:\Windows", StringComparison.InvariantCultureIgnoreCase))
                        continue;

                    if (path.StartsWith(@"C:\Program Files\WindowsApps", StringComparison.InvariantCultureIgnoreCase))
                        continue;

                    var appEnUs = new AplicacioEnUs(name, "", path);

                    ret.Add(appEnUs);
                }

                ret = [.. ret.GroupBy(a => a.Executable).Select(g => g.First())];

                foreach (var aplicacioEnUs in ret)
                {
                    aplicacioEnUs.Descripcio = ObtenirDescripcio(aplicacioEnUs.Executable);
                    aplicacioEnUs.Icona = ObtenirIcona(aplicacioEnUs.Executable);
                }
            }
            catch
            {
                // Ignorar
            }

            return ret;
        }

        private static string ObtenirDescripcio(string executable)
        {
            try
            {
                if (_Descripcions.TryGetValue(executable, out var descripcio))
                    return descripcio;

                var info = FileVersionInfo.GetVersionInfo(executable);
                descripcio = info.FileDescription ?? "";
                _Descripcions.Add(executable, descripcio);

                return descripcio;
            }
            catch
            {
                // Ignorar
            }

            return "";
        }

        private static string l = "";

        private static Bitmap ObtenirIcona(string executable)
        {
            try
            {
                if (_Icones.TryGetValue(executable, out var bitmap))
                    return bitmap;

                if (executable.Equals(Application.ExecutablePath, StringComparison.InvariantCultureIgnoreCase))
                {
                    bitmap = Resources.Examen.ToBitmap();
                }
                else
                {
                    var largeIcon = new IntPtr[1];
                    var smallIcon = new IntPtr[1];

                    ExtractIconEx(executable, 0, largeIcon, smallIcon, 1);

                    if (largeIcon[0] != IntPtr.Zero)
                    {
                        var icon = Icon.FromHandle(largeIcon[0]);
                        bitmap = icon.ToBitmap();
                        DestroyIcon(largeIcon[0]);
                    }
                    else if (smallIcon[0] != IntPtr.Zero)
                    {
                        var icon = Icon.FromHandle(smallIcon[0]);
                        bitmap = icon.ToBitmap();
                        DestroyIcon(smallIcon[0]);
                    }
                    else
                        bitmap = Resources.Aplicacio_32x32;
                }
                
                bitmap = bitmap.Redimensionar(16);
                _Icones.Add(executable, bitmap);

                l = executable;

                return bitmap;
            }
            catch
            {
                // Ignorar
            }

            return Resources.Aplicacio_32x32;
        }

        private static Bitmap Redimensionar(this Bitmap original, int novaAlcada)
        {
            var proporcio = (float)novaAlcada / original.Height;
            var novaAmplada = (int)(original.Width * proporcio);

            var redimensionada = new Bitmap(novaAmplada, novaAlcada);
            using var g = Graphics.FromImage(redimensionada);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(original, 0, 0, novaAmplada, novaAlcada);

            return redimensionada;
        }

        public static Node[] LlegirNodes(this ContenidorAplicacions contenidorAplicacions)
        {
            var nodes = new List<Node>();

            foreach (var categoriaAplicacions in contenidorAplicacions.CategoriesAplicacions)
            {
                var nodeCategoria = new Node(categoriaAplicacions);
                foreach (var aplicacio in categoriaAplicacions.Aplicacions)
                {
                    var nodeAplicacio = new Node(aplicacio);
                    nodeCategoria.Nodes.Add(nodeAplicacio);
                }
                nodes.Add(nodeCategoria);
            }

            return [.. nodes];
        }
    }
}
