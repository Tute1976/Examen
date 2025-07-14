using System;
using System.Net;

namespace Examen.Suport.Classes
{
    public class EstacioAlumne
    {
        public IPAddress Adreça { get; set; }
        public int Port { get; set; }
        public DateTime DataInici { get; set; }
        public DateTime DatadareraConnexio { get; set; }

        public string Usuari { get; set; }
        public string Estacio { get; set; }
        public string Fabricant{ get; set; }
        public string Model { get; set; }
    }
}
