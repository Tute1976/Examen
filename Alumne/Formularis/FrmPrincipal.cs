using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Examen.Alumne.Funcions;

namespace Examen.Alumne.Formularis
{
    public partial class FrmPrincipal : MetroForm
    {
        public EstacioAlumne EstacioAlumne { get; private set; }
        public AdreçaPort AdreçaPortProfessor { get; private set; } = new();
        public List<Aplicacio> Aplicacions { get; private set; } = [];

        private readonly string _nom;
        private readonly string _codi;

        public FrmPrincipal(string nom, string codi)
        {
            _nom = nom;
            _codi = codi;

            InitializeComponent();

            txtId.Text = $@"Id: {Program.Id}";
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            imatge.Image = imatgesConnecta.Images[0];
            imatge.Tag = 0;

            txtNom.Text = _nom;
            txtCodi.Text = _codi;

            txtVersio.Text = $@"Examen.Alumne v.{Application.ProductVersion}";
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

                ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, [], TipusMissatge.Fi, Helper.Pitar, Helper.Bloquejar, Helper.Aturar, FiServidor);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
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
                        adreçaPort.Provar(EstacioAlumne, FiServidor))
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
                        @"El codi no és vàlid, o el servidor no està disponible".Mostrar(MessageBoxIcon.Error, MessageBoxButtons.OK, true);

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
                    EstacioAlumne = new EstacioAlumne(txtNom.Text, Program.Id);

                    bIniciar.Text = @"Amagar";
                    bIniciar.BackColor = Color.FromArgb(255, 255, 224);
                    bIniciar.Width -= 75;
                    bTancar.Left -= 75;
                    bInfo.Show();

                    var aplicacionsEnUs = Helper.LlistarAplicacionsEnUs();
                    var json = ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, aplicacionsEnUs, TipusMissatge.Inici, Helper.Pitar, Helper.Bloquejar, Helper.Aturar, FiServidor);
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
            _ = new Worker(this, Completat);
        }

        private void Completat(List<Aplicacio> aplicacions)
        {
            Aplicacions = aplicacions;
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
            var aplicacions = Aplicacions.Where(a => !a.Ignorar).Select(a => a.ToString()).ToList();
            if (aplicacions.Count == 0)
                aplicacions.Add(@"No hi ha aplicacions bloquejades");

            var nl = Environment.NewLine;
            var txt = $"Aplicacions bloquedades:{nl}{nl}{string.Join($"{nl}", aplicacions.Select(a => $"    {a}    "))}";

            txt.Mostrar(MessageBoxIcon.Information);
        }

        public void FiServidor()
        {
            try
            {
                Hide();

                ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, [], TipusMissatge.FiServidor, Helper.Pitar, Helper.Bloquejar, Helper.Aturar, FiServidor);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
            finally
            {
                Application.Exit();
            }
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_nom) &&
                !string.IsNullOrEmpty(_codi))
            {
                if (bIniciar.Text.Equals(@"Connectar"))
                    BIniciar_Click(bIniciar, EventArgs.Empty);

                if (bIniciar.Text.Equals(@"Iniciar"))
                    BIniciar_Click(bIniciar, EventArgs.Empty);

                if (bIniciar.Text.Equals(@"Amagar"))
                    BIniciar_Click(bIniciar, EventArgs.Empty);
            }
        }
    }
}
