using System.Windows.Forms;
using Examen.Suport.Classes;
using Syncfusion.Windows.Forms;

namespace Examen.Professor.Formularis
{
    public partial class FrmAplicacions : MetroForm
    {
        public ContenidorAplicacions ContenidorAplicacions
        {
            get => (ContenidorAplicacions)propietats.SelectedObject;
            private set
            {
                propietats.SelectedObject = value;
                propietats.Refresh();
            }
        }

        public FrmAplicacions(ContenidorAplicacions contenidorAplicacions)
        {
            InitializeComponent();

            ContenidorAplicacions = contenidorAplicacions;
        }

        private void bDesar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
