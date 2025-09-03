using System;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Funcions;

namespace Examen.Suport.Controls
{
    public partial class InfoEstacioV1 : InfoEstacio
    {
        private Colors _color;
        private readonly Action<string, ContenidorAplicacionsEnUs> _onAplicacionsEnUs;

        // Les existents:
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
        public override string Estat { get => txtEstat.Text; set => txtEstat.Text = value; }
        public sealed override DateTime Data
        {
            get => EstacioAlumne.DataDarreraConnexio ?? DateTime.Now;
            set
            {
                EstacioAlumne.DataDarreraConnexio = value; 
                txtDataInci.Text = Temps.ToNaturalString();
            }
        }

        public override Imatge Imatge
        {
            set => imatge.Image = imatges.Images[(int)value];
        }

        public override Colors Color
        {
            get => _color;
            set
            {
                _color = value;

                taula.BackColor = _color switch
                {
                    Colors.Correcte => System.Drawing.Color.PaleGreen,
                    Colors.Vermell => System.Drawing.Color.LightCoral,
                    Colors.VermellFosc => System.Drawing.Color.Coral,
                    Colors.Blanc => System.Drawing.Color.Transparent,
                    _ => System.Drawing.Color.LightBlue
                };
            }
        }

        public InfoEstacioV1() : this(new EstacioAlumne("", Guid.Empty), 30, null) { }

        public InfoEstacioV1(EstacioAlumne estacioAlumne, int interval, Action<string, ContenidorAplicacionsEnUs> onAplicacionsEnUs) : base (estacioAlumne, interval)
        {
            InitializeComponent();

            imatge.Image = imatges.Images[0];

            gb.Text = estacioAlumne.Nom;
            txtEstacio.Text = estacioAlumne.Estacio;
            txtUsuari.Text = estacioAlumne.Usuari;
            txtInformacio.Text = estacioAlumne.Fabricant;
            Data = DateTime.Now;
            txtEstat.Text = "";

            _onAplicacionsEnUs = onAplicacionsEnUs;
        }

        private void BInfo_Click(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;
            $"Identificador de la sessió:{nl}{nl}    {EstacioAlumne.Id}    ".Mostrar(MostrarIcon.Information);
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
                    $"Vols bloquejar l'estació {txtEstacio.Text} ?".Mostrar(MostrarIcon.Question,
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
                    $"Vols aturar l'estació {txtEstacio.Text} ?".Mostrar(MostrarIcon.Question,
                        MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
        }

        private void BAplicacionsEnUs_Click(object sender, EventArgs e)
        {
            var contenidorAplicacionsEnUs = new ContenidorAplicacionsEnUs
            {
                AplicacionsEnUs = [.. AplicacionsEnUs]
            };
            _onAplicacionsEnUs.Invoke(EstacioAlumne.Estacio, contenidorAplicacionsEnUs);
        }
    }
}
