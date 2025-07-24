using Examen.Suport.Formularis;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
// ReSharper disable InconsistentNaming

namespace Examen.Suport.Funcions
{
    public static class Helper
    {
        public static string SyncfusionLicense => Properties.Settings.Default.SyncfusionLicense;

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();

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

            var psi = new ProcessStartInfo(shutdown)
            {
                UseShellExecute = false,
                Arguments = arguments,
                CreateNoWindow = true
            };
            var process = new Process();
            process.StartInfo = psi;
            process.Start();
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
    }
}
