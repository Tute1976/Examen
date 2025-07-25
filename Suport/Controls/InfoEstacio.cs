using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;

namespace Examen.Suport.Controls
{
    public partial class InfoEstacio : UserControl
    {
        public EstacioAlumne EstacioAlumne { get; set; }

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
                bAplicacionsEnUs.Visible = value;
                bTancar.Visible = !value;
            }
        }

        public bool Tancar => bTancar.Visible;

        public string Estat
        {
            get => txtEstat.Text;
            set => txtEstat.Text = value;
        }

        public DateTime Data
        {
            get => EstacioAlumne.DataDarreraConnexio ?? DateTime.Now;
            set
            {
                EstacioAlumne.DataDarreraConnexio = value;
                txtDataInci.Text = Temps.ToNaturalString();
            }
        }

        private TimeSpan TempsCaducada => DateTime.Now - (EstacioAlumne.DataDarreraConnexio ?? DateTime.Now);
        public bool Caducada => TempsCaducada.TotalSeconds > _interval;
        private TimeSpan Temps => DateTime.Now - (EstacioAlumne.DataInici ?? DateTime.Now);

        public int Imatge
        {
            set => imatge.Image = imatges.Images[value];
        }

        public Color BackgroundColor
        {
            get => taula.BackColor; 
            set => taula.BackColor = value;
        }

        public List<AplicacioEnUs> AplicacionsEnUs { get; set; }

        public InfoEstacio(EstacioAlumne estacioAlumne, int interval)
        {
            InitializeComponent();

            EstacioAlumne = estacioAlumne;

            _id = estacioAlumne.Id;
            _interval = interval;

            imatge.Image = imatges.Images[0];

            gb.Text = estacioAlumne.Nom;
            txtEstacio.Text = estacioAlumne.Estacio;
            txtUsuari.Text = estacioAlumne.Usuari;
            txtInformacio.Text = estacioAlumne.Fabricant;
            Data = DateTime.Now;
            txtEstat.Text = "";
        }

        private void bInfo_Click(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;
            $"Identificador de la sessió:{nl}{nl}    {_id}    ".Mostrar(MessageBoxIcon.Information);
        }

        private void bTancar_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void bPitar_Click(object sender, EventArgs e)
        {
            bPitar.Checked = !bPitar.Checked;
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

        private void bAplicacionsEnUs_Click(object sender, EventArgs e)
        {
            var contenidorAplicacionsEnUs = new ContenidorAplicacionsEnUs
            {
                AplicacionsEnUs = AplicacionsEnUs.ToArray()
            };
            var frmAplicacionsEnUs = new FrmAplicacionsEnUs(txtEstacio.Text, contenidorAplicacionsEnUs);
            frmAplicacionsEnUs.Show();
        }
    }
}
