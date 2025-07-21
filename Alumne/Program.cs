using System;
using System.Windows.Forms;

namespace Examen.Alumne
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
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Properties.Settings.Default.SyncfusionLicense);

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
