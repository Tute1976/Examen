using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Formularis;
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
        private int _columnaOrdenada = -1;
        private SortOrder _ordre = SortOrder.None;

        private List<ListViewItem> Items1 { get; set; } = [];
        private List<ListViewItem> Items2 { get; set; } = [];

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

                ContenidorAplicacions.CategoriesAplicacions = Suport.Funcions.Text.Llegir(Fitxer);

                DefineixColumnes(int.Parse(cbColumnes.Text));

                timerCaducades.Interval = Properties.Settings.Default.IntevarvalTemps * 1000;
                timerCaducades.Start();

                txtVersio.Text = $@"Examen.Professor v.{Application.ProductVersion}";
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
                    @"No s'ha pogut generar el Codi".Mostrar(MostrarIcon.Error, MessageBoxButtons.OK, true);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void Callback(TipusMissatge tipusMissatge, EstacioAlumne estacioAlumne, string text, List<AplicacioEnUs> aplicacionsEnUs)
        {
            try
            {
                if (llistaHistoric ==  null ||
                    llistaHistoric.IsDisposed)
                    return;

                if (ContenidorAplicacions.AplicaIcones(aplicacionsEnUs))
                    ContenidorAplicacions.CategoriesAplicacions.Desar(Fitxer);

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
                            $@"Estació {estacioAlumne.Estacio} connectada.".Mostrar(MostrarIcon.Information);

                            AfegirItem(estacioAlumne, 1, Color.Green, estat);

                            infoEstacio = Properties.Settings.Default.VersioInfo == 1
                                ? new InfoEstacioV1(estacioAlumne, Properties.Settings.Default.IntevarvalTemps * 3, null)
                                : new InfoEstacioV2(estacioAlumne, Properties.Settings.Default.IntevarvalTemps * 3, OnHistoric, OnAplicacionsEnUs);
                            infoEstacio.Estat = estat;
                            infoEstacio.Data = DateTime.Now;
                            infoEstacio.Imatge = Imatge.Nou;
                            infoEstacio.Tag = estacioAlumne.Id;
                            infoEstacio.Color = Colors.Correcte;
                            infoEstacio.Dock = DockStyle.Fill;
                            infoEstacio.AplicacionsEnUs = aplicacionsEnUs;
                            taula.Controls.Add(infoEstacio);

                            break;

                        case TipusMissatge.Fi:
                            estat = @"Estació desconectada manualment";
                            $@"Estació {estacioAlumne.Estacio} desconectada manualment.".Mostrar(MostrarIcon.Information);

                            AfegirItem(estacioAlumne, 2, Color.Blue, estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Imatge = Imatge.Vell;
                                infoEstacio.Estat = estat;
                                infoEstacio.Color = Colors.VermellFosc;
                                infoEstacio.Pitar = false;
                                infoEstacio.Bloquejar = false;
                                infoEstacio.Aturar = false;
                                infoEstacio.MostrarBotons = false;
                                if (aplicacionsEnUs.Count > 0)
                                    infoEstacio.AplicacionsEnUs = aplicacionsEnUs;

                                taula.Controls.SetChildIndex(infoEstacio, 0);

                                //taula.Controls.Remove(infoEstacio);
                                //DefineixColumnes(int.Parse(cbColumnes.Text));
                            }
                            break;

                        case TipusMissatge.Deteccio:
                            var tt = text.Split(':');
                            estat = $"Aplicació '{tt.First()}' (Aturada: {tt.Last()})";
                            $@"{estat} en l'estació {estacioAlumne.Estacio}.".Mostrar(MostrarIcon.Warning);

                            AfegirItem(estacioAlumne, 3, Color.Red, estat);

                            infoEstacio = taula.Controls
                                .OfType<InfoEstacio>()
                                .FirstOrDefault(x => x.Tag.Equals(estacioAlumne.Id));
                            if (infoEstacio != null)
                            {
                                infoEstacio.Imatge = Imatge.Atencio;
                                infoEstacio.Data = DateTime.Now;
                                infoEstacio.Estat = estat;
                                infoEstacio.Color = Colors.Vermell;
                                infoEstacio.Pitar = false;
                                infoEstacio.Bloquejar = false;
                                infoEstacio.Aturar = false;
                                infoEstacio.MostrarBotons = true;
                                if (aplicacionsEnUs.Count > 0) 
                                    infoEstacio.AplicacionsEnUs = aplicacionsEnUs;

                                taula.Controls.SetChildIndex(infoEstacio, 0);
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
                                if (infoEstacio.Color != Colors.Defecte && infoEstacio.Color != Colors.Correcte)
                                    $@"{estat} en l'estació {estacioAlumne.Estacio}.".Mostrar(MostrarIcon.Information);

                                infoEstacio.Imatge = 0;
                                infoEstacio.Data = DateTime.Now;
                                infoEstacio.Estat = estat;
                                infoEstacio.Color = infoEstacio.Color != Colors.Defecte && infoEstacio.Color != Colors.Correcte ?
                                    Colors.Correcte : 
                                    Colors.Defecte;
                                infoEstacio.Pitar = false;
                                infoEstacio.Bloquejar = false;
                                infoEstacio.Aturar = false;
                                infoEstacio.MostrarBotons = true;
                                if (aplicacionsEnUs.Count > 0)
                                    infoEstacio.AplicacionsEnUs = aplicacionsEnUs;
                            }
                            break;

                        case TipusMissatge.FiServidor:
                            estat = @"Desconnexió servidor";
                            estat.Mostrar(MostrarIcon.Information);

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
                                if (aplicacionsEnUs.Count > 0)
                                    infoEstacio.AplicacionsEnUs = aplicacionsEnUs;
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

        private void OnHistoric(string estacio)
        {
            try
            {
                var items = Items2.Where(i => ((EstacioAlumne)i.Tag).Estacio.Equals(estacio));

                using var frmHistoric = new FrmHistoric(items);
                frmHistoric.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void OnAplicacionsEnUs(string estacio, ContenidorAplicacionsEnUs contenidorAplicacionsEnUs)
        {
            try
            {
                var frmAplicacionsEnUs = new FrmAplicacionsEnUs(estacio, contenidorAplicacionsEnUs, ContenidorAplicacions, Fitxer);
                frmAplicacionsEnUs.ShowDialog();
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

                var aplicacions = ContenidorAplicacions.TotesSenseIgnorades;
                if (bStartStop.Tag is string s &&
                    bool.TryParse(s, out var start) &&
                    !start)
                    aplicacions = [new Aplicacio()];

                var ret = tipusMissatge switch
                {
                    TipusMissatge.Inici or
                        TipusMissatge.Temps or
                        TipusMissatge.TempsAmbDeteccio =>
                        $@"{aplicacions.Serialitzar()}^{pitar}^{bloquejar}^{aturar}^{_fi}",
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
            if (txt.Mostrar(MostrarIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
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

        private void BMostrarLlista_CheckedChanged(object sender, EventArgs e)
        {
            split.Panel2Collapsed = !bMostrarLlista.Checked;
        }

        private void BNetejarLlista_Click(object sender, EventArgs e)
        {
            Items1.Clear();

            llistaHistoric.Items.Clear();
            cbHistoric.Items.Clear();
            cbHistoric.Items.Add("Totes les estacions");
            cbHistoric.Hide();
            lFiltreHistoric.Hide();
        }

        private void BCopiarCodi_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CaptionLabels[1].Text);
        }

        private void TimerCaducades_Tick(object sender, EventArgs e)
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

                    if (!infoEstacio.Estat.Equals(estat))
                        $@"Estació {infoEstacio.EstacioAlumne.Estacio} desconectada.".Mostrar(MostrarIcon.Warning);

                    AfegirItem(infoEstacio.EstacioAlumne, 3, Color.Coral, estat);

                    infoEstacio.Imatge = Imatge.Atencio;
                    infoEstacio.Estat = estat;
                    infoEstacio.Color = Colors.Vermell;
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

        private void BAplicacions_Click(object sender, EventArgs e)
        {
            try
            {
                using var frmAplicacions = new FrmAplicacions(ContenidorAplicacions);
                if (frmAplicacions.ShowDialog() != DialogResult.OK) 
                    return;
                ContenidorAplicacions = frmAplicacions.ContenidorAplicacions;
                ContenidorAplicacions.CategoriesAplicacions.Desar(Fitxer);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void CbHistoric_SelectedIndexChanged(object sender, EventArgs e)
        {
            llistaHistoric.Items.Clear();

            var items = cbHistoric.Text.Contains("Totes")
                ? Items1
                : Items1.Where(i => ((EstacioAlumne)i.Tag).Estacio.Equals(cbHistoric.Text));
            llistaHistoric.Items.AddRange([.. items]);
        }

        private void AfegirItem(EstacioAlumne estacioAlumne, int imageIndex, Color foreColor, string estat)
        {
            var text = cbHistoric.Text;
            if (!cbHistoric.Items.Contains(estacioAlumne.Estacio))
                cbHistoric.Items.Add(estacioAlumne.Estacio);
            cbHistoric.Visible = cbHistoric.Items.Count > 2;
            lFiltreHistoric.Visible = cbHistoric.Visible;
            cbHistoric.Text = text;

            var lastItem = Items1.LastOrDefault(i => ((EstacioAlumne)i.Tag).Estacio.Equals(estacioAlumne.Estacio));
            if (lastItem != null &&
                lastItem.SubItems[3].Text.Equals(estat)) 
                return;

            var item = CreaItem(estacioAlumne, imageIndex, foreColor, estat);
            Items1.Add(item);

            if (cbHistoric.Text.Contains("Totes") ||
                cbHistoric.Text.Equals(estacioAlumne.Estacio))
            {
                llistaHistoric.Items.Add(item);
            }

            Items2.Add(CreaItem(estacioAlumne, imageIndex, foreColor, estat));
        }

        private ListViewItem CreaItem(EstacioAlumne estacioAlumne, int imageIndex, Color foreColor, string estat)
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

            return item;
        }

        private void BSortir_Click(object sender, EventArgs e)
        {
            if ("Vols finalitzar el programa?".Mostrar(MostrarIcon.Question, MessageBoxButtons.YesNo, true) == DialogResult.Yes)
            {
                _fi = true;
                Enabled = false;
                timerTancar.Start();

                "Desconnectant alumnes i tancant ...".ShowToast(15, ToastType.Info);
            }
        }

        private void TimerTancar_Tick(object sender, EventArgs e)
        {
            try
            {
                var infoEstacions = taula.Controls
                    .OfType<InfoEstacio>()
                    .Where(x => x.Tancar).ToArray();
                foreach (var infoEstacio in infoEstacions)
                    taula.Controls.Remove(infoEstacio);

                if (taula.Controls.Count == 0)
                    Application.Exit();
            }
            catch
            {
                // ignore
            }
        }

        private void BStartStop_Click(object sender, EventArgs e)
        {
            bStartStop.Text.Mostrar(MostrarIcon.Information);

            if (bStartStop.Tag is string s &&
                bool.TryParse(s, out var start) &&
                start)
            {
                bStartStop.Image = Properties.Resources.Start_32x32;
                bStartStop.Text = @"Iniciar sessió";
                bStartStop.ToolTipText = bStartStop.Text;
                bStartStop.Tag = false.ToString();
            }
            else
            {
                bStartStop.Image = Properties.Resources.Stop_32x32;
                bStartStop.Text = @"Finalitzar sessió";
                bStartStop.ToolTipText = bStartStop.Text;
                bStartStop.Tag = true.ToString();
            }
        }

        private void Taula_Controls(object sender, ControlEventArgs e)
        {
            CaptionLabels[0].Text = taula.Controls.Count == 0 ? 
                "Codi" : 
                $"Codi | {taula.Controls.Count} alumne{(taula.Controls.Count == 1 ? "" : "s")}";
        }

        private void LlistaHistoric_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var llista = (ListView)sender;

            if (e.Column == _columnaOrdenada)
            {
                _ordre = _ordre == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                _columnaOrdenada = e.Column;
                _ordre = SortOrder.Ascending;
            }

            llista.ListViewItemSorter = new ListViewColumnSorter(_columnaOrdenada, _ordre);
            llista.Sort();
        }
    }
}
