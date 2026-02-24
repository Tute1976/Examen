using Examen.Suport.Funcions;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Examen.Suport.Classes
{
    public class Node
    {
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public bool CalAturar { get; set; }
        public bool Ignorar { get; set; }
        public string Executable { get; set; }
        public Bitmap Icona { get; set; }

        private string TagNom { get; set; }
        private string TagDescripcio { get; set; }
        private bool TagCalAturar { get; set; }
        private bool TagIgnorar { get; set; }
        private string TagExecutable { get; set; }
        private Bitmap TagIcona { get; set; }

        public string CalAturar2 => CalAturar.SiNo();
        public string Ignorar2 => Ignorar.SiNo();

        public readonly Node Pare = null;
        public List<Node> Nodes = [];

        public bool EsAplicacio => Aplicacio != null;

        public bool Modificat =>
            !Nom.Equals(TagNom) ||
            !Descripcio.Equals(TagDescripcio) ||
            !CalAturar.Equals(TagCalAturar) ||
            !Ignorar.Equals(TagIgnorar) ||
            !Executable.Equals(TagExecutable) ||
            !Icona.ToBase64(ImageFormat.Png).Equals(TagIcona.ToBase64(ImageFormat.Png));

        public CategoriaAplicacions CategoriaAplicacions { get; }

        public Aplicacio Aplicacio { get; }

        public Node(CategoriaAplicacions categoriaAplicacions = null)
        {
            categoriaAplicacions ??= new CategoriaAplicacions();

            Nom = categoriaAplicacions.Nom;
            Descripcio = categoriaAplicacions.Descripcio;
            CalAturar = categoriaAplicacions.CalAturar;
            Ignorar = categoriaAplicacions.Ignorar;
            Executable = "";
            Icona = null;

            TagNom = categoriaAplicacions.Nom;
            TagDescripcio = categoriaAplicacions.Descripcio;
            TagCalAturar = categoriaAplicacions.CalAturar;
            TagIgnorar = categoriaAplicacions.Ignorar;
            TagExecutable = "";
            TagIcona = null;

            CategoriaAplicacions = categoriaAplicacions;
            Aplicacio = null;
        }

        public Node(Node pare, Aplicacio aplicacio = null)
        {
            Pare = pare;

            aplicacio ??= new Aplicacio();

            Nom = aplicacio.Nom;
            Descripcio = aplicacio.Descripcio;
            CalAturar = aplicacio.CalAturar;
            Ignorar = aplicacio.Ignorar;
            Executable = aplicacio.Executable;
            Icona = aplicacio.Icona;

            TagNom = aplicacio.Nom;
            TagDescripcio = aplicacio.Descripcio;
            TagCalAturar = aplicacio.CalAturar;
            TagIgnorar = aplicacio.Ignorar;
            TagExecutable = aplicacio.Executable;
            TagIcona = aplicacio.Icona;

            CategoriaAplicacions = null;
            Aplicacio = aplicacio;
        }

        public void Desar()
        {
            foreach (var node in Nodes)
                node.Desar();

            if (CategoriaAplicacions != null)
            {
                CategoriaAplicacions.Nom = Nom;
                CategoriaAplicacions.Descripcio = Descripcio;
                CategoriaAplicacions.CalAturar = CalAturar;
                CategoriaAplicacions.Ignorar = Ignorar;
            }

            if (Aplicacio != null)
            {
                Aplicacio.Nom = Nom;
                Aplicacio.Descripcio = Descripcio;
                Aplicacio.CalAturar = CalAturar;
                Aplicacio.Ignorar = Ignorar;
                Aplicacio.Executable = Executable;
                Aplicacio.Icona = Icona;
            }
        }

        public void Desfer()
        {
            Nom = TagNom;
            Descripcio = TagDescripcio;
            CalAturar = TagCalAturar;
            Ignorar = TagIgnorar;
            Executable = TagExecutable;
            Icona = TagIcona;

            foreach (var node in Nodes)
                node.Desfer();
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
