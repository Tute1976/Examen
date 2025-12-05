using Examen.Suport.Funcions;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Examen.Suport.Classes
{
    [Serializable, Category("Aplicació"), DisplayName("Aplicació")]
    public class Aplicacio(string nom, string descripcio, string executable, bool calAturar, bool ignorar) : AplicacioBase(nom, descripcio, executable)
    {
        [Category("Acció"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Cal aturar?"),
         Description("Indica si cal aturar l'aplicació en detectar-la")]
        public bool CalAturar { get; set; } = calAturar;

        [Category("Acció"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Ignorar"),
         Description("Ignorar l'aplicació en detectar-la")]
        public bool Ignorar { get; set; }= ignorar;

        [JsonIgnore]
        [Browsable(false)]
        public string Categoria { get; set; }

        public Aplicacio() : this("", "", "", true, false)
        {
        }

        public Aplicacio(AplicacioEnUs aplicacioEnUs) : this(string.IsNullOrEmpty(aplicacioEnUs.Descripcio) ? aplicacioEnUs.Nom : aplicacioEnUs.Descripcio, aplicacioEnUs.Descripcio, aplicacioEnUs.ExecutableCurt, true, false)
        {
            Icona = aplicacioEnUs.Icona;
        }

        public bool EnExecucio()
        {
            try
            {
                if (Ignorar)
                    return false;

                var processos = Process.GetProcessesByName(NomExecutableCurt);
                return processos.Length > 0;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }
    }
}