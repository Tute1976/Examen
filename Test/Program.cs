using Examen.Intermediari.Redis;
using Examen.Suport.Funcions;
using System;

namespace Examen.Test
{
    public static class Program
    {
        static void Main()
        {
            try
            {
                var args = Environment.GetCommandLineArgs();

                if (args.Length < 2)
                {
                    Console.WriteLine(@"Falten paràmetres");
                }
                else
                {
                    var tipus = args[1];
                    var kk = Guid.NewGuid().ToString();

                    Console.WriteLine($@"Tipus: {tipus}");

                    Connexio.Connectar();

                    if (tipus.Equals("P", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Professor.SubscriuresKeepAlive("Prova", EnRebre);

                        Console.WriteLine(@"  Prem una tecla per finalitzar ...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(@"  Prem Control + C per finalitzar ...");
                        while (true)
                        {
                        //    var ret = Alumne.Enviar("Prova", TipusNotificacio.KeepAlive, "nom");
                        //    Console.WriteLine($@"  KeepAlive enviat: {ret}");

                        //    Thread.Sleep(2000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
            finally
            {
                Connexio.Desconnectar();
            }

            //Console.ReadKey();
        }

        private static void EnRebre(string usuari, string estacio, string nom, DateTime data)
        {
            Console.WriteLine($@"    --> {data:G} | Usuari: {usuari} | Estació: {estacio}");
        }
    }
}
