using Examen.Suport.Classes;
using Examen.Suport.Formularis;
using Examen.Suport.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        public static Bitmap Aplicacio_32x32 => Resources.Aplicacio_32x32;

        public const int BufferSize = 81920;

        private static readonly Dictionary<string, Bitmap> _Icones = [];
        private static readonly Dictionary<string, string> _Descripcions = [];

        public static List<AplicacioEnUs> AplicacionsEnUs { get; set; } = [];

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();

        [DllImport("kernel32.dll")]
        private static extern uint WTSGetActiveConsoleSessionId();

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phiconLarge,
            IntPtr[] phiconSmall, int nIcons);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public static void Pitar()
        {
            ShowToast("Reproduint so ...", 5, ToastType.Info);

            for (var i = 0; i < 5; i++)
                Beep();
        }

        public static void Bloquejar()
        {
            ShowToast("Bloquejant ...", 5, ToastType.Alert);
            LockWorkStation();
        }

        public static void Aturar()
        {
            ShowToast("Aturant ...", 5, ToastType.Alert);

            Beep();

            var shutdown = Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\shutdown.exe");
            const string arguments = "/s /t 30 /c \"Aturant estació per petició del professor\"";
            Executar(shutdown, arguments);
        }

        public static void ShowToast(this string missatge, int interval, ToastType toastType)
        {
            new ToastForm(missatge, interval, toastType).Show();
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

        private static bool _llistarAplicacionsEnUs;

        public static List<AplicacioEnUs> LlistarAplicacionsEnUs()
        {
            var ret = new List<AplicacioEnUs>();

            try
            {
                if (_llistarAplicacionsEnUs)
                    return null;
                _llistarAplicacionsEnUs = true;

                var sessionId = WTSGetActiveConsoleSessionId();

                var query =
                    $"SELECT Name, ExecutablePath, CommandLine FROM Win32_Process WHERE SessionId = {sessionId} AND Priority = 8";

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
                    aplicacioEnUs.Icona = ObtenirIcona(aplicacioEnUs.Executable, true) ?? Aplicacio_32x32;
                }

                AplicacionsEnUs = ret;
            }
            catch
            {
                // Ignorar
            }
            finally
            {
                _llistarAplicacionsEnUs = false;
            }

            return ret;
        }

        public static string ObtenirDescripcio(string executable)
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

        public static Bitmap ObtenirIcona(string executable, bool usaCache)
        {
            try
            {
                if (usaCache &&
                    _Icones.TryGetValue(executable, out var bitmap))
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
                        return null;
                }

                bitmap = bitmap.Redimensionar(16);
                _Icones[executable] = bitmap;

                return bitmap;
            }
            catch
            {
                // Ignorar
            }

            return null;
        }

        public static Bitmap ObtenirIconaImatge(string fitxerImatge, bool usaCache)
        {
            try
            {
                if (usaCache &&
                    _Icones.TryGetValue(fitxerImatge, out var bmpCached))
                    return bmpCached;

                if (!File.Exists(fitxerImatge))
                    return null;

                using var fs = new FileStream(fitxerImatge, FileMode.Open, FileAccess.Read,
                    FileShare.ReadWrite | FileShare.Delete);

                using var img = Image.FromStream(fs, useEmbeddedColorManagement: true, validateImageData: false);

                using var tmp = new Bitmap(img);

                CorregirOrientacioExif(tmp);

                var bitmap = tmp.Redimensionar(16);
                _Icones[fitxerImatge] = bitmap;
                return bitmap;
            }
            catch
            {
                // Ignorar
            }

            return null;
        }

        private static void CorregirOrientacioExif(Image img)
        {
            const int ExifOrientationId = 0x0112;
            if (Array.IndexOf(img.PropertyIdList, ExifOrientationId) < 0)
                return;

            try
            {
                var prop = img.GetPropertyItem(ExifOrientationId);
                if (prop.Value is { Length: > 0 })
                {
                    int o = prop.Value[0];
                    switch (o)
                    {
                        case 3: img.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                        case 6: img.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                        case 8: img.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                    }
                }

                // Evita que torni a girar si es torna a processar
                try
                {
                    img.RemovePropertyItem(ExifOrientationId);
                }
                catch
                {
                    /* ignore */
                }
            }
            catch
            {
                /* ignore */
            }
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
                    var nodeAplicacio = new Node(nodeCategoria, aplicacio);
                    nodeCategoria.Nodes.Add(nodeAplicacio);
                }

                nodeCategoria.Nodes = nodeCategoria.Nodes.OrderBy(n => n.Nom).ToList();
                nodes.Add(nodeCategoria);
            }

            nodes = nodes.OrderBy(n => n.Nom).ToList();
            return [.. nodes];
        }

        public static void ReportCustomProgress(this BackgroundWorker backgroundWorker, int interval, ToastType toastType, string missatge)
        {
            var dictionary = new Dictionary<ToastType, string>
            {
                {
                    toastType, missatge
                }
            };
            backgroundWorker.ReportProgress(interval, dictionary);
            missatge.Mostrar(MostrarIcon.Information);
        }

        private static readonly List<string> _aplicacionsNoAturades = [];
        private static readonly List<string> _aplicacionsNoHaurienDEstar = [];

        public static bool Aturar(this Aplicacio aplicacio, BackgroundWorker backgroundWorker)
        {
            try
            {
                if (aplicacio.CalAturar)
                {
                    var processos = Process.GetProcessesByName(aplicacio.NomExecutableCurt);
                    var n = processos.Length;
                    while (n > 0)
                    {
                        var taskKill = Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\taskkill.exe");
                        var arguments = $"/F /IM \"{aplicacio.Executable}\" /T";
                        if (!Executar(taskKill, arguments))
                            break;

                        processos = Process.GetProcessesByName(aplicacio.NomExecutableCurt);
                        var nn = processos.Length;
                        if (nn == n)
                            break;
                        n = nn;
                    }

                    if (n > 0)
                    {
                        if (!_aplicacionsNoAturades.Contains(aplicacio.Nom))
                        {
                            backgroundWorker.ReportCustomProgress(10, ToastType.Error, $"L'aplicació '{aplicacio.Nom}', no s'ha pogut aturar");
                            _aplicacionsNoAturades.Add(aplicacio.Nom);
                        }
                    }
                    else
                    {
                        backgroundWorker.ReportCustomProgress(10, ToastType.Alert, $"L'aplicación '{aplicacio.Nom}', ha estat aturada correctament.");
                        if (_aplicacionsNoAturades.Contains(aplicacio.Nom))
                            _aplicacionsNoAturades.Remove(aplicacio.Nom);
                        if (_aplicacionsNoHaurienDEstar.Contains(aplicacio.Nom))
                            _aplicacionsNoHaurienDEstar.Remove(aplicacio.Nom);
                    }

                    return n == 0;
                }

                if (!_aplicacionsNoHaurienDEstar.Contains(aplicacio.Nom))
                {
                    backgroundWorker.ReportCustomProgress(10, ToastType.Info, $@"L'aplicació '{aplicacio.Nom}', no hauria d'estar en ús.");
                    _aplicacionsNoHaurienDEstar.Add(aplicacio.Nom);
                }

                return false;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }
    }
}
