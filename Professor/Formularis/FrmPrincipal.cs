using Examen.Intermediari.Redis;
using Examen.Professor.Controls;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Professor.Formularis
{
    public partial class FrmPrincipal : MetroForm
    {
        private ContenidorAplicacions ContenidorAplicacions { get; set; } = new ();

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
            CaptionLabels[0].Location = new Point(Width - 530, 64);
            CaptionLabels[1].Location = new Point(Width - 530, 8);
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

                var json = Connexio.LlegirClau("CategoriesAplicacions", Connexio.TipusRedis.Persistent);
                if (!string.IsNullOrEmpty(json))
                    ContenidorAplicacions.CategoriesAplicacions = json.Deserialitzar<List<CategoriaAplicacions>>() ?? [] ;
                else
                {
                    ContenidorAplicacions.CategoriesAplicacions = Suport.Funcions.Text.Llegir(Fitxer, out json);
                    Connexio.CrearClau("CategoriesAplicacions", json, TimeSpan.MaxValue, Connexio.TipusRedis.Persistent);
                }

                DefineixColumnes(int.Parse(cbColumnes.Text));

                timerCaducades.Interval = Properties.Settings.Default.IntervalTemps * 1000;
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
            Intermediari.Redis.Professor.EsborrarClauSessio(CaptionLabels[1].Text, Connexio.TipusRedis.Volatil);

            Connexio.Desconnectar();
        }

        private void TimerInici_Tick(object sender, EventArgs e)
        {
            try
            {
                var timer = sender as Timer;
                timer?.Stop();
                timer?.Dispose();

                if (Helper.ObtenirCodi(out var codi))
                {
                    CaptionLabels[1].Text = codi;

                    Subscripcio(codi);
                }
                else
                    @"No s'ha pogut generar el Codi".Mostrar(MostrarIcon.Error, MessageBoxButtons.OK, true);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private string _codiAntic;
        private void Subscripcio(string codi)
        {
            if (!string.IsNullOrEmpty(_codiAntic))
            {
                Intermediari.Redis.Professor.EsborrarClauSessio(_codiAntic, Connexio.TipusRedis.Volatil);
            }

            Intermediari.Redis.Professor.CreaClauSessio(codi, TimeSpan.FromHours(Properties.Settings.Default.Duracio), Connexio.TipusRedis.Volatil);

            Intermediari.Redis.Professor.SubscriuresInici(codi, EnRebreInici, Connexio.TipusRedis.Volatil);
            Intermediari.Redis.Professor.SubscriuresFi(codi, EnRebreFi, Connexio.TipusRedis.Volatil);
            Intermediari.Redis.Professor.SubscriuresFiServidor(codi, EnRebreFiServidor, Connexio.TipusRedis.Volatil);

            Intermediari.Redis.Professor.SubscriuresKeepAlive(codi, EnRebreKeepAlive, Connexio.TipusRedis.Volatil);
            Intermediari.Redis.Professor.SubscriuresDeteccio(codi, EnRebreDeteccio, Connexio.TipusRedis.Volatil);
            Intermediari.Redis.Professor.SubscriuresCaptura(codi, EnRebreCaptura, Connexio.TipusRedis.Volatil);

            Intermediari.Redis.Professor.SubscriuresKeepAliveAmdDeteccio(codi, EnRebreKeepAliveAmdDeteccio, Connexio.TipusRedis.Volatil);
            Intermediari.Redis.Professor.SubscriuresLlistaAplicacionsEnUs(codi, EnRebreAplicacionsEnUs, Connexio.TipusRedis.Volatil);

            _codiAntic = codi;
        }

        private void EnRebreInici(string usuari, string estacio, string nom, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreInici.Traça(@"Rebut inici de l'estació");

                Helper.Invocar(llistaHistoric, () =>
                {
                    notificacio.EstacioAlumne.DataInici = DateTime.Now;
                    notificacio.EstacioAlumne.DataDarreraConnexio = DateTime.Now;

                    var estat = @"Connexió";
                    $@"Estació {notificacio.EstacioAlumne.Estacio} connectada.".Mostrar(MostrarIcon.Information);

                    AfegirItem(notificacio.EstacioAlumne, 1, Color.Green, estat);

                    InfoEstacio infoEstacio = Properties.Settings.Default.VersioInfo == 1
                        ? new InfoEstacioV1(notificacio.EstacioAlumne, Properties.Settings.Default.IntervalTemps * 3, null)
                        : new InfoEstacioV3(CaptionLabels[1].Text, notificacio.EstacioAlumne, Properties.Settings.Default.IntervalTemps * 3, OnHistoric, OnAplicacionsEnUs);
                    infoEstacio.Estat = estat;
                    infoEstacio.Data = DateTime.Now;
                    infoEstacio.Imatge = Imatge.Nou;
                    infoEstacio.Tag = notificacio.EstacioAlumne.Id;
                    infoEstacio.Color = Colors.Correcte;
                    infoEstacio.Dock = DockStyle.Fill;
                    if (notificacio.AplicacioEnUs.Count > 0)
                        infoEstacio.AplicacionsEnUs = notificacio.AplicacioEnUs;

                    taula.Controls.Add(infoEstacio);
                });

                var aplicacions = ContenidorAplicacions.TotesSenseIgnorades;
                Intermediari.Redis.Professor.EnviarAplicacions(CaptionLabels[1].Text, notificacio.EstacioAlumne, aplicacions, Connexio.TipusRedis.Volatil);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreFi(string usuari, string estacio, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreFi.Traça(@"Rebut fi de l'estació");

                Helper.Invocar(llistaHistoric, () =>
                {
                    var estat = @"Estació desconectada manualment";
                    $@"Estació {notificacio.EstacioAlumne.Estacio} desconectada manualment.".Mostrar(MostrarIcon.Information);

                    AfegirItem(notificacio.EstacioAlumne, 2, Color.Blue, estat);

                    var infoEstacio = taula.Controls
                        .OfType<InfoEstacio>()
                        .FirstOrDefault(x => x.Tag.Equals(notificacio.EstacioAlumne.Id));
                    if (infoEstacio == null) 
                        return;
                    
                    infoEstacio.Imatge = Imatge.Vell;
                    infoEstacio.Estat = estat;
                    infoEstacio.Color = Colors.VermellFosc;
                    infoEstacio.Pitar = false;
                    infoEstacio.Bloquejar = false;
                    infoEstacio.Aturar = false;
                    infoEstacio.MostrarBotons = false;
                    if (notificacio.AplicacioEnUs.Count > 0)
                        infoEstacio.AplicacionsEnUs = notificacio.AplicacioEnUs;

                    taula.Controls.SetChildIndex(infoEstacio, 0);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreFiServidor(string usuari, string estacio, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreFiServidor.Traça(@"Rebuda informació de fi del servidor");

                Helper.Invocar(llistaHistoric, () =>
                {
                    var estat = @"Desconnexió servidor";
                    estat.Mostrar(MostrarIcon.Information);

                    AfegirItem(notificacio.EstacioAlumne, 2, Color.Blue, estat);

                    var infoEstacio = taula.Controls
                        .OfType<InfoEstacio>()
                        .FirstOrDefault(x => x.Tag.Equals(notificacio.EstacioAlumne.Id));
                    if (infoEstacio == null)
                        return;
                    
                    taula.Controls.Remove(infoEstacio);
                    DefineixColumnes(int.Parse(cbColumnes.Text));
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreDeteccio(string usuari, string estacio, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreDetecció.Traça($@"Rebut deteccció de l'aplicació: {notificacio.Aplicacio.Nom}");

                Helper.Invocar(llistaHistoric, () =>
                {
                    var estat = $"Aplicació '{notificacio.Aplicacio.Nom}' (Aturada: {notificacio.Aturada.SiNo()})";
                    $@"{estat} en l'estació {estacio}.".Mostrar(MostrarIcon.Warning);

                    AfegirItem(notificacio.EstacioAlumne, 3, Color.Red, estat);

                    var infoEstacio = taula.Controls
                        .OfType<InfoEstacio>()
                        .FirstOrDefault(x => x.Tag.Equals(notificacio.EstacioAlumne.Id));
                    if (infoEstacio == null) 
                        return;
                    
                    infoEstacio.Imatge = Imatge.Atencio;
                    infoEstacio.Data = DateTime.Now;
                    infoEstacio.Estat = estat;
                    infoEstacio.Color = Colors.Vermell;
                    infoEstacio.Pitar = false;
                    infoEstacio.Bloquejar = false;
                    infoEstacio.Aturar = false;
                    infoEstacio.MostrarBotons = true;

                    taula.Controls.SetChildIndex(infoEstacio, 0);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreCaptura(string usuari, string estacio, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreFiServidor.Traça(@"Rebuda captura de pantalla");

                var fitxer = Path.Combine(Helper.DirectoriCaptures, $"Captura_{usuari}_{estacio}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                notificacio.Imatge.Save(fitxer, ImageFormat.Png);

                Helper.Executar(fitxer);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreKeepAlive(string usuari, string estacio, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreKeepAlive.Traça($@"Rebut KeepAlive de l'estació: {notificacio.EstacioAlumne.Nom}");

                Helper.Invocar(llistaHistoric, () =>
                {
                    var estat = @"Actualització periódica, tot bé";

                    AfegirItem(notificacio.EstacioAlumne, 0, Color.Green, estat);

                    var infoEstacio = taula.Controls
                        .OfType<InfoEstacio>()
                        .FirstOrDefault(x => x.Tag.Equals(notificacio.EstacioAlumne.Id));
                    if (infoEstacio != null)
                    {
                        if (infoEstacio.Color != Colors.Defecte && infoEstacio.Color != Colors.Correcte)
                            $@"{estat} en l'estació {notificacio.EstacioAlumne.Estacio}.".Mostrar(MostrarIcon.Information);

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
                        if (notificacio.AplicacioEnUs.Count > 0)
                            infoEstacio.AplicacionsEnUs = notificacio.AplicacioEnUs;
                    }
                });

                var aplicacions = ContenidorAplicacions.TotesSenseIgnorades;
                Intermediari.Redis.Professor.EnviarAplicacions(CaptionLabels[1].Text, notificacio.EstacioAlumne, aplicacions, Connexio.TipusRedis.Volatil);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreKeepAliveAmdDeteccio(string usuari, string estacio, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreKeepAlive.Traça($@"Rebut KeepAlive amb detecció de l'aplicació: {notificacio.Aplicacio.Nom}");

                Helper.Invocar(llistaHistoric, () =>
                {
                    var infoEstacio = taula.Controls
                        .OfType<InfoEstacio>()
                        .FirstOrDefault(x => x.Tag.Equals(notificacio.EstacioAlumne.Id));
                    infoEstacio?.Data = DateTime.Now;
                });

            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void EnRebreAplicacionsEnUs(string usuari, string estacio, string nom, Notificacio notificacio)
        {
            try
            {
                Connexio.TipusTraça.AlRebreAplicacionsEnUs.Traça($@"Rebut llista d'aplicacions en ús: {notificacio.AplicacioEnUs.Count}");

                var infoEstacio = taula.Controls
                    .OfType<InfoEstacio>()
                    .FirstOrDefault(x => x.Tag.Equals(notificacio.EstacioAlumne.Id));

                if (notificacio.AplicacioEnUs.Count > 0)
                    infoEstacio?.AplicacionsEnUs = notificacio.AplicacioEnUs;
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

        private void OnAplicacionsEnUs(string estacio, ContenidorAplicacionsEnUs contenidorAplicacionsEnUs, EstacioAlumne estacioAlumne)
        {
            try
            {
                var frmAplicacionsEnUs = new FrmAplicacionsEnUs(estacio, contenidorAplicacionsEnUs, ContenidorAplicacions, Fitxer, estacioAlumne, OnRefrescar);
                frmAplicacionsEnUs.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void OnRefrescar(EstacioAlumne estacioAlumne)
        {
            TipusNotificacio.Refrescar.EnviarNotificacio(CaptionLabels[1].Text, estacioAlumne, Connexio.TipusRedis.Volatil);
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
                ContenidorAplicacions.CategoriesAplicacions.Desar(Fitxer, out var json);
                Connexio.CrearClau("CategoriesAplicacions", json, TimeSpan.MaxValue, Connexio.TipusRedis.Persistent);
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
            if ("Vols finalitzar el programa?".Mostrar(MostrarIcon.Question, MessageBoxButtons.YesNo, true) != DialogResult.Yes) 
                return;

            Enabled = false;

            var infoEstacions = taula.Controls
                .OfType<InfoEstacio>().ToArray();
            foreach (var infoEstacio in infoEstacions)
            {
                TipusNotificacio.Tancament.EnviarNotificacio(CaptionLabels[1].Text, infoEstacio.EstacioAlumne, Connexio.TipusRedis.Volatil);
            }

            timerTancar.Start();

            "Desconnectant alumnes i tancant ...".ShowToast(15, ToastType.Info);
        }

        private void TimerTancar_Tick(object sender, EventArgs e)
        {
            try
            {
                var infoEstacions = taula.Controls
                    .OfType<InfoEstacio>()
                    .Where(x => x.Tancar).ToArray();
                foreach (var infoEstacio in infoEstacions)
                {
                    taula.Controls.Remove(infoEstacio);
                }

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

                bCanviarCodi.Visible = true;

                TipusNotificacio.FiSessió.EnviarNotificacio(CaptionLabels[1].Text, Connexio.TipusRedis.Volatil);
            }
            else
            {
                bStartStop.Image = Properties.Resources.Stop_32x32;
                bStartStop.Text = @"Finalitzar sessió";
                bStartStop.ToolTipText = bStartStop.Text;
                bStartStop.Tag = true.ToString();

                bCanviarCodi.Visible = false;

                TipusNotificacio.IniciSessió.EnviarNotificacio(CaptionLabels[1].Text, Connexio.TipusRedis.Volatil);
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

        private void BCanviarCodi_Click(object sender, EventArgs e)
        {
            try
            {
                using var frmEdicioCodi = new FrmEdicioCodi(CaptionLabels[1].Text);
                if (frmEdicioCodi.ShowDialog() != DialogResult.OK)
                    return;

                CaptionLabels[1].Text = frmEdicioCodi.NouCodi;
                Subscripcio(CaptionLabels[1].Text);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }
    }
}
