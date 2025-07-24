using Examen.Suport.Classes;
using Syncfusion.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using Examen.Suport.Funcions;

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

        private void bImportar_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                {
                    var desti = $@"{Path.GetDirectoryName(Application.ExecutablePath)}\Dades\Aplicacions.json";
                    File.Copy(openFileDialog.FileName, desti, true);
                }

                ContenidorAplicacions.Aplicacions = ContenidorAplicacions.Aplicacions.Llegir(openFileDialog.FileName);
            }
        }

        private void bExportar_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                ContenidorAplicacions.Aplicacions.Desar(saveFileDialog.FileName);
            }
        }
    }
}
