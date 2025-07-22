using Examen.Professor.Formularis;
using Examen.Suport.Funcions;
using System;
using System.Windows.Forms;

namespace Examen.Professor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Helper.SyncfusionLicense);
                Ip.Port = Properties.Settings.Default.PortTcp;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Principal());
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }
    }
}
