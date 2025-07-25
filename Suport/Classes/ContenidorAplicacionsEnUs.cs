using System.Collections.Generic;
using System.ComponentModel;

namespace Examen.Suport.Classes
{
    public class ContenidorAplicacionsEnUs
    {
        [Category("Aplicacions en ús"),
         Browsable(true),
         ReadOnly(true),
         DisplayName("Aplicacions en ús"),
         Description("Aplicacions executant-se en el client")]
        public AplicacioEnUs[] AplicacionsEnUs { get; set; } = [];
    }
}
