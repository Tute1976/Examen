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
using Examen.Suport.Controls;

namespace Examen.Professor
{
    public partial class Principal : MetroForm
    {
        private List<Aplicacio> Aplicacions { get; set; } = [];
        private Dictionary<Guid, EstacioAlumne> EstacionsAlumnes { get; set; } = [];

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
                    Aplicacions.Add(new Aplicacio("Firefox", "firefox.exe", false));
                    Aplicacions.Add(new Aplicacio("Microsoft Edge", "edge.exe", false));
                    DesarAplicacions();
                }
                else
                    Aplicacions = Aplicacions.Llegir(Fitxer);

                DefineixColumnes(int.Parse(cbColumnes.Text));
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

                    string estat;
                    InfoEstacio infoEstacio;
                    switch (tipusMissatge)
                    {
                        case TipusMissatge.Inici:
                            estacioAlumne.DataInici = DateTime.Now;
                            estacioAlumne.DataDarreraConnexio = DateTime.Now;
                            EstacionsAlumnes.Add(estacioAlumne.Id, estacioAlumne);

                            estat = $"Connexió estació {estacioAlumne.Nom}";

                            item = llistaHistoric.Items.Add(estacioAlumne.Id.ToString(), "", 1);
                            item.Tag = estacioAlumne;
                            item.ForeColor = Color.Green;
                            item.ToolTipText = estacioAlumne.ToString();
                            item.SubItems.Add($"{DateTime.Now:G}");
                            item.SubItems.Add(estat);

                            infoEstacio = new InfoEstacio(estacioAlumne)
                            {
                                Estat = estat,
                                Imatge = 1,
                                Tag = estacioAlumne.Id,
                                BackgroundColor = Color.PaleGreen,
                                Dock = DockStyle.Fill
                            };
                            taula.Controls.Add(infoEstacio);

                            break;

                        case TipusMissatge.Fi:
                            EstacionsAlumnes.Remove(estacioAlumne.Id);

                            estat = $"Desconnexió estació {estacioAlumne.Nom}";

                            item = llistaHistoric.Items.Add(estacioAlumne.Id.ToString(), "", 2);
                            item.Tag = estacioAlumne;
                            item.ForeColor = Color.Blue;
                            item.ToolTipText = estacioAlumne.ToString();
                            item.SubItems.Add($"{DateTime.Now:G}");
                            item.SubItems.Add(estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                taula.Controls.Remove(infoEstacio);
                                DefineixColumnes(int.Parse(cbColumnes.Text));
                            }
                            break;

                        case TipusMissatge.Deteccio:
                            EstacionsAlumnes[estacioAlumne.Id].DataDarreraConnexio = DateTime.Now;

                            var tt = text.Split(':');
                            estat = $"Aplicació '{tt.First()}' en estació {estacioAlumne.Nom} (Aturada: {tt.Last()})";

                            item = llistaHistoric.Items.Add(estacioAlumne.Id.ToString(), "", 3);
                            item.Tag = estacioAlumne;
                            item.ForeColor = Color.Red;
                            item.ToolTipText = estacioAlumne.ToString();
                            item.SubItems.Add($"{DateTime.Now:G}");
                            item.SubItems.Add(estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Imatge = 2;
                                infoEstacio.DataConnexio = estacioAlumne.DataDarreraConnexio ?? DateTime.Now;
                                infoEstacio.Estat = estat;
                                infoEstacio.BackgroundColor = Color.LightCoral;
                            }
                            break;

                        case TipusMissatge.Temps:
                            EstacionsAlumnes[estacioAlumne.Id].DataDarreraConnexio = DateTime.Now;

                            estat = $"Actualització estació {estacioAlumne.Nom}";

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Imatge = 0;
                                infoEstacio.DataConnexio = estacioAlumne.DataDarreraConnexio ?? DateTime.Now;
                                infoEstacio.Estat = estat;
                                infoEstacio.BackgroundColor = Color.LightSkyBlue;
                            }
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

        private void LlistaHistoric_DoubleClick(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;

            if (llistaHistoric.SelectedItems is not { Count: > 0 }) 
                return;
            
            var linies = new List<string>();
            string txt;
            foreach (ListViewItem item in llistaHistoric.SelectedItems)
            {
                txt = $"{item.SubItems[1].Text} \t{item.SubItems[2].Text}";
                linies.Add(txt);
            }

            var txts = string.Join(nl, linies);
            txt = $"{txts}{nl}{nl}{nl}Vols copiar el text al portapapers?";
            if (MessageBoxAdv.Show(txt, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) 
                return;

            Clipboard.SetText(txts);
        }

        private void CbColumnes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbColumnes.Text, out var columnes))
                DefineixColumnes(columnes);
            else
            {
                cbColumnes.Text = @"3";
                DefineixColumnes(int.Parse(cbColumnes.Text));
            }
        }

        private void DefineixColumnes(int columnes)
        {
            try
            {
                var controls = taula.Controls.Cast<Control>().ToList();

                taula.ColumnStyles.Clear();
                taula.RowStyles.Clear();

                taula.ColumnCount = columnes;
                for (var columna = 0; columna < columnes; columna++) 
                    taula.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100.0 / columnes)));

                taula.RowCount = 2;
                taula.RowStyles.Add(new RowStyle(SizeType.Absolute, 180));
                taula.RowStyles.Add(new RowStyle(SizeType.Percent, 180));

                var c = 0;
                var r = 0;
                foreach (var control in controls)
                {
                    taula.Controls.Add(control, c, r);

                    c++;
                    if (c < columnes) 
                        continue;
                    c = 0;
                    r++;
                    taula.RowStyles.Insert(taula.RowCount - 1, new RowStyle(SizeType.Absolute, 180));
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void bMostrarLlista_CheckedChanged(object sender, EventArgs e)
        {
            split.Panel2Collapsed = !bMostrarLlista.Checked;
        }

        private void bNetejarLlista_Click(object sender, EventArgs e)
        {
            llistaHistoric.Items.Clear();
        }
    }
}
