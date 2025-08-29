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
        public ContenidorAplicacions ContenidorAplicacions
        {
            get => (ContenidorAplicacions)propietats.SelectedObject;
            private set
            {
                propietats.SelectedObject = value;
                propietats.Refresh();
            }
        }

        private Node[] _nodesArrel;

        public FrmAplicacions(ContenidorAplicacions contenidorAplicacions)
        {
            InitializeComponent();

            ContenidorAplicacions = contenidorAplicacions;
            _nodesArrel = contenidorAplicacions.LlegirNodes();

            OmpleLlista(contenidorAplicacions);

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint, true);
        }

        private void OmpleLlista(ContenidorAplicacions contenidorAplicacions)
        {
            try
            {
                var colNom = new OLVColumn("Nom", "Nom") { Width = 150 };
                var colDescripcio = new OLVColumn("Descripció", "Descripcio") { Width = 300};
                var colCalAturar = new OLVColumn("Cal aturar", "CalAturar2") { Width = 100 };
                var colIgnorar = new OLVColumn("Ignorar", "Ignorar2") { Width = 100 };
                var colExecutable = new OLVColumn("Executable", "Executable") { Width = 300 };

                llista.AllColumns.AddRange([colNom, colDescripcio, colCalAturar, colIgnorar, colExecutable]);
                llista.Columns.AddRange([colNom, colDescripcio, colCalAturar, colIgnorar, colExecutable]);

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

                colNom.ImageGetter = rowObj => {
                    var n = (Node)rowObj;
                    if (n.EsAplicacio) 
                        return n.Nom;
                    return llista.IsExpanded(n) ? "folder-open" : "folder";
                };

                _nodesArrel = contenidorAplicacions.LlegirNodes();
                llista.Roots = _nodesArrel;
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
    }
}
