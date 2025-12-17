using Examen.Alumne.Funcions;
using Examen.Intermediari.Redis;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Examen.Alumne.Formularis
{
    public partial class FrmPrincipal : FormAdv
    {
        public string Nom { get; private set; }
        public string Codi { get; private set; }

        public EstacioAlumne EstacioAlumne { get; private set; }
        public List<Aplicacio> Aplicacions { get; private set; } = [];
        private Worker Worker { get; set; }
        private DateTime _marcaDeTemps = DateTime.Now;

        public FrmPrincipal(string nom, string codi)
        {
            Dpi.ActivaDpiAware();

            Nom = nom;
            Codi = codi;

            InitializeComponent();

            txtNom.Text = Nom;
            txtCodi.Text = Codi;

            txtId.Text = $@"Id: {Program.Id}";
            txtVersio.Text = $@"Examen.Alumne v.{Application.ProductVersion}";
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            imatge.Image = imatgesConnecta.Images[0];
            imatge.Tag = 0;
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            bIniciar.Enabled = !string.IsNullOrEmpty(txtNom.Text) && !string.IsNullOrEmpty(txtCodi.Text);

            bIniciar.Text = @"Connectar";
            bIniciar.Image = Properties.Resources.Validation_32x32;
            bIniciar.BackColor = Color.FromArgb(83, 180, 237);
        }

        private void BTancar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!timerTemps.Enabled) 
                    return;

                Hide();

                TipusNotificacio.Fi.Notificar(Codi, new Notificacio(EstacioAlumne, Helper.AplicacionsEnUs), nom: Nom);
                //ClientTcp.EnviarEstat(AdreçaPortProfessor, EstacioAlumne, [], TipusMissatge.Fi, Helper.Pitar, Helper.Bloquejar, Helper.Aturar, FiServidor);
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
                    if (Connexio.ExisteixClau(txtCodi.Text))
                    {
                        Nom = txtNom.Text;
                        Codi = txtCodi.Text;

                        bIniciar.Text = @"Iniciar";
                        bIniciar.Image = Properties.Resources.Start_32x32;
                        bIniciar.BackColor = Color.FromArgb(128, 255, 128);

                        txtNom.Enabled = false;
                        txtCodi.Enabled = false;

                        imatge.Image = imatgesConnecta.Images[1];
                        imatge.Tag = 1;
                    }
                    else
                    {
                        @"El codi no és vàlid".Mostrar(MostrarIcon.Error, MessageBoxButtons.OK, true);

                        bIniciar.Text = @"Connectar";
                        bIniciar.Image = Properties.Resources.Validation_32x32;
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
                    bIniciar.Text = @"Amagar";
                    bIniciar.Image = Properties.Resources.Base_32x32;
                    bIniciar.BackColor = Color.FromArgb(255, 255, 224);
                    bIniciar.Width -= 75;
                    bTancar.Left -= 75;
                    bInfo.Show();

                    EstacioAlumne = new EstacioAlumne(Nom);

                    Intermediari.Redis.Alumne.SubscriuresPitar(Codi, EstacioAlumne, EnRebrePitar);
                    Intermediari.Redis.Alumne.SubscriuresBloquejar(Codi, EstacioAlumne, EnRebreBloquejar);
                    Intermediari.Redis.Alumne.SubscriuresAturar(Codi, EstacioAlumne, EnRebreAturar);
                    Intermediari.Redis.Alumne.SubscriuresCapturar(Codi, EstacioAlumne, EnRebreCapturar);
                    Intermediari.Redis.Alumne.SubscriuresTancament(Codi, EstacioAlumne, EnRebreTancament);
                    Intermediari.Redis.Alumne.SubscriuresRefrescar(Codi, EstacioAlumne, EnRebreRefrescar);

                    Intermediari.Redis.Alumne.SubscriuresLlistaAplicacions(Codi, EstacioAlumne, EnRebreAplicacions);
                    Intermediari.Redis.Alumne.SubscriuresIniciSessio(Codi, EnRebreIniciSessio);
                    Intermediari.Redis.Alumne.SubscriuresFiSessio(Codi, EnRebreFiSessio);

                    TipusNotificacio.Inici.Notificar(Codi, new Notificacio(EstacioAlumne, Helper.AplicacionsEnUs));

                    timerTemps.Interval = Properties.Settings.Default.IntervalTemps * 1000;
                    timerTemps.Start();
                    timerImatge.Start();

                    notifyIcon.Visible = true;

                    TimerAplicacionsEnUs_Tick(null, null);
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();

                bIniciar.Text = @"Connectar";
                bIniciar.Image = Properties.Resources.Validation_32x32;
                bIniciar.BackColor = Color.FromArgb(83, 180, 237);

                imatge.Image = imatgesConnecta.Images[0];
                imatge.Tag = 0;
            }
        }

        private void EnRebreAplicacions(List<Aplicacio> aplicacions)
        {
            Connexio.TipusTraça.AlRebreAplicacions.Traça($@"Aplicacions rebudes: {aplicacions.Count}");
            Aplicacions = aplicacions;
        }

        private void EnRebrePitar(string canal)
        {
            Connexio.TipusTraça.AlRebrePitar.Traça(@"Rebuda ordre de pitar");
            Helper.Pitar();
        }

        private void EnRebreBloquejar(string canal)
        {
            Connexio.TipusTraça.AlRebreBloquejar.Traça(@"Rebuda ordre de bloquejar");
            Helper.Bloquejar();
        }

        private void EnRebreAturar(string canal)
        {
            Connexio.TipusTraça.AlRebreAturar.Traça(@"Rebuda ordre d'aturar");
            Helper.Aturar();
        }

        private void EnRebreCapturar(string canal)
        {
            Connexio.TipusTraça.AlRebreCapturar.Traça(@"Rebuda ordre de capturar pantalla");
            var bitmap = Helper.Captura();
            TipusNotificacio.Captura.Notificar(Codi, new Notificacio(EstacioAlumne, bitmap));
        }

        private void EnRebreTancament(string canal)
        {
            try
            {
                Connexio.TipusTraça.AlRebreTancament.Traça(@"Rebuda ordre de tancament del servidor");
                Invocar(this, () =>
                {
                    Hide();
                    TipusNotificacio.FiServidor.Notificar(Codi, new Notificacio(EstacioAlumne, []));
                });
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

        private void EnRebreIniciSessio(string canal)
        {
            try
            {
                Connexio.TipusTraça.AlRebreIniciSessió.Traça(@"Rebuda ordre d'inici de sessió");

                StripeColor = Color.GreenYellow;

                Worker = new Worker(this);
                Worker.Inici();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreFiSessio(string canal)
        {
            try
            {
                Connexio.TipusTraça.AlRebreFiSessió.Traça(@"Rebuda ordre de fi de sessió");

                StripeColor = Color.DeepSkyBlue;

                Worker.Fi();
                Worker.Dispose();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreRefrescar(string canal)
        {
            Connexio.TipusTraça.AlRebrePitar.Traça(@"Rebuda ordre de refrescar aplicacions en ús");
            TimerAplicacionsEnUs_Tick(null, null);
        }

        private static void Invocar(Control control, Action accio)
        {
            if (control.InvokeRequired)
                control.Invoke(accio);
            else
                accio();
        }

        private void TimerTemps_Tick(object sender, EventArgs e)
        {
            Connexio.CrearClau($@"{Codi}:{Environment.MachineName}", Nom, TimeSpan.FromMilliseconds(timerTemps.Interval));
            TipusNotificacio.KeepAlive.Notificar(Codi, new Notificacio(EstacioAlumne, Helper.AplicacionsEnUs));
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
            var aplicacions = Aplicacions.Where(a => !a.Ignorar).Where(a => !string.IsNullOrEmpty(a.Nom)).Select(a => a.ToString()).ToList();
            if (aplicacions.Count == 0)
                aplicacions.Add(@"No hi ha aplicacions bloquejades");

            var nl = Environment.NewLine;
            var txt = $"Aplicacions bloquedades:{nl}{nl}{string.Join($"{nl}", aplicacions.Select(a => $"    {a}    "))}";

            txt.Mostrar(MostrarIcon.Information);
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Nom) &&
                !string.IsNullOrEmpty(Codi))
            {
                Thread.Sleep(2000);

                if (bIniciar.Text.Equals(@"Connectar"))
                    BIniciar_Click(bIniciar, EventArgs.Empty);

                if (bIniciar.Text.Equals(@"Iniciar"))
                    BIniciar_Click(bIniciar, EventArgs.Empty);

                if (bIniciar.Text.Equals(@"Amagar"))
                    BIniciar_Click(bIniciar, EventArgs.Empty);
            }
        }

        private void TimerAplicacionsEnUs_Tick(object sender, EventArgs e)
        {
            timerAplicacionsEnUs.Stop();
            timerAplicacionsEnUs.Enabled = false;

            var marcaDeTemps = DateTime.Now;
            _ = new WorkerAplicacionsEnUs(() =>
            {
                var marcaDeTempsFinal = DateTime.Now;
                var temps = marcaDeTempsFinal - marcaDeTemps;
                var tempsTotal = marcaDeTempsFinal - _marcaDeTemps;
                $@"Lectura d'aplicacions finalitzada: {Helper.AplicacionsEnUs.Count} (Durada: {temps.ToNaturalString()} | Darrera: {tempsTotal.ToNaturalString()})".Mostrar(MostrarIcon.Information);
                _marcaDeTemps = DateTime.Now;

                timerAplicacionsEnUs.Enabled = true;
                timerAplicacionsEnUs.Start();

                TipusNotificacio.KeepAlive.Notificar(Codi, new Notificacio(EstacioAlumne, Helper.AplicacionsEnUs));
            });
        }
    }
}
