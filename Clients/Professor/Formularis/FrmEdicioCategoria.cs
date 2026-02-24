using System;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Controls;

namespace Examen.Professor.Formularis
{
    public partial class FrmEdicioCategoria : FormAdv
    {
        public Node Node { get; set; }

        public FrmEdicioCategoria(Node node)
        {
            InitializeComponent();

            Node = node;
            OmpleCamps();
        }
        private void OnModificat(bool modificat)
        {
            bDesar.Enabled = modificat;
            bDesfer.Visible = modificat;
        }

        private void OmpleCamps()
        {
            txtNom.Text = Node.Nom;
            txtDescripcio.Text = Node.Descripcio;
            chkCalAturar.Checked = Node.CalAturar;
            chkIgnorar.Checked = Node.Ignorar;
        }

        private void BDesfer_Click(object sender, EventArgs e)
        {
            Node.Desfer();
            OmpleCamps();

            bDesar.Enabled = false;
            bDesfer.Visible = false;
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
            Node.Nom = txtNom.Text;
            OnModificat(Node.Modificat);
        }

        private void TxtDescripcio_TextChanged(object sender, EventArgs e)
        {
            Node.Descripcio = txtDescripcio.Text;
            OnModificat(Node.Modificat);
        }

        private void ChkCalAturar_CheckedChanged(object sender, EventArgs e)
        {
            Node.CalAturar = chkCalAturar.Checked;
            OnModificat(Node.Modificat);
        }

        private void ChkIgnorar_CheckedChanged(object sender, EventArgs e)
        {
            Node.Ignorar = chkIgnorar.Checked;
            OnModificat(Node.Modificat);
        }
    }
}
