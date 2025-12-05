using System.Collections.Generic;

namespace Examen.Suport.Classes
{
    public class Notificacio(EstacioAlumne estacioAlumne, List<AplicacioEnUs> aplicacioEnUs)
    {
        public EstacioAlumne EstacioAlumne { get; set; } = estacioAlumne;
        public List<AplicacioEnUs> AplicacioEnUs { get; set; } = aplicacioEnUs;

    }
}
