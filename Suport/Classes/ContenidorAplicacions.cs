using System.Collections.Generic;
using System.ComponentModel;

namespace Examen.Suport.Classes
{
    public class ContenidorAplicacions
    {
        [Category("Aplicacions"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Aplicacions"),
         Description("Aplicacions no permeses")]
        public List<Aplicacio> Aplicacions { get; set; } = [];
    }
}
