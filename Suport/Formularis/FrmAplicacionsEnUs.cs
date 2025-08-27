using System.IO;
using System.Linq;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;

namespace Examen.Suport.Formularis
{
    public partial class FrmAplicacionsEnUs : FormAdv
    {
        private ContenidorAplicacionsEnUs ContenidorAplicacionsEnUs
        {
            get => (ContenidorAplicacionsEnUs)propietats.SelectedObject;
            set
            {
                propietats.SelectedObject = value;
                propietats.Refresh();
            }
        }

        public FrmAplicacionsEnUs(string estacio, ContenidorAplicacionsEnUs contenidorAplicacionsEnUs)
        {
            InitializeComponent();

            Text = $@"Aplicacions en ús a {estacio}";
            ContenidorAplicacionsEnUs = contenidorAplicacionsEnUs;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void bCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void bExportar_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var aplicacions = ContenidorAplicacionsEnUs.AplicacionsEnUs.Select(aplicacioEnUs => new Aplicacio(aplicacioEnUs)).ToList();

                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                aplicacions.Desar(saveFileDialog.FileName);
            }
        }
    }
}
