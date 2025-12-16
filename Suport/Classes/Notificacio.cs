using Examen.Suport.Funcions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Examen.Suport.Classes
{
    public class Notificacio(EstacioAlumne estacioAlumne)
    {
        public EstacioAlumne EstacioAlumne { get; set; } = estacioAlumne;
        public List<AplicacioEnUs> AplicacioEnUs { get; set; }
        public Aplicacio Aplicacio { get; set; }
        public bool Aturada { get; set; }

        public string ImatgeBase64 { get; set; }

        [JsonIgnore]
        public Bitmap Imatge
        {
            get => ImatgeBase64.ToImageFromBase64();
            set => ImatgeBase64 = value.ToBase64(ImageFormat.Png);
        }

        public Notificacio(EstacioAlumne estacioAlumne, List<AplicacioEnUs> aplicacioEnUs) : this(estacioAlumne)
        {
            AplicacioEnUs = aplicacioEnUs;
        }

        public Notificacio(EstacioAlumne estacioAlumne, Aplicacio aplicacio, bool aturada) : this(estacioAlumne)
        {
            Aplicacio = aplicacio;
            Aturada = aturada;
        }

        public Notificacio(EstacioAlumne estacioAlumne, Bitmap imatge) : this(estacioAlumne)
        {
            Imatge = imatge;
        }

        public Notificacio() : this(new EstacioAlumne())
        {

        }
    }
}
