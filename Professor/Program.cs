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
        static void Main()
        {
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Properties.Settings.Default.SyncfusionLicense);

                Suport.Funcions.Ip.Port = Properties.Settings.Default.PortTcp;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Principal());
            }
            catch (Exception ex)
            {
                Suport.Funcions.Error.Mostrar(ex);
            }
        }
    }
}
