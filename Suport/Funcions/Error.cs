using Syncfusion.Windows.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Examen.Suport.Funcions
{
    public static class Error
    {
        static Error()
        {
            var metroColorTable = new MetroStyleColorTable
            {
                NoButtonBackColor = Color.Red,
                YesButtonBackColor = Color.SkyBlue,
                OKButtonBackColor = Color.Green
            };
            MessageBoxAdv.MetroColorTable = metroColorTable;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
        }

        public static DialogResult Mostrar(this string missatge, MessageBoxIcon icona = MessageBoxIcon.Information, MessageBoxButtons botons = MessageBoxButtons.OK, bool mostrarMissatge = true)
        {
            try
            {
                Trace.AutoFlush = true;
                var mm = missatge.Replace(Environment.NewLine, "^").Split('^');
                foreach (var m in mm)
                    Trace.WriteLine($@"Examen {DateTime.Now:G} [{icona}]: {m}");

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

        public static void Mostrar(this Exception ex, bool mostrarMissatge = true)
        {
            try
            {
                var missatge = $"S'ha produït un error: {ex.Message}{Environment.NewLine}Detalls: {ex.StackTrace}";
                missatge.Mostrar(MessageBoxIcon.Error, MessageBoxButtons.OK, mostrarMissatge);
            }
            catch
            {
                // ignore any error in the logging process
            }
        }
    }
}
