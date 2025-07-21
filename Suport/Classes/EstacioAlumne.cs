using System;
using System.Management;
using Newtonsoft.Json;

namespace Examen.Suport.Classes
{
    public class EstacioAlumne
    {
        public DateTime? DataInici { get; set; } = null;
        public DateTime? DataDarreraConnexio { get; set; } = null;

        public AdreçaPort AdreçaPort { get; set; }

        public string Nom { get; set; }
        public string Usuari { get; set; }
        public string Estacio { get; set; }
        public string Fabricant{ get; set; }
        public string Model { get; set; }

        public string Id => $"{AdreçaPort.Adreça}:{Usuari}";

        public EstacioAlumne(string nom)
        {
            try
            {
                Nom = nom;

                AdreçaPort = new AdreçaPort();
                Usuari = Environment.UserName;
                Estacio = Environment.MachineName;

                var query = new SelectQuery("SELECT Manufacturer, Model FROM Win32_ComputerSystem");
                using (var searcher = new ManagementObjectSearcher(query))
                {
                    foreach (var process in searcher.Get())
                    {
                        Fabricant = process["Manufacturer"].ToString();
                        Model = process["Model"].ToString();
                    }
                }

                if (!Funcions.Ip.ObtenirIp(out var adreçaPortMascara))
                    return;
                AdreçaPort = adreçaPortMascara;
                AdreçaPort.Port = Funcions.Ip.Port;
                AdreçaPort.Port = Funcions.Ip.ObtenirPort(AdreçaPort);
            }
            catch
            {
                // ignore
            }

            Nom = nom;
        }

        public override string ToString()
        {
            return $"{Usuari} ({Estacio}) - {Fabricant} {Model} ({AdreçaPort})";
        }

        public string Serialitzar()
        {
            return Funcions.Text.Serialitzar(this, Formatting.Indented, true);
        }
    }
}
