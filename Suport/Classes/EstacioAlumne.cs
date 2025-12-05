using System;
using System.Management;
using Newtonsoft.Json;

namespace Examen.Suport.Classes
{
    public class EstacioAlumne
    {
        public DateTime? DataInici { get; set; }
        public DateTime? DataDarreraConnexio { get; set; }

        public string Nom { get; set; }
        public string Usuari { get; set; }
        public string Estacio { get; set; }
        public string Fabricant{ get; set; }
        public string Model { get; set; }

        public Guid Id { get; }

        public EstacioAlumne(string nom = "", Guid? id = null)
        {
            try
            {
                Id = id ?? Guid.Empty;
     
                Nom = nom;

                Usuari = Environment.UserName;
                Estacio = Environment.MachineName;

                var query = new SelectQuery("SELECT Manufacturer, Model FROM Win32_ComputerSystem");
                using var searcher = new ManagementObjectSearcher(query);
                foreach (var process in searcher.Get())
                {
                    Fabricant = process["Manufacturer"].ToString();
                    Model = process["Model"].ToString();
                }
            }
            catch
            {
                // ignore
            }

            Nom = nom;
        }

        public override string ToString()
        {
            return $"{Usuari} ({Estacio}) - {Fabricant} {Model}";
        }

        public string Serialitzar()
        {
            return Funcions.Text.Serialitzar(this, Formatting.Indented, true);
        }
    }
}
