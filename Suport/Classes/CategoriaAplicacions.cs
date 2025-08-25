using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Examen.Suport.Classes
{
    [Serializable, Category("Categoria"), DisplayName("Categoria")]
    public class CategoriaAplicacions
    {
        [Category("Categoria"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Nom"),
         Description("Nom de la categoria")]
        public string Nom { get; set; } = "";

        [Category("Categoria"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Descripció"),
         Description("Descripció de la categoria")]
        public string Descripcio { get; set; } = "";

        [Category("Categoria"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Aplicacions"),
         Description("Aplicacions no permeses")]
        public List<Aplicacio> Aplicacions { get; set; } = [];

        public override string ToString()
        {
            return Nom;
        }
    }
}
