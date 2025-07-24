namespace Examen.Professor.Formularis
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel1 = new Syncfusion.Windows.Forms.CaptionLabel();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel2 = new Syncfusion.Windows.Forms.CaptionLabel();
            this.split = new System.Windows.Forms.SplitContainer();
            this.panelTaula = new System.Windows.Forms.Panel();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.panelHistoric = new System.Windows.Forms.Panel();
            this.llistaHistoric = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imatgesLlista = new System.Windows.Forms.ImageList(this.components);
            this.panelComboBox = new System.Windows.Forms.Panel();
            this.lFiltreHistoric = new System.Windows.Forms.Label();
            this.cbHistoric = new System.Windows.Forms.ComboBox();
            this.timerInici = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.ToolStrip();
            this.cbColumnes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bMostrarLlista = new System.Windows.Forms.ToolStripButton();
            this.bNetejarLlista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bAplicacions = new System.Windows.Forms.ToolStripButton();
            this.bSortir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bCopiarCodi = new System.Windows.Forms.ToolStripButton();
            this.timerCaducades = new System.Windows.Forms.Timer(this.components);
            this.timerTancar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.panelTaula.SuspendLayout();
            this.panelHistoric.SuspendLayout();
            this.panelComboBox.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(5, 5);
            this.split.Margin = new System.Windows.Forms.Padding(0);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.panelTaula);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.panelHistoric);
            this.split.Panel2MinSize = 200;
            this.split.Size = new System.Drawing.Size(892, 476);
            this.split.SplitterDistance = 266;
            this.split.SplitterWidth = 10;
            this.split.TabIndex = 0;
            // 
            // panelTaula
            // 
            this.panelTaula.AutoScroll = true;
            this.panelTaula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTaula.Controls.Add(this.taula);
            this.panelTaula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaula.Location = new System.Drawing.Point(0, 0);
            this.panelTaula.Name = "panelTaula";
            this.panelTaula.Size = new System.Drawing.Size(892, 266);
            this.panelTaula.TabIndex = 1;
            // 
            // taula
            // 
            this.taula.AutoSize = true;
            this.taula.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.taula.ColumnCount = 2;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.Dock = System.Windows.Forms.DockStyle.Top;
            this.taula.Location = new System.Drawing.Point(0, 0);
            this.taula.Name = "taula";
            this.taula.RowCount = 2;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.Size = new System.Drawing.Size(890, 0);
            this.taula.TabIndex = 0;
            // 
            // panelHistoric
            // 
            this.panelHistoric.Controls.Add(this.llistaHistoric);
            this.panelHistoric.Controls.Add(this.panelComboBox);
            this.panelHistoric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistoric.Location = new System.Drawing.Point(0, 0);
            this.panelHistoric.Margin = new System.Windows.Forms.Padding(0);
            this.panelHistoric.Name = "panelHistoric";
            this.panelHistoric.Size = new System.Drawing.Size(892, 200);
            this.panelHistoric.TabIndex = 1;
            // 
            // llistaHistoric
            // 
            this.llistaHistoric.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4});
            this.llistaHistoric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llistaHistoric.FullRowSelect = true;
            this.llistaHistoric.HideSelection = false;
            this.llistaHistoric.Location = new System.Drawing.Point(0, 31);
            this.llistaHistoric.Margin = new System.Windows.Forms.Padding(0);
            this.llistaHistoric.Name = "llistaHistoric";
            this.llistaHistoric.Size = new System.Drawing.Size(892, 169);
            this.llistaHistoric.SmallImageList = this.imatgesLlista;
            this.llistaHistoric.TabIndex = 0;
            this.llistaHistoric.UseCompatibleStateImageBehavior = false;
            this.llistaHistoric.View = System.Windows.Forms.View.Details;
            this.llistaHistoric.DoubleClick += new System.EventHandler(this.LlistaHistoric_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Estació";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Informació";
            this.columnHeader4.Width = 500;
            // 
            // imatgesLlista
            // 
            this.imatgesLlista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imatgesLlista.ImageStream")));
            this.imatgesLlista.TransparentColor = System.Drawing.Color.Transparent;
            this.imatgesLlista.Images.SetKeyName(0, "Laptop_1.png");
            this.imatgesLlista.Images.SetKeyName(1, "Laptop_Nou.png");
            this.imatgesLlista.Images.SetKeyName(2, "Laptop_Vell.png");
            this.imatgesLlista.Images.SetKeyName(3, "Laptop_Atencio.png");
            // 
            // panelComboBox
            // 
            this.panelComboBox.Controls.Add(this.lFiltreHistoric);
            this.panelComboBox.Controls.Add(this.cbHistoric);
            this.panelComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComboBox.Location = new System.Drawing.Point(0, 0);
            this.panelComboBox.Name = "panelComboBox";
            this.panelComboBox.Size = new System.Drawing.Size(892, 31);
            this.panelComboBox.TabIndex = 2;
            // 
            // lFiltreHistoric
            // 
            this.lFiltreHistoric.Dock = System.Windows.Forms.DockStyle.Right;
            this.lFiltreHistoric.Location = new System.Drawing.Point(569, 0);
            this.lFiltreHistoric.Name = "lFiltreHistoric";
            this.lFiltreHistoric.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.lFiltreHistoric.Size = new System.Drawing.Size(123, 31);
            this.lFiltreHistoric.TabIndex = 1;
            this.lFiltreHistoric.Text = "Filtre per estacions";
            this.lFiltreHistoric.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lFiltreHistoric.Visible = false;
            // 
            // cbHistoric
            // 
            this.cbHistoric.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbHistoric.FormattingEnabled = true;
            this.cbHistoric.Items.AddRange(new object[] {
            "Totes les estacions"});
            this.cbHistoric.Location = new System.Drawing.Point(692, 0);
            this.cbHistoric.Margin = new System.Windows.Forms.Padding(0);
            this.cbHistoric.Name = "cbHistoric";
            this.cbHistoric.Size = new System.Drawing.Size(200, 21);
            this.cbHistoric.Sorted = true;
            this.cbHistoric.TabIndex = 0;
            this.cbHistoric.Text = "Totes les estacions";
            this.cbHistoric.Visible = false;
            this.cbHistoric.SelectedIndexChanged += new System.EventHandler(this.cbHistoric_SelectedIndexChanged);
            // 
            // timerInici
            // 
            this.timerInici.Enabled = true;
            this.timerInici.Tick += new System.EventHandler(this.TimerInici_Tick);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbColumnes,
            this.toolStripSeparator1,
            this.bMostrarLlista,
            this.bNetejarLlista,
            this.toolStripSeparator2,
            this.bAplicacions,
            this.bSortir,
            this.toolStripSeparator3,
            this.bCopiarCodi});
            this.menu.Location = new System.Drawing.Point(897, 5);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.menu.Size = new System.Drawing.Size(82, 476);
            this.menu.TabIndex = 0;
            // 
            // cbColumnes
            // 
            this.cbColumnes.DropDownWidth = 24;
            this.cbColumnes.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.cbColumnes.MaxDropDownItems = 3;
            this.cbColumnes.Name = "cbColumnes";
            this.cbColumnes.Size = new System.Drawing.Size(69, 23);
            this.cbColumnes.Sorted = true;
            this.cbColumnes.Text = "3";
            this.cbColumnes.ToolTipText = "Número de columnes";
            this.cbColumnes.SelectedIndexChanged += new System.EventHandler(this.CbColumnes_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(71, 6);
            // 
            // bMostrarLlista
            // 
            this.bMostrarLlista.Checked = true;
            this.bMostrarLlista.CheckOnClick = true;
            this.bMostrarLlista.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bMostrarLlista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bMostrarLlista.Image = global::Examen.Professor.Properties.Resources.Llista_32x32;
            this.bMostrarLlista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMostrarLlista.Name = "bMostrarLlista";
            this.bMostrarLlista.Size = new System.Drawing.Size(71, 36);
            this.bMostrarLlista.ToolTipText = "Mostrar llista";
            this.bMostrarLlista.CheckedChanged += new System.EventHandler(this.bMostrarLlista_CheckedChanged);
            // 
            // bNetejarLlista
            // 
            this.bNetejarLlista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNetejarLlista.Image = global::Examen.Professor.Properties.Resources.Neteja_32x32;
            this.bNetejarLlista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNetejarLlista.Name = "bNetejarLlista";
            this.bNetejarLlista.Size = new System.Drawing.Size(71, 36);
            this.bNetejarLlista.Text = "Netejar llista";
            this.bNetejarLlista.ToolTipText = "Netejar llista";
            this.bNetejarLlista.Click += new System.EventHandler(this.bNetejarLlista_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(71, 6);
            // 
            // bAplicacions
            // 
            this.bAplicacions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAplicacions.Image = global::Examen.Professor.Properties.Resources.Aplicacions_32x32;
            this.bAplicacions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAplicacions.Name = "bAplicacions";
            this.bAplicacions.Size = new System.Drawing.Size(71, 36);
            this.bAplicacions.Text = "Aplicacions";
            this.bAplicacions.Click += new System.EventHandler(this.bAplicacions_Click);
            // 
            // bSortir
            // 
            this.bSortir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bSortir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSortir.Image = global::Examen.Professor.Properties.Resources.Sortir_32x32;
            this.bSortir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSortir.Name = "bSortir";
            this.bSortir.Size = new System.Drawing.Size(71, 36);
            this.bSortir.Text = "Tancar l\'aplicació";
            this.bSortir.Click += new System.EventHandler(this.bSortir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(71, 6);
            // 
            // bCopiarCodi
            // 
            this.bCopiarCodi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bCopiarCodi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bCopiarCodi.Image = global::Examen.Professor.Properties.Resources.Copiar_32x32;
            this.bCopiarCodi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCopiarCodi.Name = "bCopiarCodi";
            this.bCopiarCodi.Size = new System.Drawing.Size(71, 36);
            this.bCopiarCodi.Text = "Copiar codi";
            this.bCopiarCodi.ToolTipText = "Copiar codi";
            this.bCopiarCodi.Click += new System.EventHandler(this.bCopiarCodi_Click);
            // 
            // timerCaducades
            // 
            this.timerCaducades.Tick += new System.EventHandler(this.timerCaducades_Tick);
            // 
            // timerTancar
            // 
            this.timerTancar.Interval = 1000;
            this.timerTancar.Tick += new System.EventHandler(this.timerTancar_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.Gray;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.CaptionBarHeight = 96;
            this.CaptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = global::Examen.Professor.Properties.Resources.Examen2;
            captionImage1.Location = new System.Drawing.Point(18, 12);
            captionImage1.Name = "Logo";
            captionImage1.Size = new System.Drawing.Size(64, 64);
            this.CaptionImages.Add(captionImage1);
            captionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel1.Location = new System.Drawing.Point(650, 64);
            captionLabel1.Name = "TxtCodi";
            captionLabel1.Text = "Codi";
            captionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel2.Location = new System.Drawing.Point(650, 8);
            captionLabel2.Name = "Codi";
            captionLabel2.Size = new System.Drawing.Size(500, 64);
            captionLabel2.Text = "XXXXX";
            this.CaptionLabels.Add(captionLabel1);
            this.CaptionLabels.Add(captionLabel2);
            this.ClientSize = new System.Drawing.Size(984, 486);
            this.Controls.Add(this.split);
            this.Controls.Add(this.menu);
            this.DropShadow = true;
            this.EnableTouchMode = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.panelTaula.ResumeLayout(false);
            this.panelTaula.PerformLayout();
            this.panelHistoric.ResumeLayout(false);
            this.panelComboBox.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ListView llistaHistoric;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Timer timerInici;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imatgesLlista;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripComboBox cbColumnes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Panel panelTaula;
        private System.Windows.Forms.ToolStripButton bMostrarLlista;
        private System.Windows.Forms.ToolStripButton bNetejarLlista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bCopiarCodi;
        private System.Windows.Forms.Timer timerCaducades;
        private System.Windows.Forms.ToolStripButton bAplicacions;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panelHistoric;
        private System.Windows.Forms.Panel panelComboBox;
        private System.Windows.Forms.ComboBox cbHistoric;
        private System.Windows.Forms.Label lFiltreHistoric;
        private System.Windows.Forms.ToolStripButton bSortir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Timer timerTancar;
    }
}

