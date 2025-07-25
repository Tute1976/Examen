using Examen.Suport.Formularis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using Examen.Suport.Classes;

// ReSharper disable InconsistentNaming

namespace Examen.Suport.Funcions
{
    public static class Helper
    {
        public static string SyncfusionLicense => Properties.Settings.Default.SyncfusionLicense;

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();
        [DllImport("kernel32.dll")]
        static extern uint WTSGetActiveConsoleSessionId();

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
                var process = new Process();
                process.StartInfo = psi;
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

            //var usuari = Environment.UserName;
            //var processes = Process.GetProcesses();
            //foreach (var process in processes)
            //{
            //    if (process.)
            //}

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

                ret.Add(new AplicacioEnUs
                {
                    Nom = name,
                    Ruta = path
                });

                ret = ret.GroupBy(a => a.Nom).Select(g => g.First()).ToList();

                foreach (var aplicacioEnUs in ret)
                    aplicacioEnUs.Descripcio = ObtenirDescripcio(aplicacioEnUs.Ruta);
            }

            return ret;
        }

        private static string ObtenirDescripcio(string ruta)
        {
            try
            {
                var info = FileVersionInfo.GetVersionInfo(ruta);
                return info.FileDescription ?? "";
            }
            catch
            {
                return "";
            }
        }
    }
}
