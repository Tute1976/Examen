using System;
using System.Windows.Forms;

namespace Examen.Suport.Funcions
{
    public static class Error
    {
        public static void Mostrar(this string missatge, MessageBoxIcon icona = MessageBoxIcon.Information)
        {
            MessageBox.Show(missatge, Application.ProductName, MessageBoxButtons.OK, icona);
        }

        public static void Mostrar(this Exception ex, bool mostrarMissatge = true)
        {
            if (!mostrarMissatge)
                return;

            var missatge = $"S'ha produït un error: {ex.Message}{Environment.NewLine}Detalls: {ex.StackTrace}";
            missatge.Mostrar(MessageBoxIcon.Error);
        }
    }
}
