using Examen.Suport.Funcions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Newtonsoft.Json;

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

        public bool Aturar(BackgroundWorker backgroundWorker)
        {
            try
            {
                if (CalAturar)
                {
                    var processos = Process.GetProcessesByName(NomExecutableCurt);
                    var n = processos.Length;
                    while (n > 0)
                    {
                        var taskKill = Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\taskkill.exe");
                        var arguments = $"/F /IM \"{Executable}\" /T";
                        if (!Helper.Executar(taskKill, arguments))
                            break;

                        processos = Process.GetProcessesByName(NomExecutableCurt);
                        n = processos.Length;
                    }

                    var msg = n > 0
                        ? $"L'aplicació '{Nom}', no s'ha pogut aturar correctament."
                        : $"L'aplicación '{Nom}', ha estat aturada correctament.";
                    backgroundWorker.ReportProgress(10, msg);

                    return n == 0;
                }

                if (Helper._Notificades.Contains(Nom)) 
                    return false;
                
                backgroundWorker.ReportProgress(10, $@"L'aplicació '{Nom}', no hauria d'estar en ús.");
                Helper._Notificades.Add(Nom);

                return false;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }
    }
}