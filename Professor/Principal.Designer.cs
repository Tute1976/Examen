namespace Examen.Professor
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel1 = new Syncfusion.Windows.Forms.CaptionLabel();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel2 = new Syncfusion.Windows.Forms.CaptionLabel();
            this.split = new System.Windows.Forms.SplitContainer();
            this.llistaHistoric = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imatgesLlista = new System.Windows.Forms.ImageList(this.components);
            this.timerInici = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbColumnes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.panelTaula = new System.Windows.Forms.Panel();
            this.bMostrarLlista = new System.Windows.Forms.ToolStripButton();
            this.bNetejarLlista = new System.Windows.Forms.ToolStripButton();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelTaula.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
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
            this.split.Panel2.Controls.Add(this.llistaHistoric);
            this.split.Panel2MinSize = 200;
            this.split.Size = new System.Drawing.Size(903, 492);
            this.split.SplitterDistance = 288;
            this.split.TabIndex = 0;
            // 
            // llistaHistoric
            // 
            this.llistaHistoric.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.llistaHistoric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llistaHistoric.FullRowSelect = true;
            this.llistaHistoric.HideSelection = false;
            this.llistaHistoric.Location = new System.Drawing.Point(0, 0);
            this.llistaHistoric.Margin = new System.Windows.Forms.Padding(0);
            this.llistaHistoric.Name = "llistaHistoric";
            this.llistaHistoric.Size = new System.Drawing.Size(903, 200);
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
            this.columnHeader2.Width = 300;
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
            // timerInici
            // 
            this.timerInici.Enabled = true;
            this.timerInici.Tick += new System.EventHandler(this.TimerInici_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbColumnes,
            this.toolStripSeparator1,
            this.bMostrarLlista,
            this.bNetejarLlista});
            this.toolStrip1.Location = new System.Drawing.Point(903, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(83, 492);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbColumnes
            // 
            this.cbColumnes.DropDownWidth = 24;
            this.cbColumnes.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.cbColumnes.MaxDropDownItems = 3;
            this.cbColumnes.Name = "cbColumnes";
            this.cbColumnes.Size = new System.Drawing.Size(68, 23);
            this.cbColumnes.Sorted = true;
            this.cbColumnes.Text = "3";
            this.cbColumnes.ToolTipText = "Número de columnes";
            this.cbColumnes.SelectedIndexChanged += new System.EventHandler(this.CbColumnes_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(70, 6);
            // 
            // taula
            // 
            this.taula.ColumnCount = 2;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Location = new System.Drawing.Point(0, 0);
            this.taula.Name = "taula";
            this.taula.RowCount = 2;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.Size = new System.Drawing.Size(884, 286);
            this.taula.TabIndex = 0;
            // 
            // panelTaula
            // 
            this.panelTaula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTaula.Controls.Add(this.taula);
            this.panelTaula.Controls.Add(this.vScrollBar1);
            this.panelTaula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaula.Location = new System.Drawing.Point(0, 0);
            this.panelTaula.Name = "panelTaula";
            this.panelTaula.Size = new System.Drawing.Size(903, 288);
            this.panelTaula.TabIndex = 1;
            // 
            // bMostrarLlista
            // 
            this.bMostrarLlista.Checked = true;
            this.bMostrarLlista.CheckOnClick = true;
            this.bMostrarLlista.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bMostrarLlista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bMostrarLlista.Image = global::Examen.Professor.Properties.Resources.view_full_list_icone_6722_48;
            this.bMostrarLlista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMostrarLlista.Name = "bMostrarLlista";
            this.bMostrarLlista.Size = new System.Drawing.Size(70, 20);
            this.bMostrarLlista.ToolTipText = "Mostrar llista";
            this.bMostrarLlista.CheckedChanged += new System.EventHandler(this.bMostrarLlista_CheckedChanged);
            // 
            // bNetejarLlista
            // 
            this.bNetejarLlista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNetejarLlista.Image = global::Examen.Professor.Properties.Resources.Netejar;
            this.bNetejarLlista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNetejarLlista.Name = "bNetejarLlista";
            this.bNetejarLlista.Size = new System.Drawing.Size(70, 20);
            this.bNetejarLlista.ToolTipText = "Netejar llista";
            this.bNetejarLlista.Click += new System.EventHandler(this.bNetejarLlista_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(884, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 286);
            this.vScrollBar1.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.CaptionBarHeight = 96;
            this.CaptionButtonColor = System.Drawing.Color.Gray;
            this.CaptionButtonHoverColor = System.Drawing.Color.Gray;
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = global::Examen.Professor.Properties.Resources.Examen2;
            captionImage1.Location = new System.Drawing.Point(18, 12);
            captionImage1.Name = "Logo";
            captionImage1.Size = new System.Drawing.Size(64, 64);
            this.CaptionImages.Add(captionImage1);
            captionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel1.Location = new System.Drawing.Point(700, 64);
            captionLabel1.Name = "TxtCodi";
            captionLabel1.Text = "Codi";
            captionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel2.Location = new System.Drawing.Point(700, 8);
            captionLabel2.Name = "Codi";
            captionLabel2.Size = new System.Drawing.Size(500, 64);
            captionLabel2.Text = "XXXXX";
            this.CaptionLabels.Add(captionLabel1);
            this.CaptionLabels.Add(captionLabel2);
            this.ClientSize = new System.Drawing.Size(986, 492);
            this.Controls.Add(this.split);
            this.Controls.Add(this.toolStrip1);
            this.DropShadow = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.Name = "Principal";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelTaula.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbColumnes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Panel panelTaula;
        private System.Windows.Forms.ToolStripButton bMostrarLlista;
        private System.Windows.Forms.ToolStripButton bNetejarLlista;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

