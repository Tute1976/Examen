using System;
using System.Diagnostics;
using System.Linq;
using Examen.Suport.Funcions;

namespace Examen.Suport.Classes
{
    public class Aplicacio
    {
        public string Nom { get; set; }
        public string Executable { get; set; }

        private string ExecutableCurt => string.Join(".", Executable.Split('.').Reverse().Skip(1).Reverse());

        public override string ToString()
        {
            return $"{Nom} ({Executable})";
        }

        public bool EnExecucio()
        {
            try
            {
                var processos = Process.GetProcessesByName(ExecutableCurt);
                return processos.Length > 0;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public bool Aturar(System.Windows.Forms.NotifyIcon notifyIcon)
        {
            try
            {
                var processos = Process.GetProcessesByName(ExecutableCurt);
                var n = processos.Length;
                while (n > 0)
                {
                    try
                    {
                        processos.Last().Kill();
                    }
                    catch (Exception ex)
                    {
                        ex.Mostrar(false);
                        break;
                    }

                    processos = Process.GetProcessesByName(ExecutableCurt);
                    n = processos.Length;
                }

                processos = Process.GetProcessesByName(ExecutableCurt);
                n = processos.Length;

                if (n > 0)
                    notifyIcon.ShowBalloonTip(1000, "Aplicació no aturada", $"L'aplicació '{Nom}', no s'ha pogut aturar correctament.", System.Windows.Forms.ToolTipIcon.Error);
                else
                    notifyIcon.ShowBalloonTip(1000, "Aplicació aturada", $"L'aplicación '{Nom}', ha estat aturada correctament.", System.Windows.Forms.ToolTipIcon.Warning);

                return n == 0;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }
    }
}
