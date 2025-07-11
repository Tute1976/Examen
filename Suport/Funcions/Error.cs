using System;
using System.Windows.Forms;

namespace Examen.Suport.Funcions
{
    public static class Error
    {
        public static void Mostrar(this string missatge, MessageBoxIcon icona)
        {
            MessageBox.Show(missatge, Application.ProductName, MessageBoxButtons.OK, icona);
        }

        public static void Mostrar(this Exception ex)
        {
            var missatge = $"S'ha produït un error: {ex.Message}\n\nDetalls: {ex.StackTrace}";
            missatge.Mostrar(MessageBoxIcon.Error);
        }
    }
}
