using System;
using System.ComponentModel;

namespace Examen.Suport.Classes
{
    [Serializable, Category("Aplicació en ús"), DisplayName("Aplicació en ús")]
    public class AplicacioEnUs
    {
        [Category("Aplicació en ús"),
         Browsable(true),
         ReadOnly(true),
         DisplayName("Nom"),
         Description("Nom de l'aplicació")]
        public string Nom { get; set; }

        [Category("Aplicació en ús"),
         Browsable(true),
         ReadOnly(true),
         DisplayName("Descripció"),
         Description("Descripció de l'aplicació")]
        public string Descripcio { get; set; }

        [Category("Aplicació en ús"),
         Browsable(true),
         ReadOnly(true),
         DisplayName("Ruta"),
         Description("Ruta de l'aplicació")]
        public string Ruta { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Descripcio) ?
                Nom :
                $"{Descripcio} ({Nom})";
        }
    }
}
