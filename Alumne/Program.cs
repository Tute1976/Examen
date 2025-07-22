using System;
using System.Windows.Forms;
using Examen.Alumne.Formularis;
using Examen.Suport.Funcions;

namespace Examen.Alumne
{
    internal static class Program
    {
        public static readonly Guid Id = Guid.NewGuid();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Helper.SyncfusionLicense);

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
