using System;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;

namespace Examen.Suport.Controls
{
    public partial class InfoEstacioV2 : InfoEstacio
    {
        private string _estat;
        private readonly string _informacio;
        private Colors _color;

        // Implementacions del contracte comú:
        public override bool Pitar { get => bPitar.Checked; set => bPitar.Checked = value; }
        public override bool Bloquejar { get => bBloquejar.Checked; set => bBloquejar.Checked = value; }
        public override bool Aturar { get => bAturar.Checked; set => bAturar.Checked = value; }

        public override bool MostrarBotons
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
        public override bool Tancar => bTancar.Visible;
        public override string Estat { get => _estat; set => _estat = value; }
        public sealed override DateTime Data
        {
            get => EstacioAlumne.DataDarreraConnexio ?? DateTime.Now;
            set
            {
                EstacioAlumne.DataDarreraConnexio = value; 
                txtTemps.Text = Temps.ToNaturalString();
            }
        }

        // Pots mantenir el teu enum 'Imatge' i el setter específic:
        public override Imatge Imatge { set => imatge.Image = imatges.Images[(int)value]; }

        public override Colors Color
        {
            get => _color;
            set
            {
                _color = value;

                panelFons.StripeColor = _color switch
                {
                    Colors.Correcte => System.Drawing.Color.PaleGreen,
                    Colors.Vermell => System.Drawing.Color.LightCoral,
                    Colors.VermellFosc => System.Drawing.Color.Coral,
                    Colors.Blanc => System.Drawing.Color.DeepSkyBlue,
                    _ => System.Drawing.Color.LightBlue
                };
            }
        }

        public InfoEstacioV2() : this(new EstacioAlumne("", Guid.Empty), 30) { }
        public InfoEstacioV2(EstacioAlumne estacioAlumne, int interval) : base(estacioAlumne, interval)
        {
            InitializeComponent();

            imatge.Image = imatges.Images[0];

            txtNom.Text = estacioAlumne.Nom;
            txtEstacio.Text = estacioAlumne.Estacio;
            txtUsuari.Text = estacioAlumne.Usuari;
            _informacio = estacioAlumne.Fabricant;
            Data = DateTime.Now;
            _estat = "";
        }

        private void BInfo_Click(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;
            var txt = $"Estat:{nl}    {_estat}   " + nl + nl +
                      $"Informació: {_informacio}   " + nl +
                      $"Identificador de la sessió: {EstacioAlumne.Id}   ";
            txt.Mostrar(MessageBoxIcon.Information);
        }

        private void BTancar_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void BPitar_Click(object sender, EventArgs e)
        {
            bPitar.Checked = !bPitar.Checked;
        }

        private void BBloquejar_Click(object sender, EventArgs e)
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

        private void BAturar_Click(object sender, EventArgs e)
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

        private void BAplicacionsEnUs_Click(object sender, EventArgs e)
        {
            var contenidorAplicacionsEnUs = new ContenidorAplicacionsEnUs
            {
                AplicacionsEnUs = [.. AplicacionsEnUs]
            };
            var frmAplicacionsEnUs = new FrmAplicacionsEnUs(txtEstacio.Text, contenidorAplicacionsEnUs);
            frmAplicacionsEnUs.Show();
        }
    }
}
