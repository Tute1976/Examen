namespace Examen.Suport.Formularis
{
    partial class FrmAplicacionsEnUs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAplicacionsEnUs));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.menuDesar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bExportar = new System.Windows.Forms.ToolStripButton();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.llistaAplicacions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuLlista = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAturar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPermetre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIgnorar = new System.Windows.Forms.ToolStripMenuItem();
            this.separacioEsborrar = new System.Windows.Forms.ToolStripSeparator();
            this.menuEsborrar = new System.Windows.Forms.ToolStripMenuItem();
            this.imatges = new System.Windows.Forms.ImageList(this.components);
            this.lTitol = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.menuLlista.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDesar,
            this.toolStripSeparator1,
            this.bExportar,
            this.bCancelar});
            this.menu.Location = new System.Drawing.Point(754, 10);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(36, 375);
            this.menu.TabIndex = 1;
            // 
            // menuDesar
            // 
            this.menuDesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDesar.Enabled = false;
            this.menuDesar.Image = global::Examen.Suport.Properties.Resources.Desar_32x32;
            this.menuDesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDesar.Name = "menuDesar";
            this.menuDesar.Size = new System.Drawing.Size(35, 36);
            this.menuDesar.Text = "Desar";
            this.menuDesar.Click += new System.EventHandler(this.MenuDesar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(35, 6);
            // 
            // bExportar
            // 
            this.bExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bExportar.Image = global::Examen.Suport.Properties.Resources.Exportar_32x32;
            this.bExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExportar.Name = "bExportar";
            this.bExportar.Size = new System.Drawing.Size(35, 36);
            this.bExportar.Text = "Exportar";
            this.bExportar.Click += new System.EventHandler(this.BExportar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bCancelar.Image = global::Examen.Suport.Properties.Resources.Cancel_32x32;
            this.bCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(35, 36);
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(744, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 375);
            this.panel1.TabIndex = 2;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.json";
            this.saveFileDialog.FileName = "AplicacionsEnUs.json";
            this.saveFileDialog.Filter = "jSon|*.json|Tots els fitxers|*.*";
            this.saveFileDialog.Title = "Exportació";
            // 
            // llistaAplicacions
            // 
            this.llistaAplicacions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4});
            this.llistaAplicacions.ContextMenuStrip = this.menuLlista;
            this.llistaAplicacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llistaAplicacions.FullRowSelect = true;
            this.llistaAplicacions.HideSelection = false;
            this.llistaAplicacions.Location = new System.Drawing.Point(15, 42);
            this.llistaAplicacions.Margin = new System.Windows.Forms.Padding(0);
            this.llistaAplicacions.MultiSelect = false;
            this.llistaAplicacions.Name = "llistaAplicacions";
            this.llistaAplicacions.Size = new System.Drawing.Size(729, 343);
            this.llistaAplicacions.SmallImageList = this.imatges;
            this.llistaAplicacions.TabIndex = 5;
            this.llistaAplicacions.UseCompatibleStateImageBehavior = false;
            this.llistaAplicacions.View = System.Windows.Forms.View.Details;
            this.llistaAplicacions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LlistaAplicacions_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nom";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Executable";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Descripció";
            this.columnHeader4.Width = 300;
            // 
            // menuLlista
            // 
            this.menuLlista.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAturar,
            this.menuPermetre,
            this.menuIgnorar,
            this.separacioEsborrar,
            this.menuEsborrar});
            this.menuLlista.Name = "menuLlista";
            this.menuLlista.Size = new System.Drawing.Size(159, 98);
            this.menuLlista.Opening += new System.ComponentModel.CancelEventHandler(this.MenuLlista_Opening);
            // 
            // menuAturar
            // 
            this.menuAturar.Image = global::Examen.Suport.Properties.Resources.Aturar_16x16;
            this.menuAturar.Name = "menuAturar";
            this.menuAturar.Size = new System.Drawing.Size(158, 22);
            this.menuAturar.Text = "Aturar";
            this.menuAturar.ToolTipText = "Bloquejar aplicació";
            this.menuAturar.Click += new System.EventHandler(this.MenuAturar_Click);
            // 
            // menuPermetre
            // 
            this.menuPermetre.Image = global::Examen.Suport.Properties.Resources.Validation_16x16;
            this.menuPermetre.Name = "menuPermetre";
            this.menuPermetre.Size = new System.Drawing.Size(158, 22);
            this.menuPermetre.Text = "Permetre";
            this.menuPermetre.ToolTipText = "Permetre aplicació";
            this.menuPermetre.Click += new System.EventHandler(this.MenuPermetre_Click);
            // 
            // menuIgnorar
            // 
            this.menuIgnorar.Image = global::Examen.Suport.Properties.Resources.Base_16x16;
            this.menuIgnorar.Name = "menuIgnorar";
            this.menuIgnorar.Size = new System.Drawing.Size(158, 22);
            this.menuIgnorar.Text = "Ignorar";
            this.menuIgnorar.ToolTipText = "Ignorar aplicació";
            this.menuIgnorar.Click += new System.EventHandler(this.MenuIgnorar_Click);
            // 
            // separacioEsborrar
            // 
            this.separacioEsborrar.Name = "separacioEsborrar";
            this.separacioEsborrar.Size = new System.Drawing.Size(155, 6);
            // 
            // menuEsborrar
            // 
            this.menuEsborrar.Image = global::Examen.Suport.Properties.Resources.Neteja_16x16;
            this.menuEsborrar.Name = "menuEsborrar";
            this.menuEsborrar.Size = new System.Drawing.Size(158, 22);
            this.menuEsborrar.Text = "Esborrar control";
            this.menuEsborrar.ToolTipText = "Esborrar aplicació de la llista de control";
            this.menuEsborrar.Click += new System.EventHandler(this.MenuEsborrar_Click);
            // 
            // imatges
            // 
            this.imatges.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imatges.ImageSize = new System.Drawing.Size(16, 16);
            this.imatges.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lTitol
            // 
            this.lTitol.Dock = System.Windows.Forms.DockStyle.Top;
            this.lTitol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitol.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lTitol.Location = new System.Drawing.Point(15, 10);
            this.lTitol.Margin = new System.Windows.Forms.Padding(0);
            this.lTitol.Name = "lTitol";
            this.lTitol.Size = new System.Drawing.Size(729, 32);
            this.lTitol.TabIndex = 6;
            this.lTitol.Text = "label1";
            // 
            // FrmAplicacionsEnUs
            // 
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.ControlBox = false;
            this.Controls.Add(this.llistaAplicacions);
            this.Controls.Add(this.lTitol);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAplicacionsEnUs";
            this.Padding = new System.Windows.Forms.Padding(15, 10, 10, 15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicacions en ús";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.menuLlista.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton bCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton bExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ListView llistaAplicacions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imatges;
        private System.Windows.Forms.ContextMenuStrip menuLlista;
        private System.Windows.Forms.ToolStripMenuItem menuAturar;
        private System.Windows.Forms.ToolStripMenuItem menuPermetre;
        private System.Windows.Forms.ToolStripSeparator separacioEsborrar;
        private System.Windows.Forms.ToolStripMenuItem menuEsborrar;
        private System.Windows.Forms.ToolStripMenuItem menuIgnorar;
        private System.Windows.Forms.Label lTitol;
        private System.Windows.Forms.ToolStripButton menuDesar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}