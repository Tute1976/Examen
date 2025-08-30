using Examen.Suport.Funcions;
using System.Collections.Generic;
using System.Drawing;

namespace Examen.Suport.Classes
{
    public class Node
    {
        public StringTag Nom { get; set; }
        public StringTag Descripcio { get; set; }
        private BoolTag CalAturar { get; }
        private BoolTag Ignorar { get; }
        public StringTag Executable { get; set; }

        public BitmapTag Icona { get; set; }

        public string CalAturar2 => CalAturar.Valor.SiNo();
        public string Ignorar2 => Ignorar.Valor.SiNo();

        public readonly List<Node> Nodes = [];

        public bool EsAplicacio => Aplicacio != null;

        private CategoriaAplicacions CategoriaAplicacions { get; }
        private Aplicacio Aplicacio { get; }

        public Node(CategoriaAplicacions categoriaAplicacions = null)
        {
            categoriaAplicacions ??= new CategoriaAplicacions();

            Nom = new StringTag(categoriaAplicacions.Nom);
            Descripcio = new StringTag(categoriaAplicacions.Descripcio);
            CalAturar = new BoolTag(categoriaAplicacions.CalAturar);
            Ignorar = new BoolTag(categoriaAplicacions.Ignorar);
            Executable = new StringTag();
            Icona = null;

            CategoriaAplicacions = categoriaAplicacions;
            Aplicacio = null;
        }

        public Node(Aplicacio aplicacio = null)
        {
            aplicacio ??= new Aplicacio();

            Nom = new StringTag(aplicacio.Nom);
            Descripcio = new StringTag(aplicacio.Descripcio);
            CalAturar = new BoolTag(aplicacio.CalAturar);
            Ignorar = new BoolTag(aplicacio.Ignorar);
            Executable = new StringTag(aplicacio.Executable);
            Icona = new BitmapTag(aplicacio.Icona);

            CategoriaAplicacions = null;
            Aplicacio = aplicacio;
        }

        public void Desar()
        {
            foreach (var node in Nodes)
                node.Desar();

            if (CategoriaAplicacions != null)
            {
                CategoriaAplicacions.Nom = Nom.Valor;
                CategoriaAplicacions.Descripcio = Descripcio.Valor;
                CategoriaAplicacions.CalAturar = CalAturar.Valor;
                CategoriaAplicacions.Ignorar = Ignorar.Valor;
            }

            if (Aplicacio != null)
            {
                Aplicacio.Nom = Nom.Valor;
                Aplicacio.Descripcio = Descripcio.Valor;
                Aplicacio.CalAturar = CalAturar.Valor;
                Aplicacio.Ignorar = Ignorar.Valor;
                Aplicacio.Executable = Executable.Valor;
                Aplicacio.Icona = Icona.Valor;
            }
        }

        public void Desfer()
        {
            Nom.Desfer();
            Descripcio.Desfer();
            CalAturar.Desfer();
            Ignorar.Desfer();
            Executable.Desfer();
            Icona.Desfer();

            foreach (var node in Nodes)
                node.Desfer();
        }
    }

    public class StringTag(string valor = "")
    {
        public string Valor { get; set; } = valor;
        private string Tag { get; } = valor;

        public bool Modificat => !Valor.Equals(Tag);

        public void Desfer()
        {
            Valor = Tag;
        }
    }

    public class BoolTag(bool valor)
    {
        public bool Valor { get; set; } = valor;
        private bool Tag { get; } = valor;

        public bool Modificat => !Valor.Equals(Tag);

        public void Desfer()
        {
            Valor = Tag;
        }
    }

    public class BitmapTag(Bitmap valor)
    {
        public Bitmap Valor { get; set; } = valor;
        private Bitmap Tag { get; } = valor;

        public bool Modificat => !Valor.Equals(Tag);

        public void Desfer()
        {
            Valor = Tag;
        }
    }
}
