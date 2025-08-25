using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Examen.Suport.Funcions
{
    public static class Error
    {
        static Error()
        {
            var metroColorTable = new MetroStyleColorTable
            {
                NoButtonBackColor = Color.LightSalmon,
                YesButtonBackColor = Color.SkyBlue,
                OKButtonBackColor = Color.Green,
                CaptionBarColor = Color.FromArgb(83, 180, 237),
                CaptionForeColor = Color.White,
                BorderColor = Color.FromArgb(83, 180, 237)
            };
            MessageBoxAdv.MetroColorTable = metroColorTable;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
        }

        public static DialogResult Mostrar(this string missatge, MessageBoxIcon icona, MessageBoxButtons botons = MessageBoxButtons.OK, bool mostrarMissatge = false)
        {
            try
            {
                mostrarMissatge = mostrarMissatge | (icona != MessageBoxIcon.Error);
                var nl = Environment.NewLine;

                Trace.AutoFlush = true;
                var mm = missatge.Replace(nl, "^").Replace("^^", "^").Split('^');
                var tt = new List<string>();
                foreach (var m in mm)
                {
                    Trace.WriteLine($@"Examen {DateTime.Now:G} [{icona}]: {m}");
                    tt.Add($@"{DateTime.Now:G} [{icona}]: {m}{nl}");
                }
                EscriuFitxer(tt.ToArray());

                return !mostrarMissatge ? 
                    DialogResult.None : 
                    MessageBoxAdv.Show(missatge, Application.ProductName, botons, icona);
            }
            catch
            {
                // ignore any error in the logging process
            }

            return DialogResult.None;
        }

        private static void EscriuFitxer(string[] missatge)
        {
            try
            {
                var fitxer = Path.GetFullPath(Environment.ExpandEnvironmentVariables(@".\error.log"));
                File.AppendAllLines(fitxer, missatge, Encoding.UTF8);
            }
            catch
            {
                // ignore any error in the logging process
            }
        }

        public static void Mostrar(this Exception ex, bool mostrarMissatge = false)
        {
            try
            {
                var nl = Environment.NewLine;
                var missatge = $"S'ha produït un error: {ex.Message}{nl}{nl}Detalls: {ex.StackTrace}";
                missatge.Mostrar(MessageBoxIcon.Error, MessageBoxButtons.OK, mostrarMissatge);
            }
            catch
            {
                // ignore any error in the logging process
            }
        }
    }
}
