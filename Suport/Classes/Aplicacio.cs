using Examen.Suport.Funcions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Examen.Suport.Classes
{
    [Serializable, Category("Aplicació"), DisplayName("Aplicació")]
    public class Aplicacio
    {
        [Category("Aplicació"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Nom"),
         Description("Nom de l'aplicació")]
        public string Nom { get; set; } = "";

        [Category("Aplicació"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Executable"),
         Description("Nom del fitxer executable (*.exe)")]
        public string Executable { get; set; } = "";

        [Category("Acció"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Cal aturar?"),
         Description("Indica si cal aturar l'aplicació en detectar-la")]
        public bool CalAturar { get; set; }

        [Category("Acció"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Ignorar"),
         Description("Ignorar l'aplicació en detectar-la")]
        public bool Ignorar { get; set; }

        [Browsable(false)]
        private string ExecutableCurt => string.Join(".", Executable.Split('.').Reverse().Skip(1).Reverse());

        public Aplicacio()
        {
        }

        public Aplicacio(string nom, string executable, bool calAturar, bool ignorar)
        {
            Nom = nom;
            Executable = executable;
            CalAturar = calAturar;
            Ignorar = ignorar;
        }

        public override string ToString()
        {
            return $"{Nom} ({Executable})";
        }

        public bool EnExecucio()
        {
            try
            {
                if (Ignorar)
                    return false;

                var processos = Process.GetProcessesByName(ExecutableCurt);
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
                    var processos = Process.GetProcessesByName(ExecutableCurt);
                    var n = processos.Length;
                    while (n > 0)
                    {
                        try
                        {
                            var taskKill = Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\taskkill.exe");
                            var arguments = $"/F /IM \"{Executable}\" /T";

                            var psi = new ProcessStartInfo(taskKill)
                            {
                                UseShellExecute = false,
                                Arguments = arguments,
                                CreateNoWindow = true
                            };
                            var process = new Process();
                            process.StartInfo = psi;
                            process.Start();

                            //                            processos.Last().Kill();
                        }
                        catch (Exception ex)
                        {
                            ex.Mostrar(false);
                            break;
                        }

                        processos = Process.GetProcessesByName(ExecutableCurt);
                        n = processos.Length;
                    }

                    var msg = n > 0
                        ? $"L'aplicació '{Nom}', no s'ha pogut aturar correctament."
                        : $"L'aplicación '{Nom}', ha estat aturada correctament.";
                    backgroundWorker.ReportProgress(15, msg);

                    return n == 0;
                }

                backgroundWorker.ReportProgress(15, $@"L'aplicació '{Nom}', no s'ha d'aturar segons directrius.");

                return false;
            }
            catch (Exception ex)
            {
                ex.Mostrar(false);
            }

            return false;
        }
    }
}