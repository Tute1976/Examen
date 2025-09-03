using BrightIdeasSoftware;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Professor.Formularis
{
    public partial class FrmAplicacions : FormAdv
    {
        public ContenidorAplicacions ContenidorAplicacions { get; set; }
        private OLVColumn _colNom;
        private readonly Node[] _nodes;

        public FrmAplicacions(ContenidorAplicacions contenidorAplicacions)
        {
            ContenidorAplicacions = contenidorAplicacions;
            
            InitializeComponent();
            InicialitzaLlista();

            _nodes = contenidorAplicacions.LlegirNodes();
            llista.Roots = _nodes;
            OmpleIcones();

            lTitol.Text = @"Gestió de les aplicacions a controlar";

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint, true);
        }

        private void InicialitzaLlista()
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

                _colNom.ImageGetter = rowObj => {
                    var n = (Node)rowObj;

                    return n.EsAplicacio ?
                        imatges.Images.ContainsKey(n.Nom) ? 
                            n.Nom : 
                            "application" :
                        llista.IsExpanded(n) ? 
                            "folder-open" : 
                            "folder";
                };
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void OmpleIcones()
        {
            imatges.Images.Clear();
            imatges.Images.Add("folder", Properties.Resources.FolderClosed);    // posa-hi la teva icona
            imatges.Images.Add("folder-open", Properties.Resources.FolderOpened); // opcional
            imatges.Images.Add("application", Properties.Resources.Application);    // posa-hi la teva icona
            foreach (var nodeCategoria in _nodes)
                foreach (var node in nodeCategoria.Nodes)
                    imatges.Images.Add(node.Nom, node.Icona);
        }

        private void BDesar_Click(object sender, EventArgs e)
        {
            ContenidorAplicacions.CategoriesAplicacions = OmpleCategories(_nodes);
            DialogResult = DialogResult.OK;
        }

        private List<CategoriaAplicacions> OmpleCategories(Node[] nodes)
        {
            var ret = new List<CategoriaAplicacions>();

            foreach (var nodeCategoria in nodes)
            {
                nodeCategoria.Desar();

                var categoriaAplicacions = nodeCategoria.CategoriaAplicacions;
                categoriaAplicacions.Aplicacions.Clear();

                foreach (var node in nodeCategoria.Nodes)
                {
                    if (!categoriaAplicacions.Aplicacions.Any(a => a.Nom.Equals(node.Nom)))
                        categoriaAplicacions.Aplicacions.Add(node.Aplicacio);
                }

                ret.Add(categoriaAplicacions);
            }

            return ret;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BImportar_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    var aplicacions = Examen.Suport.Funcions.Text.Llegir(openFileDialog.FileName);

                    var ret = @"Vols importar la llista d'aplicacions (Sí) o subtituïr-la (No)?".Mostrar(MostrarIcon.Question,
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

            if (!node.EsAplicacio)
            {
                if (e.Column != _colNom) 
                    return;

                if (llista.IsExpanded(node))
                    llista.Collapse(node);
                else
                    llista.Expand(node);

                e.Handled = true;
            }
            else
            {
                MenuEditar_Click(sender, null);
            }
        }

        private void MenuLlista_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var item = llista.SelectedItem;

            menuAfegirAplicacio.Enabled = item is { RowObject: Node { EsAplicacio: false } };
            menuEditar.Enabled = item is { RowObject: Node };
            menuEsborrar.Enabled = item is { RowObject: Node };
        }

        private void MenuAfegirCategoria_Click(object sender, EventArgs e)
        {
            using var frmEdicioCategoria = new FrmEdicioCategoria(new Node());
            if (frmEdicioCategoria.ShowDialog() != DialogResult.OK)
                return;

            llista.AddObject(frmEdicioCategoria.Node);
            llista.BuildList();

            CalDesar();
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

            OmpleIcones();
            llista.RefreshObject(nodePare);
            llista.Collapse(nodePare);
            llista.Expand(nodePare);
            llista.SelectedObject = nodePare;

            CalDesar();
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
                node = frmEdicioAplicacio.Node;
                item.RowObject = node;

                OmpleIcones();
                llista.BuildList();
            }
            else
            {
                using var frmEdicioCategoria = new FrmEdicioCategoria(node);
                if (frmEdicioCategoria.ShowDialog() != DialogResult.OK)
                    return;
                item.RowObject = frmEdicioCategoria.Node;
                llista.BuildList();
            }

            CalDesar();
        }

        private void MenuEsborrar_Click(object sender, EventArgs e)
        {
            var item = llista.SelectedItem;
            if (item.RowObject is not Node node)
                return;

            if (node.EsAplicacio)
            {
                if (@"Vols esborrar l'aplicació seleccionada?".Mostrar(MostrarIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var nodePare = node.Pare;
                nodePare.Nodes.Remove(node);

                llista.RefreshObject(nodePare);
                llista.Collapse(nodePare);
                llista.Expand(nodePare);
                llista.SelectedObject = nodePare;

                CalDesar();
            }
            else
            {
                if (@"Vols esborrar la categoria seleccionada?".Mostrar(MostrarIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                llista.RemoveObject(node);
                llista.BuildList();

                CalDesar();
            }
        }

        private void CalDesar()
        {
            bDesar.Enabled = true;
            toolStripSeparator1.Visible = false;
            bImportar.Visible = false;
            bExportar.Visible = false;
        }
    }
}
