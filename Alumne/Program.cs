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
        static void Main()
        {
            try
            {
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
