using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Examen.Suport.Classes
{
    [Serializable, Category("Aplicació en ús"), DisplayName("Aplicació en ús")]
    public class AplicacioEnUs(string nom, string descripcio, string executable)
        : AplicacioBase(nom, descripcio, executable)
    {
        [JsonIgnore]
        [Browsable(false)]
        public Aplicacio Aplicacio { get; set; }

    }
}
