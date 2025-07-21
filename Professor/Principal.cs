using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Professor
{
    public partial class Principal : MetroForm
    {
        private List<Aplicacio> Aplicacions { get; set; } = [];
        private Dictionary<string, EstacioAlumne> EstacionsAlumnes { get; set; } = [];

        private static string Fitxer => Path.GetFullPath(Environment.ExpandEnvironmentVariables(Properties.Settings.Default.Aplicacions));

        public Principal()
        {
            InitializeComponent();

            Principal_Resize(null, null);
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            CaptionLabels[0].Location = new Point(Width - 330, 64);
            CaptionLabels[1].Location = new Point(Width - 330, 8);
            CaptionLabels[1].Text = "";
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Fitxer))
                {
                    Aplicacions.Add(new Aplicacio
                    {
                        Nom = "Firefox",
                        Executable = "firefox.exe"
                    });
                    Aplicacions.Add(new Aplicacio
                    {
                        Nom = "Microsoft Edge",
                        Executable = "edge.exe"
                    });
                    DesarAplicacions();
                }
                else
                    Aplicacions = Aplicacions.Llegir(Fitxer);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxAdv.Show("Vols finalitzar el programa?", Application.ProductName, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;

            ServidorTcp.Aturar();
        }

        private void TimerInici_Tick(object sender, EventArgs e)
        {
            try
            {
                var timer = sender as Timer;
                timer?.Stop();
                timer?.Dispose();

                if (Ip.ObtenirCodi(out var codi, out var adreçaPort))
                {
                    CaptionLabels[1].Text = codi;

                    ServidorTcp.Iniciar(adreçaPort, GestorEstat, Callback);
                }
                else
                    @"No s'ha pogut generar el Codi".Mostrar(MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void Callback(TipusMissatge tipusMissatge, EstacioAlumne estacioAlumne, string text)
        {
            try
            {
                Invocar(llistaHistoric, () =>
                {
                    ListViewItem item;

                    switch (tipusMissatge)
                    {
                        case TipusMissatge.Inici:
                            estacioAlumne.DataInici = DateTime.Now;
                            estacioAlumne.DataDarreraConnexio = DateTime.Now;
                            EstacionsAlumnes.Add(estacioAlumne.Id, estacioAlumne);

                            item = llistaHistoric.Items.Add(estacioAlumne.Id, "", 0);
                            item.ForeColor = Color.Green;
                            item.ToolTipText = estacioAlumne.ToString();
                            item.SubItems.Add($"{DateTime.Now:G}");
                            item.SubItems.Add($"Connexió estació {estacioAlumne.Nom}");
                            break;

                        case TipusMissatge.Fi:
                            EstacionsAlumnes.Remove(estacioAlumne.Id);

                            item = llistaHistoric.Items.Add(estacioAlumne.Id, "", 0);
                            item.ForeColor = Color.Blue;
                            item.ToolTipText = estacioAlumne.ToString();
                            item.SubItems.Add($"{DateTime.Now:G}");
                            item.SubItems.Add($"Desconnexió estació {estacioAlumne.Nom}");
                            break;

                        case TipusMissatge.Deteccio:
                            EstacionsAlumnes[estacioAlumne.Id].DataDarreraConnexio = DateTime.Now;

                            item = llistaHistoric.Items.Add(estacioAlumne.Id, "", 0);
                            item.ForeColor = Color.Red;
                            item.ToolTipText = estacioAlumne.ToString();
                            item.SubItems.Add($"{DateTime.Now:G}");
                            var tt = text.Split(':');
                            item.SubItems.Add($"Aplicació '{tt.First()}' en estació {estacioAlumne.Nom} (Aturada: {tt.Last()})");
                            break;

                        case TipusMissatge.Temps:
                            EstacionsAlumnes[estacioAlumne.Id].DataDarreraConnexio = DateTime.Now;
                            break;

                        case TipusMissatge.Prova:
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(tipusMissatge), tipusMissatge, null);
                    }
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private string GestorEstat(TipusMissatge tipusMissatge, EstacioAlumne estacioAlumne)
        {
            try
            {
                switch (tipusMissatge)
                {
                    case TipusMissatge.Inici:
                    case TipusMissatge.Temps:
                        return Aplicacions.Serialitzar();

                    case TipusMissatge.Prova:
                    case TipusMissatge.Deteccio:
                    case TipusMissatge.Fi:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipusMissatge), tipusMissatge, null);
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return "";
        }

        private static void Invocar(Control control, Action accio)
        {
            if (control.InvokeRequired)
                control.Invoke(accio);
            else
                accio();
        }

        private void DesarAplicacions()
        {
            try
            {
                Aplicacions.Desar(Fitxer);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }
    }
}
