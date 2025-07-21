using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen.Alumne
{
    public partial class Principal : MetroForm
    {
        private static EstacioAlumne EstacioAlumne { get; set; }
        private AdreçaPort AdreçaPortProfessor { get; set; } = new AdreçaPort();
        private List<Aplicacio> Aplicacions { get; set; } = new List<Aplicacio>();
        
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            imatge.Image = imatgesConnecta.Images[0];
            imatge.Tag = 0;

#if DEBUG
            txtNom.Text = @"Tuté";
            txtCodi.Text = @"F:22B3";
#endif
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            bIniciar.Enabled = !string.IsNullOrEmpty(txtNom.Text) && !string.IsNullOrEmpty(txtCodi.Text);

            bIniciar.Text = @"Connectar";
            bIniciar.BackColor = Color.FromArgb(83, 180, 237);
        }

        private void BTancar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!timerTemps.Enabled) 
                    return;

                Hide();

                var ret = ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Fi);
            }
            catch (Exception ex)
            {
                ex.Mostrar(false);
            }
            finally
            {
                Application.Exit();
            }
        }

        private void BIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bIniciar.Text == @"Connectar")
                {
                    if (txtCodi.Text.ObtenirAdreça(out var adreçaPort) &&
                        adreçaPort.Provar(EstacioAlumne))
                    {
                        AdreçaPortProfessor = adreçaPort;

                        bIniciar.Text = @"Iniciar";
                        bIniciar.BackColor = Color.FromArgb(128, 255, 128);

                        txtNom.Enabled = false;
                        txtCodi.Enabled = false;

                        imatge.Image = imatgesConnecta.Images[1];
                        imatge.Tag = 1;
                    }
                    else
                    {
                        @"El codi no és vàlid".Mostrar(MessageBoxIcon.Error);

                        bIniciar.Text = @"Connectar";
                        bIniciar.BackColor = Color.FromArgb(83, 180, 237);

                        imatge.Image = imatgesConnecta.Images[0];
                        imatge.Tag = 0;
                    }
                }
                else if (bIniciar.Text == @"Amagar")
                {
                    Hide();
                }
                else
                {
                    EstacioAlumne = new EstacioAlumne(txtNom.Text);

                    bIniciar.Text = @"Amagar";
                    bIniciar.BackColor = Color.FromArgb(255, 255, 224);
                    bIniciar.Width -= 75;
                    bTancar.Left -= 75;
                    bInfo.Show();

                    var json = ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Inici);
                    Aplicacions = json.Deserialitzar<List<Aplicacio>>();

                    timerTemps.Interval = Properties.Settings.Default.IntevarvalTemps * 1000;
                    timerTemps.Start();
                    timerImatge.Start();

                    notifyIcon.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();

                bIniciar.Text = @"Connectar";
                bIniciar.BackColor = Color.FromArgb(83, 180, 237);

                imatge.Image = imatgesConnecta.Images[0];
                imatge.Tag = 0;
            }
        }
        
        private void TimerTemps_Tick(object sender, EventArgs e)
        {
            try
            {
                var json = ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Temps);
                Aplicacions = json.Deserialitzar<List<Aplicacio>>();

                foreach (var aplicacio in Aplicacions.Where(aplicacio => aplicacio.EnExecucio()))
                {
                    var aturada = aplicacio.Aturar(notifyIcon);
                    ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Deteccio, $"{aplicacio.Nom}:{aturada.SiNo()}");
                }
            }
            catch
            {
                // ignore
            }
        }

        private void TimerImatge_Tick(object sender, EventArgs e)
        {
            if (!Visible)
                return;

            var index = (int)(imatgesConnecta.Tag ?? 0);
            index++;

            if (index >= imatgesConnecta.Images.Count)
                index = 2;

            imatge.Image = imatgesConnecta.Images[index];
            imatgesConnecta.Tag = index;
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon.Visible = false;
        }

        private void BInfo_Click(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;

            var aplicacions = Aplicacions.Select(aplicacio => aplicacio.ToString()).ToList();
            var txt = $"Aplicacions bloquedades:{nl}{nl}{string.Join(nl, aplicacions)}";

            MessageBoxAdv.Show(txt, Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
