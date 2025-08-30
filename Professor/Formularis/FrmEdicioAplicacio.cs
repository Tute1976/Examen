using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;

namespace Examen.Professor.Formularis
{
    public partial class FrmEdicioAplicacio : FormAdv
    {
        public Node Node { get; set; }

        public FrmEdicioAplicacio(Node node)
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
            txtExecutable.Text = Node.Executable;
            pbIcona.Image = Node.Icona;
        }

        private void BDesfer_Click(object sender, EventArgs e)
        {
            Node.Desfer();
            OmpleCamps();

            bDesar.Enabled = false;
            bDesar.Visible = false;
        }

        private void BCercar_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Title = @"Selecciona l'executable";
            dialog.Filter = @"Executables (*.exe)|*.exe|Tots els fitxers (*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            txtExecutable.Text = dialog.SafeFileName ?? "";
            txtNom.Text = string.Join(".", txtExecutable.Text.Split('.').Reverse().Skip(1).Reverse());

            txtDescripcio.Text = Helper.ObtenirDescripcio(dialog.FileName);
            pbIcona.Image = Helper.ObtenirIcona(dialog.FileName);
            Node.Icona = (Bitmap)pbIcona.Image;
            OnModificat(Node.Modificat);
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

        private void TxtExecutable_TextChanged(object sender, EventArgs e)
        {
            Node.Executable = txtExecutable.Text;
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
