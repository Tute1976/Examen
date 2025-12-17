using System;
using System.Windows.Forms;
using Examen.Intermediari.Redis;
using Examen.Professor.Formularis;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;

namespace Examen.Professor.Controls
{
    public partial class InfoEstacioV3 : InfoEstacio
    {
        private readonly Action<string> _onHistoric;
        private readonly Action<string, ContenidorAplicacionsEnUs, EstacioAlumne> _onAplicacionsEnUs;

        private readonly string _codi;
        private string _estat;
        //private readonly string _informacio;
        private Colors _color;
        private EstacioAlumne _estacioAlumne;

        public override bool MostrarBotons
        {
            set
            {
                bPitar.Visible = value; 
                bBloquejar.Visible = value; 
                bAturar.Visible = value; 
                bCapturar.Visible = value;
                bAplicacionsEnUs.Visible = value;
                toolStripSeparator1.Visible = value;

                bTancar.Visible = !value;
                toolStripSeparator2.Visible = !value;
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

        public InfoEstacioV3(string codi, EstacioAlumne estacioAlumne, int interval, Action<string> onHistoric, Action<string, ContenidorAplicacionsEnUs, EstacioAlumne> onAplicacionsEnUs) : base(estacioAlumne, interval)
        {
            InitializeComponent();

            _codi = codi;
            _estacioAlumne = estacioAlumne;

            imatge.Image = imatges.Images[0];

            txtNom.Text = estacioAlumne.Nom;
            txtEstacio.Text = estacioAlumne.Estacio;
            txtUsuari.Text = estacioAlumne.Usuari;
            //_informacio = estacioAlumne.Fabricant;
            Data = DateTime.Now;
            _estat = "";

            _onHistoric = onHistoric;
            _onAplicacionsEnUs = onAplicacionsEnUs;
        }

        private void BInfo_Click(object sender, EventArgs e)
        {
            using var frmInformacio = new FrmInformacio(EstacioAlumne);
            frmInformacio.ShowDialog();
        }

        private void BTancar_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void BPitar_Click(object sender, EventArgs e)
        {
            TipusNotificacio.Pitar.EnviarNotificacio(_codi, EstacioAlumne);
        }

        private void BBloquejar_Click(object sender, EventArgs e)
        {
            if ($"Vols bloquejar l'estació {txtEstacio.Text} ?".Mostrar(MostrarIcon.Question,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                TipusNotificacio.Bloquejar.EnviarNotificacio(_codi, EstacioAlumne);
        }

        private void BAturar_Click(object sender, EventArgs e)
        {
            if ($"Vols aturar l'estació {txtEstacio.Text} ?".Mostrar(MostrarIcon.Question,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                TipusNotificacio.Bloquejar.EnviarNotificacio(_codi, EstacioAlumne);
        }

        private void BAplicacionsEnUs_Click(object sender, EventArgs e)
        {
            var contenidorAplicacionsEnUs = new ContenidorAplicacionsEnUs
            {
                AplicacionsEnUs = [.. AplicacionsEnUs]
            };
            _onAplicacionsEnUs.Invoke(EstacioAlumne.Estacio, contenidorAplicacionsEnUs, _estacioAlumne);
        }

        private void BHistoric_Click(object sender, EventArgs e)
        {
            _onHistoric.Invoke(EstacioAlumne.Estacio);
        }

        private void bCapturar_Click(object sender, EventArgs e)
        {
            TipusNotificacio.Capturar.EnviarNotificacio(_codi, EstacioAlumne);
        }
    }
}
