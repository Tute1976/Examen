using System;
using System.Windows.Forms;
using Examen.Suport.Controls;

namespace Examen.Professor.Formularis
{
    public partial class FrmEdicioCodi : FormAdv
    {
        private string Codi { get; set; }
        public string NouCodi { get; set; }

        public FrmEdicioCodi(string codi)
        {
            InitializeComponent();

            Codi = codi;
            NouCodi = codi;

            OmpleCamps();
        }

        private void OmpleCamps()
        {
            txtCodi.Text = Codi;
            txtCodi.Tag = Codi;
        }

        private void BDesfer_Click(object sender, EventArgs e)
        {
            OmpleCamps();

            bDesar.Enabled = false;
            bDesfer.Visible = false;
            NouCodi = Codi;
        }

        private void BDesar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TxtNom_TextChanged(object sender, EventArgs e)
        {
            bDesar.Enabled = !txtCodi.Text.Equals(txtCodi.Tag);
            bDesfer.Visible = bDesar.Enabled;
            NouCodi = txtCodi.Text;
        }
    }
}
