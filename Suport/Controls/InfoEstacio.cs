using System;
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Funcions;

namespace Examen.Suport.Controls
{
    public partial class InfoEstacio : UserControl
    {
        private readonly Guid _id;
        private readonly int _interval;

        public bool Pitar
        {
            get => bPitar.Checked;
            set => bPitar.Checked = value;
        }

        public bool Bloquejar
        {
            get => bBloquejar.Checked;
            set => bBloquejar.Checked = value;
        }

        public bool Aturar
        {
            get => bAturar.Checked;
            set => bAturar.Checked = value;
        }

        public bool MostrarBotons
        {
            set
            {
                bPitar.Visible = value;
                bBloquejar.Visible = value;
                bAturar.Visible = value;
                bTancar.Visible = !value;
            }
        }

        public string Estat
        {
            get => txtEstat.Text;
            set => txtEstat.Text = value;
        }

        public DateTime DataConnexio
        {
            get => DateTime.Parse(txtDataConnexio.Text);
            set => txtDataConnexio.Text = $@"{value:G}";
        }

        public bool Caducada => DateTime.Now - DataConnexio > TimeSpan.FromSeconds(_interval);

        public int Imatge
        {
            set => imatge.Image = imatges.Images[value];
        }

        public Color BackgroundColor
        {
            get => taula.BackColor; 
            set => taula.BackColor = value;
        }

        public InfoEstacio(EstacioAlumne estacioAlumne, int interval)
        {
            InitializeComponent();

            _id = estacioAlumne.Id;
            _interval = interval;

            imatge.Image = imatges.Images[0];

            gb.Text = estacioAlumne.Nom;
            txtEstacio.Text = estacioAlumne.Estacio;
            txtInformacio.Text = $@"{estacioAlumne.Fabricant} / {estacioAlumne.Model}";
            txtDataInci.Text = $@"{estacioAlumne.DataInici:G}";
            txtDataConnexio.Text = $@"{estacioAlumne.DataDarreraConnexio:G}";
            txtEstat.Text = "";
        }

        private void bInfo_Click(object sender, EventArgs e)
        {
            _id.ToString().Mostrar();
        }

        private void bTancar_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void bPitar_Click(object sender, EventArgs e)
        {
            if (bPitar.Checked)
                bPitar.Checked = false;
            else
            {
                bPitar.Checked =
                    $"Vols fer sonar un xiulet en l'estació {txtEstacio.Text} ?".Mostrar(MessageBoxIcon.Question,
                        MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
        }

        private void bBloquejar_Click(object sender, EventArgs e)
        {
            if (bBloquejar.Checked)
                bBloquejar.Checked = false;
            else
            {
                bBloquejar.Checked =
                    $"Vols bloquejar l'estació {txtEstacio.Text} ?".Mostrar(MessageBoxIcon.Question,
                        MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
        }

        private void bAturar_Click(object sender, EventArgs e)
        {
            if (bAturar.Checked)
                bAturar.Checked = false;
            else
            {
                bAturar.Checked =
                    $"Vols aturar l'estació {txtEstacio.Text} ?".Mostrar(MessageBoxIcon.Question,
                        MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
        }
    }
}
