using System;
using System.Linq;
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

                if (ParseArguments(out var nom, out var codi))
                {
                    var nl = Environment.NewLine;
                    var missatge = $@"Examen Alumne {nl}{nl}" +
                                         $@"Arguments: {nl}" +
                                         $@"  -n, -nom: Nom de l'alumne    {nl}" +
                                         $@"  -c, -codi: Codi de l'examen    {nl}" +
                                         $@"  -?: Mostra aquesta ajuda    ";
                    missatge.Mostrar(MessageBoxIcon.Information);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmPrincipal(nom, codi));
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private static bool ParseArguments(out string nom, out string codi)
        {
            nom = "";
            codi = "";
            var ajuda = false;

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                var aa = arg.Split('=');
                if (aa.Length == 1)
                    aa = arg.Split(':');

                var a = aa.First().ToLower();
                
                if (a.Equals("-?") || a.Equals("/?"))
                    ajuda = true;
                else if (aa.Length > 1)
                {
                    var b = arg.Substring(a.Length + 1);
                    switch (a)
                    {
                        case "-n":
                        case "/n":
                        case "-nom":
                        case "/nom":
                            nom = b.Trim();
                            break;

                        case "-c":
                        case "/c":
                        case "-codi":
                        case "/codi":
                            codi = b.Trim();
                            break;
                    }
                }
            }

            return ajuda;
        }
    }
}
