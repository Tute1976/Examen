using BrightIdeasSoftware;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Professor.Formularis
{
    public partial class FrmAplicacions : FormAdv
    {
        public ContenidorAplicacions ContenidorAplicacions { get; set; }
        private OLVColumn _colNom;

        public FrmAplicacions(ContenidorAplicacions contenidorAplicacions)
        {
            InitializeComponent();

            ContenidorAplicacions = contenidorAplicacions;

            OmpleLlista(contenidorAplicacions);
            llista.Roots = contenidorAplicacions.LlegirNodes();

            lTitol.Text = @"Gestió de les aplicacions a controlar";

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint, true);
        }

        private void OmpleLlista(ContenidorAplicacions contenidorAplicacions)
        {
            try
            {
                llista.AllColumns.Clear();
                llista.Columns.Clear();
                llista.ClearObjects();

                _colNom = new OLVColumn("Nom", "Nom") { Width = 150 };
                var colDescripcio = new OLVColumn("Descripció", "Descripcio") { Width = 300};
                var colCalAturar = new OLVColumn("Cal aturar", "CalAturar2") { Width = 100 };
                var colIgnorar = new OLVColumn("Ignorar", "Ignorar2") { Width = 100 };
                var colExecutable = new OLVColumn("Executable", "Executable") { Width = 300 };

                llista.AllColumns.AddRange([_colNom, colDescripcio, colCalAturar, colIgnorar, colExecutable]);
                llista.Columns.AddRange([_colNom, colDescripcio, colCalAturar, colIgnorar, colExecutable]);

                llista.Dock = DockStyle.Fill;
                llista.ShowGroups = false;
                llista.FullRowSelect = true;

                llista.CanExpandGetter = x => ((Node)x).Nodes.Count > 0;
                llista.ChildrenGetter = x => ((Node)x).Nodes;

                var imgs = new ImageList { ImageSize = new Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
                imgs.Images.Add("folder", Properties.Resources.FolderClosed);    // posa-hi la teva icona
                imgs.Images.Add("folder-open", Properties.Resources.FolderOpened); // opcional
                foreach (var icona in contenidorAplicacions.Icones)
                    imgs.Images.Add(icona.Key, icona.Value);
                llista.SmallImageList = imgs;

                _colNom.ImageGetter = rowObj => {
                    var n = (Node)rowObj;
                    if (n.EsAplicacio) 
                        return n.Nom;
                    return llista.IsExpanded(n) ? "folder-open" : "folder";
                };
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void BDesar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BImportar_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    var aplicacions = Examen.Suport.Funcions.Text.Llegir(openFileDialog.FileName);

                    var ret = @"Vols importar la llista d'aplicacions (Sí) o subtituïr-la (No)?".Mostrar(MessageBoxIcon.Question,
                        MessageBoxButtons.YesNoCancel);
                    switch (ret)
                    {
                        case DialogResult.Yes:
                            ContenidorAplicacions.CategoriesAplicacions.AddRange(aplicacions);
                            ContenidorAplicacions.CategoriesAplicacions = [.. ContenidorAplicacions.CategoriesAplicacions.GroupBy(a => a.Nom).Select(g => g.First())];
                            break;

                        case DialogResult.No:
                            ContenidorAplicacions.CategoriesAplicacions = aplicacions;
                            break;
                    }
                }
            }
        }

        private void BExportar_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                ContenidorAplicacions.CategoriesAplicacions.Desar(saveFileDialog.FileName);
            }
        }

        private void Llista_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount != 2) 
                return;        // només doble clic
            if (e.Model is not Node node) 
                return;
            if (node.Nodes.Count == 0) 
                return;        // només si té fills

            // (opcional) només a la columna del nom:
            if (e.Column != _colNom) return;

            if (llista.IsExpanded(node)) 
                llista.Collapse(node);
            else 
                llista.Expand(node);

            e.Handled = true;
        }

        private void MenuLlista_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var item = llista.SelectedItem;

            menuEditar.Enabled = item is { RowObject: Node };
            menuEsborrar.Enabled = item is { RowObject: Node };
        }

        private void MenuAfegirCategoria_Click(object sender, EventArgs e)
        {

        }

        private void MenuAfegirAplicacio_Click(object sender, EventArgs e)
        {
            var item = llista.SelectedItem;
            if (item.RowObject is not Node nodePare) 
                return;

            if (nodePare.EsAplicacio)
                nodePare = nodePare.Pare;

            using var frmEdicioAplicacio = new FrmEdicioAplicacio(new Node(nodePare));
            if (frmEdicioAplicacio.ShowDialog() != DialogResult.OK) 
                return;
            
            nodePare.Nodes.Add(frmEdicioAplicacio.Node);
            llista.BuildList();
            llista.Expand(nodePare);
        }

        private void MenuEditar_Click(object sender, EventArgs e)
        {
            var item = llista.SelectedItem;
            if (item.RowObject is not Node node)
                return;

            if (node.EsAplicacio)
            {
                using var frmEdicioAplicacio = new FrmEdicioAplicacio(node);
                if (frmEdicioAplicacio.ShowDialog() != DialogResult.OK)
                    return;
                item.RowObject = frmEdicioAplicacio.Node;
                llista.BuildList();
            }
            else
            {
                
            }

        }

        private void MenuEsborrar_Click(object sender, EventArgs e)
        {
            var item = llista.SelectedItem;
            if (item.RowObject is not Node node)
                return;

            if (node.EsAplicacio)
            {
                if (@"Vols esborrar l'aplicació seleccionada?".Mostrar(MessageBoxIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var nodePare = node.Pare;
                nodePare.Nodes.Remove(node);
                llista.BuildList();
                llista.Expand(node.Pare);
            }
            else
            {
                if (@"Vols esborrar la categoria seleccionada?".Mostrar(MessageBoxIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var nodes = ((Node[])llista.Roots).ToList();
                nodes.Remove(node);
                llista.Roots = nodes.ToArray();
                llista.BuildList();
            }
        }
    }
}
