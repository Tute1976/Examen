using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;

namespace Examen.Suport.Controls
{
    public enum ColorsFranja
    {
        Blanc,
        Blau,
        Verd,
        Vermell,
        VermellFosc,
        Defecte
    }

    public enum Imatge
    {
        Nou = 1,
        Atencio = 2,
        Vell = 3,
        Defecte = 0
    }

    public partial class InfoEstacioAdv : UserControl
    {
        private EstacioAlumne EstacioAlumne { get; set; }
        public List<AplicacioEnUs> AplicacionsEnUs { get; set; } = [];

        private readonly Guid _id;
        private readonly int _interval;
        private string _estat;
        private readonly string _informacio;
        private ColorsFranja _colorFranja;

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
            get => _estat;
            set => _estat = value;
        }

        public DateTime Data
        {
            get => EstacioAlumne.DataDarreraConnexio ?? DateTime.Now;
            set
            {
                EstacioAlumne.DataDarreraConnexio = value;
                txtTemps.Text = Temps.ToNaturalString();
            }
        }

        private TimeSpan TempsCaducada => DateTime.Now - (EstacioAlumne.DataDarreraConnexio ?? DateTime.Now);
        public bool Caducada => TempsCaducada.TotalSeconds > _interval;
        private TimeSpan Temps => DateTime.Now - (EstacioAlumne.DataInici ?? DateTime.Now);

        public Imatge Imatge
        {
            set => imatge.Image = imatges.Images[(int)value];
        }

        public ColorsFranja ColorFranja
        {
            get => _colorFranja;
            set
            {
                _colorFranja = value;

                panelFons.StripeColor = _colorFranja switch
                {
                    ColorsFranja.Verd => Color.PaleGreen,
                    ColorsFranja.Vermell => Color.LightCoral,
                    ColorsFranja.VermellFosc => Color.Coral,
                    ColorsFranja.Blanc => Color.DeepSkyBlue,
                    _ => Color.LightBlue
                };
            }
        }

        public InfoEstacioAdv(EstacioAlumne estacioAlumne, int interval)
        {
            InitializeComponent();

            EstacioAlumne = estacioAlumne;

            _id = estacioAlumne.Id;
            _interval = interval;

            imatge.Image = imatges.Images[0];

            txtNom.Text = estacioAlumne.Nom;
            txtEstacio.Text = estacioAlumne.Estacio;
            txtUsuari.Text = estacioAlumne.Usuari;
            _informacio = estacioAlumne.Fabricant;
            Data = DateTime.Now;
            _estat = "";
        }

        private void bInfo_Click(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;
            var txt = $"Estat:{nl}    {_estat}   " + nl + nl +
                      $"Informació: {_informacio}   " + nl +
                      $"Identificador de la sessió: {_id}   ";
            txt.Mostrar(MessageBoxIcon.Information);
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
