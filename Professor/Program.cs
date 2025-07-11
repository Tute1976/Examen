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
                //var adreça = Suport.Funcions.Ip.ObtenirIp(out var mascara);
                //var xarxa = Suport.Funcions.Ip.ObtenirAdreçaDeXarxa(adreça, mascara);
                //var port = Suport.Funcions.Ip.ProvarPort(adreça, Suport.Funcions.Ip.Port);
                //var codi = Suport.Funcions.Ip.GenerarCodiDesdeAdreça(IPAddress.Parse("192.168.1.23"), mascara, port);
                //var adreçaServidor = Suport.Funcions.Ip.ObtenirAdreçaDesdeCodi(codi, xarxa, out var portServidor);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                Suport.Funcions.Error.Mostrar(ex);
            }
        }
    }
}
