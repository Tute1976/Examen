using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Examen.Suport.Funcions;
using Newtonsoft.Json;
// ReSharper disable MemberCanBePrivate.Global

namespace Examen.Suport.Classes
{
    public abstract class AplicacioBase(string nom, string descripcio, string executable)
    {
        [Category("Aplicació"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Nom"),
         Description("Nom de l'aplicació")]
        public string Nom { get; set; } = nom;

        [Category("Aplicació"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Descripció"),
         Description("Descripció de l'aplicació")]
        public string Descripcio { get; set; } = descripcio;

        [Category("Aplicació"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Executable"),
         Description("Nom del fitxer executable (*.exe)")]
        public string Executable { get; set; } = executable;

        [Browsable(false)] 
        public string ExecutableCurt => Executable.Split('\\').Last();

        [Browsable(false)] 
        protected string NomExecutableCurt => string.Join(".", Executable.Split('.').Reverse().Skip(1).Reverse());

        [Browsable(false)]
        public string ImatgeEnBase64 { get; set; }

        [Category("Aplicació"),
         Browsable(true),
         ReadOnly(true),
         DisplayName("Icona"),
         Description("Icona del programa")]
        [JsonIgnore]
        public Bitmap Icona
        {
            get => string.IsNullOrEmpty(ImatgeEnBase64) ? 
                    Properties.Resources.Aplicacio_32x32 : 
                    ImatgeEnBase64.ToImageFromBase64();
            set => ImatgeEnBase64 = value.ToBase64(ImageFormat.Png);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Descripcio) ?
                $"{Nom} | {Executable}" :
                $"{Descripcio} ({Nom}) | {Executable}";
        }
    }
}
