using System.Windows.Forms;

namespace Examen.Suport.Funcions
{
    public static class ContextMenuHelper
    {
        public static void Mostrar(this ToolStripMenuItem control)
        {
            control.Visible = true;
        }

        public static void Amagar(this ToolStripMenuItem control)
        {
            control.Visible = false;
        }

        public static void Mostrar(this ToolStripSeparator control)
        {
            control.Visible = true;
        }

        public static void Amagar(this ToolStripSeparator control)
        {
            control.Visible = false;
        }
    }
}
