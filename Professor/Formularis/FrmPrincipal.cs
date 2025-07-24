using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Professor.Formularis
{
    public partial class FrmPrincipal : MetroForm
    {
        private ContenidorAplicacions ContenidorAplicacions { get; set; } = new ();
        private bool _fi;

        private List<ListViewItem> Items { get; set; } = [];

        private static string Fitxer => Path.GetFullPath(Environment.ExpandEnvironmentVariables(Properties.Settings.Default.Aplicacions));

        public FrmPrincipal()
        {
            InitializeComponent();

            Principal_Resize(null, null);
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            CaptionLabels[0].Location = new Point(Width - 430, 64);
            CaptionLabels[1].Location = new Point(Width - 430, 8);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Fitxer))
                {
                    var origen = $@"{Path.GetDirectoryName(Application.ExecutablePath)}\Dades\Aplicacions.json";
                    File.Copy(origen, Fitxer, true);
                }

                ContenidorAplicacions.Aplicacions = ContenidorAplicacions.Aplicacions.Llegir(Fitxer);

                DefineixColumnes(int.Parse(cbColumnes.Text));

                timerCaducades.Interval = Properties.Settings.Default.IntevarvalTemps * 1000;
                timerCaducades.Start();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                    string estat;
                    InfoEstacio infoEstacio;
                    switch (tipusMissatge)
                    {
                        case TipusMissatge.Inici:
                            estacioAlumne.DataInici = DateTime.Now;
                            estacioAlumne.DataDarreraConnexio = DateTime.Now;

                            estat = @"Connexió";

                            AfegirItem(estacioAlumne, 1, Color.Green, estat);

                            infoEstacio = new InfoEstacio(estacioAlumne, Properties.Settings.Default.IntevarvalTemps * 3)
                            {
                                Estat = estat,
                                Data = DateTime.Now,
                                Imatge = 1,
                                Tag = estacioAlumne.Id,
                                BackgroundColor = Color.PaleGreen,
                                Dock = DockStyle.Fill
                            };
                            taula.Controls.Add(infoEstacio);

                            break;

                        case TipusMissatge.Fi:
                            estat = @"Desconnexió";

                            AfegirItem(estacioAlumne, 2, Color.Blue, estat);

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
                            var tt = text.Split(':');
                            estat = $"Aplicació '{tt.First()}' (Aturada: {tt.Last()})";

                            AfegirItem(estacioAlumne, 3, Color.Red, estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Imatge = 2;
                                infoEstacio.Data = DateTime.Now;
                                infoEstacio.Estat = estat;
                                infoEstacio.BackgroundColor = Color.LightCoral;
                                infoEstacio.ForeColor = Color.White;
                                infoEstacio.Pitar = false;
                                infoEstacio.Bloquejar = false;
                                infoEstacio.Aturar = false;
                                infoEstacio.MostrarBotons = true;
                            }
                            break;

                        case TipusMissatge.Temps:
                            estat = @"Actualització periódica, tot bé";

                            AfegirItem(estacioAlumne, 0, Color.Green, estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Imatge = 0;
                                infoEstacio.Data = DateTime.Now;
                                infoEstacio.Estat = estat;
                                infoEstacio.BackgroundColor = infoEstacio.BackgroundColor == Color.Transparent ? 
                                    Color.LightSkyBlue : 
                                    Color.WhiteSmoke;
                                infoEstacio.ForeColor = Color.Black;
                                infoEstacio.Pitar = false;
                                infoEstacio.Bloquejar = false;
                                infoEstacio.Aturar = false;
                                infoEstacio.MostrarBotons = true;
                            }
                            break;

                        case TipusMissatge.FiServidor:
                            estat = @"Desconnexió servidor";

                            AfegirItem(estacioAlumne, 2, Color.Blue, estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                taula.Controls.Remove(infoEstacio);
                                DefineixColumnes(int.Parse(cbColumnes.Text));
                            }
                            break;

                        case TipusMissatge.TempsAmbDeteccio:
                        case TipusMissatge.Prova:
                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Data = DateTime.Now;
                            }
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
                CercaAccions(estacioAlumne, out var pitar, out var bloquejar, out var aturar);

                var ret = tipusMissatge switch
                {
                    TipusMissatge.Inici or
                        TipusMissatge.Temps or
                        TipusMissatge.TempsAmbDeteccio =>
                        $@"{ContenidorAplicacions.Aplicacions.Serialitzar()}^{pitar}^{bloquejar}^{aturar}^{_fi}",
                    TipusMissatge.Prova or
                        TipusMissatge.Deteccio or
                        TipusMissatge.Fi or
                        TipusMissatge.FiServidor =>
                        $@"Ok^{pitar}^{bloquejar}^{aturar}^{_fi}",
                    _ => throw new ArgumentOutOfRangeException(nameof(tipusMissatge), tipusMissatge, null)
                };

                return ret;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return $@":{bool.FalseString}:{bool.FalseString}:{bool.FalseString}";
        }

        private void CercaAccions(EstacioAlumne estacioAlumne, out bool pitar, out bool bloquejar, out bool aturar)
        {
            pitar = false;
            bloquejar = false;
            aturar = false;

            try
            {
                if (!taula.Controls
                        .OfType<InfoEstacio>()
                        .Any(x => x.Tag.Equals(estacioAlumne.Id)))
                    return;

                var infoEstacio = taula.Controls
                    .OfType<InfoEstacio>()
                    .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));

                if (infoEstacio == null)
                    return;

                pitar = infoEstacio.Pitar;
                bloquejar = infoEstacio.Bloquejar;
                aturar = infoEstacio.Aturar;
            }
            catch
            {
                // Ignore exceptions during initialization
            }
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
                ContenidorAplicacions.Aplicacions.Desar(Fitxer);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void LlistaHistoric_DoubleClick(object sender, EventArgs e)
        {
            if (llistaHistoric.SelectedItems is not { Count: > 0 }) 
                return;
            
            var linies = new List<string>();
            string txt;
            foreach (ListViewItem item in llistaHistoric.SelectedItems)
            {
                txt = $"{item.SubItems[1].Text}     {item.SubItems[2].Text}";
                linies.Add(txt);
            }

            var nl = Environment.NewLine;
            var txts = string.Join($"{nl}", linies);
            txt = $"{txts}{nl}{nl}{nl}Vols copiar el text al portapapers?";
            if (txt.Mostrar(MessageBoxIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
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
            Items.Clear();
            llistaHistoric.Items.Clear();
            cbHistoric.Items.Clear();
            cbHistoric.Items.Add("Totes les estacions");
            cbHistoric.Hide();
            lFiltreHistoric.Hide();
        }

        private void bCopiarCodi_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CaptionLabels[1].Text);
        }

        private void timerCaducades_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!taula.Controls
                        .OfType<InfoEstacio>()
                        .Any(x => x.Caducada))
                    return;

                var infoEstacions = taula.Controls
                    .OfType<InfoEstacio>()
                    .Where(x => x.Caducada);

                foreach (var infoEstacio in infoEstacions)
                {
                    const string estat = @"Estació desconectada";

                    AfegirItem(infoEstacio.EstacioAlumne, 3, Color.Coral, estat);

                    infoEstacio.Imatge = 2;
                    infoEstacio.Estat = estat;
                    infoEstacio.BackgroundColor = Color.Coral;
                    infoEstacio.ForeColor = Color.White;
                    infoEstacio.Pitar = false;
                    infoEstacio.Bloquejar = false;
                    infoEstacio.Aturar = false;
                    infoEstacio.MostrarBotons = false;
                }
            }
            catch
            {
                // Ignore exceptions during timer tick
            }
        }

        private void bAplicacions_Click(object sender, EventArgs e)
        {
            try
            {
                using var frmAplicacions = new FrmAplicacions(ContenidorAplicacions);
                if (frmAplicacions.ShowDialog() != DialogResult.OK) 
                    return;
                ContenidorAplicacions = frmAplicacions.ContenidorAplicacions;
                DesarAplicacions();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void cbHistoric_SelectedIndexChanged(object sender, EventArgs e)
        {
            llistaHistoric.Items.Clear();

            var items = cbHistoric.Text.Contains("Totes")
                ? Items
                : Items.Where(i => ((EstacioAlumne)i.Tag).Estacio.Equals(cbHistoric.Text));
            llistaHistoric.Items.AddRange(items.ToArray());
        }

        private void AfegirItem(EstacioAlumne estacioAlumne, int imageIndex, Color foreColor, string estat)
        {
            var item = new ListViewItem("")
            {
                ImageIndex = imageIndex,
                Tag = estacioAlumne,
                ForeColor = foreColor,
                ToolTipText = estacioAlumne.ToString()
            };
            item.SubItems.Add($"{DateTime.Now:G}");
            item.SubItems.Add(estacioAlumne.Estacio);
            item.SubItems.Add(estat);

            var text = cbHistoric.Text;
            if (!cbHistoric.Items.Contains(estacioAlumne.Estacio))
                cbHistoric.Items.Add(estacioAlumne.Estacio);
            cbHistoric.Visible = cbHistoric.Items.Count > 2;
            lFiltreHistoric.Visible = cbHistoric.Visible;
            cbHistoric.Text = text;

            var lastItem = Items.LastOrDefault(i => ((EstacioAlumne)i.Tag).Estacio.Equals(estacioAlumne.Estacio));
            if (lastItem != null &&
                lastItem.SubItems[3].Text.Equals(estat)) 
                return;
            
            Items.Add(item);
            if (cbHistoric.Text.Contains("Totes") ||
                cbHistoric.Text.Equals(estacioAlumne.Estacio))
            {
                llistaHistoric.Items.Add(item);
            }
        }

        private void bSortir_Click(object sender, EventArgs e)
        {
            if ("Vols finalitzar el programa?".Mostrar(MessageBoxIcon.Question, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _fi = true;
                Enabled = false;
                timerTancar.Start();

                var infoEstacions = taula.Controls
                    .OfType<InfoEstacio>()
                    .Where(x => x.Tancar).ToArray();
                foreach (var infoEstacio in infoEstacions)
                    taula.Controls.Remove(infoEstacio);

                Helper.ShowToast("Desconnectant alumnes i tancant ...", 15);
            }
        }

        private void timerTancar_Tick(object sender, EventArgs e)
        {
            try
            {
                if (taula.Controls.Count == 0)
                    Application.Exit();
            }
            catch
            {
                // ignore
            }
        }
    }
}
