using System;
using Examen.Suport.Classes;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Suport.Formularis
{
    public partial class FrmAplicacionsEnUs : FormAdv
    {
        private readonly ContenidorAplicacions _contenidorAplicacions;
        private readonly ContenidorAplicacionsEnUs _contenidorAplicacionsEnUs;
        private readonly string _fitxer;

        private int _columnaOrdenada = -1;
        private SortOrder _ordre = SortOrder.None;

        public FrmAplicacionsEnUs(string estacio, ContenidorAplicacionsEnUs contenidorAplicacionsEnUs, ContenidorAplicacions contenidorAplicacions, string fitxer)
        {
            _contenidorAplicacions = contenidorAplicacions;
            _contenidorAplicacionsEnUs = contenidorAplicacionsEnUs;
            _fitxer = fitxer;

            InitializeComponent();

            lTitol.Text = $@"Aplicacions en ús a {estacio}";

            llistaAplicacions.Items.Clear();
            imatges.Images.Clear();

            var aplicacionsEnUs = new Dictionary<string, AplicacioEnUs>();
            foreach (var aplicacioEnUs in _contenidorAplicacionsEnUs.AplicacionsEnUs.OrderBy(a => a.Executable))
            {
                if (!aplicacionsEnUs.ContainsKey(aplicacioEnUs.Executable))
                    aplicacionsEnUs.Add(aplicacioEnUs.Executable, aplicacioEnUs);

                if (!imatges.Images.ContainsKey(aplicacioEnUs.Executable))
                    imatges.Images.Add(aplicacioEnUs.Executable, aplicacioEnUs.Icona);
            }

            var aplicacions = contenidorAplicacions.Totes.ToList();
            foreach (var aplicacioEnUs in aplicacionsEnUs.Values)
            {
                var item = llistaAplicacions.Items.Add(aplicacioEnUs.Executable, "", aplicacioEnUs.Executable);
                item.SubItems.Add(aplicacioEnUs.Nom);
                item.SubItems.Add(aplicacioEnUs.Executable);
                item.SubItems.Add(aplicacioEnUs.Descripcio);
                item.Tag = aplicacioEnUs;

                var aplicacio = aplicacions.FirstOrDefault(a => a.ExecutableCurt.Equals(aplicacioEnUs.ExecutableCurt, StringComparison.InvariantCultureIgnoreCase));
                if (aplicacio == null) 
                    continue;

                aplicacioEnUs.Aplicacio = aplicacio;

                if (aplicacio.Ignorar)
                    item.BackColor = System.Drawing.Color.LightGreen;
                else
                {
                    item.BackColor = aplicacio.CalAturar ?
                        System.Drawing.Color.LightCoral :
                        System.Drawing.Color.LightBlue;
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BExportar_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var aplicacions = _contenidorAplicacionsEnUs.AplicacionsEnUs.Select(aplicacioEnUs => new Aplicacio(aplicacioEnUs)).ToList();

                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                aplicacions.Desar(saveFileDialog.FileName);
            }
        }

        private void LlistaAplicacions_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void MenuLlista_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (llistaAplicacions.SelectedItems.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            menuAturar.DropDownItems.Clear();
            menuAturar.Image = Properties.Resources.Aturar_16x16;
            menuAturar.Click += MenuAturar_Click;

            var item = llistaAplicacions.SelectedItems[0];
            switch (item.BackColor.ToString())
            {
                case "Color [LightGreen]": // Ignorar
                    menuAturar.Mostrar();
                    menuPermetre.Mostrar();
                    menuIgnorar.Amagar();

                    separacioEsborrar.Mostrar();
                    menuEsborrar.Mostrar();
                    break;

                case "Color [LightCoral]": // CalAturar
                    menuAturar.Amagar();
                    menuPermetre.Mostrar();
                    menuIgnorar.Mostrar();

                    separacioEsborrar.Mostrar();
                    menuEsborrar.Mostrar();
                    break;

                case "Color [LightBlue]": // No cal aturar
                    menuAturar.Mostrar();
                    menuPermetre.Amagar();
                    menuIgnorar.Mostrar();

                    separacioEsborrar.Mostrar();
                    menuEsborrar.Mostrar();
                    break;

                default: // Normal
                    menuAturar.Mostrar();
                    menuPermetre.Amagar();
                    menuIgnorar.Amagar();

                    separacioEsborrar.Amagar();
                    menuEsborrar.Amagar();

                    menuAturar.Image = null;
                    menuAturar.Click -= MenuAturar_Click;
                    foreach (var categoria in _contenidorAplicacions.Categories)
                        menuAturar.DropDownItems.Add(categoria, Properties.Resources.Aturar_16x16, MenuAturar_Categoria_Click);
                    break;
            }
        }

        private void MenuAturar_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Image == null)
                return;

            var item = llistaAplicacions.SelectedItems[0];
            if (item?.Tag is not AplicacioEnUs aplicacioEnUs)
                return;
            if (aplicacioEnUs.Aplicacio is not { } aplicacio)
                return;

            var categoriaAplicacions = _contenidorAplicacions.CategoriesAplicacions.FirstOrDefault(c => c.Nom.Equals(aplicacio.Categoria));
            var app = categoriaAplicacions?.Aplicacions.FirstOrDefault(a => a.Nom.Equals(aplicacio.Nom));
            if (app == null)
                return;

            app.CalAturar = true;
            app.Ignorar = false;
            aplicacioEnUs.Aplicacio = app;
            item.BackColor = System.Drawing.Color.LightCoral;
            
            menuDesar.Enabled = true;
        }

        private void MenuAturar_Categoria_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var item = llistaAplicacions.SelectedItems[0];
            if (item?.Tag is not AplicacioEnUs aplicacioEnUs)
                return;

            var categoria = menuItem.Text;
            var categoriaAplicacions = _contenidorAplicacions.CategoriesAplicacions.FirstOrDefault(c => c.Nom.Equals(categoria));
            if (categoriaAplicacions == null)
                return;

            var aplicacio = new Aplicacio(aplicacioEnUs)
            {
                CalAturar = true,
                Ignorar = false
            };
            categoriaAplicacions.Aplicacions.Add(aplicacio);
            aplicacioEnUs.Aplicacio = aplicacio;
            item.BackColor = System.Drawing.Color.LightCoral;

            menuDesar.Enabled = true;
        }

        private void MenuPermetre_Click(object sender, EventArgs e)
        {
            var item = llistaAplicacions.SelectedItems[0];
            if (item?.Tag is not AplicacioEnUs aplicacioEnUs)
                return;
            if (aplicacioEnUs.Aplicacio is not { } aplicacio)
                return;

            var categoriaAplicacions = _contenidorAplicacions.CategoriesAplicacions.FirstOrDefault(c => c.Nom.Equals(aplicacio.Categoria));
            var app = categoriaAplicacions?.Aplicacions.FirstOrDefault(a => a.Nom.Equals(aplicacio.Nom));
            if (app == null)
                return;

            app.CalAturar = false;
            app.Ignorar = false;
            aplicacioEnUs.Aplicacio = app;
            item.BackColor = System.Drawing.Color.LightBlue;

            menuDesar.Enabled = true;
        }

        private void MenuIgnorar_Click(object sender, EventArgs e)
        {
            var item = llistaAplicacions.SelectedItems[0];
            if (item?.Tag is not AplicacioEnUs aplicacioEnUs)
                return;
            if (aplicacioEnUs.Aplicacio is not { } aplicacio)
                return;

            var categoriaAplicacions = _contenidorAplicacions.CategoriesAplicacions.FirstOrDefault(c => c.Nom.Equals(aplicacio.Categoria));
            var app = categoriaAplicacions?.Aplicacions.FirstOrDefault(a => a.Nom.Equals(aplicacio.Nom));
            if (app == null)
                return;

            app.Ignorar = true;
            aplicacioEnUs.Aplicacio = app;
            item.BackColor = System.Drawing.Color.LightGreen;

            menuDesar.Enabled = true;
        }

        private void MenuEsborrar_Click(object sender, EventArgs e)
        {
            var item = llistaAplicacions.SelectedItems[0];
            if (item?.Tag is not AplicacioEnUs aplicacioEnUs)
                return;
            if (aplicacioEnUs.Aplicacio is not { } aplicacio)
                return;

            var categoriaAplicacions = _contenidorAplicacions.CategoriesAplicacions.FirstOrDefault(c => c.Nom.Equals(aplicacio.Categoria));
            var app = categoriaAplicacions?.Aplicacions.FirstOrDefault(a => a.Nom.Equals(aplicacio.Nom));
            if (app == null)
                return;

            categoriaAplicacions.Aplicacions.Remove(app);
            aplicacioEnUs.Aplicacio = null;
            item.BackColor = default;

            menuDesar.Enabled = true;
        }

        private void MenuDesar_Click(object sender, EventArgs e)
        {
            if (!menuDesar.Enabled || @"Vols desar els canvis?".Mostrar(MessageBoxIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes) 
                return;
            
            _contenidorAplicacions.CategoriesAplicacions.Desar(_fitxer);
            menuDesar.Enabled = false;
        }

        private void menuDesar_Click(object sender, EventArgs e)
        {

        }
    }
}
