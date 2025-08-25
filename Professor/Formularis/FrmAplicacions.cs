using Examen.Suport.Classes;
using Syncfusion.Windows.Forms;
using System.IO;
using System.Linq;
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
                if (File.Exists(openFileDialog.FileName))
                {
                    var aplicacions = Examen.Suport.Funcions.Text.Llegir(openFileDialog.FileName);

                    var ret = @"Vols importar la llista d'aplicacions (Sí) o subtituïr-la (No)?".Mostrar(MessageBoxIcon.Question,
                        MessageBoxButtons.YesNoCancel);
                    switch (ret)
                    {
                        case DialogResult.Yes:
                            ContenidorAplicacions.CategoriaAplicacions.AddRange(aplicacions);
                            ContenidorAplicacions.CategoriaAplicacions = ContenidorAplicacions.CategoriaAplicacions.GroupBy(a => a.Nom).Select(g => g.First()).ToList();
                            break;

                        case DialogResult.No:
                            ContenidorAplicacions.CategoriaAplicacions = aplicacions;
                            break;
                    }
                }
            }
        }

        private void bExportar_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                ContenidorAplicacions.CategoriaAplicacions.Desar(saveFileDialog.FileName);
            }
        }
    }
}
