using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Examen.Alumne.Formularis
{
    public partial class FrmPrincipal : MetroForm
    {
        private static EstacioAlumne EstacioAlumne { get; set; }
        private AdreçaPort AdreçaPortProfessor { get; set; } = new AdreçaPort();
        private List<Aplicacio> Aplicacions { get; set; } = new List<Aplicacio>();

        public FrmPrincipal()
        {
            InitializeComponent();

            txtId.Text = $@"Id: {Program.Id}";
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            imatge.Image = imatgesConnecta.Images[0];
            imatge.Tag = 0;

#if DEBUG
            txtNom.Text = @"Tuté";
            txtCodi.Text = @"32:22B3";
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

                ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Fi, out _, out _, out _);
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
                        @"El codi no és vàlid, o el servidor no està disponible".Mostrar(MessageBoxIcon.Error);

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

                    var json = ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Inici, out _, out _, out _);
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
                var deteccio = false;
                foreach (var aplicacio in Aplicacions.Where(aplicacio => aplicacio.EnExecucio()))
                {
                    var aturada = aplicacio.Aturar();
                    ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, TipusMissatge.Deteccio, out _, out _,
                        out _, $"{aplicacio.Nom}:{aturada.SiNo()}");

                    deteccio = true;
                }

                var json = ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne,
                    deteccio ? TipusMissatge.TempsAmbDeteccio : TipusMissatge.Temps, out var pitar,
                    out var bloquejar, out var aturar);
                Aplicacions = json.Deserialitzar<List<Aplicacio>>();

                if (pitar)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Console.Beep(1000, 500);
                        Thread.Sleep(50);
                    }
                }

                if (bloquejar)
                {
                    Helper.LockWorkStation();
                }

                if (aturar)
                {
                    Console.Beep(1000, 1500);

                    var shutdown = Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\shutdown.exe");
                    const string arguments = "/s /t 30 /c \"Aturant estació per petició del professor\"";

                    var psi = new ProcessStartInfo(shutdown)
                    {
                        UseShellExecute = false,
                        Arguments = arguments,
                        CreateNoWindow = true
                    };
                    var process = new Process();
                    process.StartInfo = psi;
                    process.Start();
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
            var aplicacions = Aplicacions.Select(aplicacio => aplicacio.ToString()).ToList();
            var txt = $"Aplicacions bloquedades:\n\n{string.Join("\n", aplicacions.Select(a => $"    {a}    "))}";

            txt.Mostrar();
        }
    }
}
