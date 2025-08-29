using Examen.Suport.Funcions;
using System.Collections.Generic;
using System.Drawing;

namespace Examen.Suport.Classes
{
    public class Node
    {
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        private bool CalAturar { get; set; }
        private bool Ignorar { get; set; }
        public string Executable { get; set; }

        public Bitmap Icona { get; set; }

        public string CalAturar2 => CalAturar.SiNo();
        public string Ignorar2 => Ignorar.SiNo();

        public readonly List<Node> Nodes = [];

        public bool EsAplicacio { get; set; }

        public Node(CategoriaAplicacions categoriaAplicacions)
        {
            Nom = categoriaAplicacions.Nom;
            Descripcio = categoriaAplicacions.Descripcio;
            CalAturar = categoriaAplicacions.CalAturar;
            Ignorar = categoriaAplicacions.Ignorar;
            Executable = "";
            Icona = null;

            EsAplicacio = false;
        }

        public Node(Aplicacio aplicacio)
        {
            Nom = aplicacio.Nom;
            Descripcio = aplicacio.Descripcio;
            CalAturar = aplicacio.CalAturar;
            Ignorar = aplicacio.Ignorar;
            Executable = aplicacio.Executable;
            Icona = aplicacio.Icona;

            EsAplicacio = true;
        }
    }
}
