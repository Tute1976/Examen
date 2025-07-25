using System.Windows.Forms;

namespace Examen.Suport.Controls
{
    partial class InfoEstacio
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoEstacio));
            this.gb = new System.Windows.Forms.GroupBox();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.txtDataInci = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEstat = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInformacio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuari = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstacio = new System.Windows.Forms.Label();
            this.panelImatge = new System.Windows.Forms.Panel();
            this.imatge = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bPitar = new System.Windows.Forms.ToolStripButton();
            this.bBloquejar = new System.Windows.Forms.ToolStripButton();
            this.bAturar = new System.Windows.Forms.ToolStripButton();
            this.bInfo = new System.Windows.Forms.ToolStripButton();
            this.bTancar = new System.Windows.Forms.ToolStripButton();
            this.bAplicacionsEnUs = new System.Windows.Forms.ToolStripButton();
            this.imatges = new System.Windows.Forms.ImageList(this.components);
            this.gb.SuspendLayout();
            this.taula.SuspendLayout();
            this.panelImatge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imatge)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.taula);
            this.gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb.Location = new System.Drawing.Point(5, 0);
            this.gb.Margin = new System.Windows.Forms.Padding(5);
            this.gb.Name = "gb";
            this.gb.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.gb.Size = new System.Drawing.Size(240, 155);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "nom";
            // 
            // taula
            // 
            this.taula.BackColor = System.Drawing.Color.White;
            this.taula.ColumnCount = 4;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.taula.Controls.Add(this.txtDataInci, 1, 3);
            this.taula.Controls.Add(this.label11, 1, 3);
            this.taula.Controls.Add(this.txtEstat, 1, 5);
            this.taula.Controls.Add(this.label7, 1, 4);
            this.taula.Controls.Add(this.txtInformacio, 2, 2);
            this.taula.Controls.Add(this.label8, 1, 2);
            this.taula.Controls.Add(this.txtUsuari, 2, 1);
            this.taula.Controls.Add(this.label5, 1, 1);
            this.taula.Controls.Add(this.txtEstacio, 2, 0);
            this.taula.Controls.Add(this.panelImatge, 0, 0);
            this.taula.Controls.Add(this.label1, 1, 0);
            this.taula.Controls.Add(this.menu, 3, 0);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taula.Location = new System.Drawing.Point(10, 15);
            this.taula.Margin = new System.Windows.Forms.Padding(0);
            this.taula.Name = "taula";
            this.taula.Padding = new System.Windows.Forms.Padding(5);
            this.taula.RowCount = 5;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.Size = new System.Drawing.Size(220, 130);
            this.taula.TabIndex = 2;
            // 
            // txtDataInci
            // 
            this.txtDataInci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataInci.Location = new System.Drawing.Point(99, 65);
            this.txtDataInci.Name = "txtDataInci";
            this.txtDataInci.Size = new System.Drawing.Size(80, 20);
            this.txtDataInci.TabIndex = 17;
            this.txtDataInci.Text = "dInici";
            this.txtDataInci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(42, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Temps";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEstat
            // 
            this.taula.SetColumnSpan(this.txtEstat, 2);
            this.txtEstat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstat.Location = new System.Drawing.Point(42, 105);
            this.txtEstat.Name = "txtEstat";
            this.txtEstat.Size = new System.Drawing.Size(137, 20);
            this.txtEstat.TabIndex = 12;
            this.txtEstat.Text = "estat";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Estat";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInformacio
            // 
            this.txtInformacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformacio.Location = new System.Drawing.Point(99, 45);
            this.txtInformacio.Name = "txtInformacio";
            this.txtInformacio.Size = new System.Drawing.Size(80, 20);
            this.txtInformacio.TabIndex = 10;
            this.txtInformacio.Text = "informacio";
            this.txtInformacio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Informació";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsuari
            // 
            this.txtUsuari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuari.Location = new System.Drawing.Point(99, 25);
            this.txtUsuari.Name = "txtUsuari";
            this.txtUsuari.Size = new System.Drawing.Size(80, 20);
            this.txtUsuari.TabIndex = 7;
            this.txtUsuari.Text = "usuari";
            this.txtUsuari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Usuari";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEstacio
            // 
            this.txtEstacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstacio.Location = new System.Drawing.Point(99, 5);
            this.txtEstacio.Name = "txtEstacio";
            this.txtEstacio.Size = new System.Drawing.Size(80, 20);
            this.txtEstacio.TabIndex = 3;
            this.txtEstacio.Text = "estacio";
            this.txtEstacio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelImatge
            // 
            this.panelImatge.BackColor = System.Drawing.Color.White;
            this.panelImatge.Controls.Add(this.imatge);
            this.panelImatge.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelImatge.Location = new System.Drawing.Point(5, 5);
            this.panelImatge.Margin = new System.Windows.Forms.Padding(0);
            this.panelImatge.Name = "panelImatge";
            this.panelImatge.Padding = new System.Windows.Forms.Padding(5);
            this.taula.SetRowSpan(this.panelImatge, 6);
            this.panelImatge.Size = new System.Drawing.Size(34, 120);
            this.panelImatge.TabIndex = 1;
            // 
            // imatge
            // 
            this.imatge.Dock = System.Windows.Forms.DockStyle.Top;
            this.imatge.Location = new System.Drawing.Point(5, 5);
            this.imatge.Margin = new System.Windows.Forms.Padding(0);
            this.imatge.MaximumSize = new System.Drawing.Size(24, 24);
            this.imatge.MinimumSize = new System.Drawing.Size(24, 24);
            this.imatge.Name = "imatge";
            this.imatge.Size = new System.Drawing.Size(24, 24);
            this.imatge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imatge.TabIndex = 0;
            this.imatge.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estació";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bPitar,
            this.bBloquejar,
            this.bAturar,
            this.bInfo,
            this.bTancar,
            this.bAplicacionsEnUs});
            this.menu.Location = new System.Drawing.Point(191, 5);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.taula.SetRowSpan(this.menu, 6);
            this.menu.Size = new System.Drawing.Size(24, 120);
            this.menu.TabIndex = 18;
            // 
            // bPitar
            // 
            this.bPitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bPitar.Image = global::Examen.Suport.Properties.Resources.Altaveu_32x32;
            this.bPitar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bPitar.Name = "bPitar";
            this.bPitar.Size = new System.Drawing.Size(21, 20);
            this.bPitar.Text = "Reproduïr un xiulet";
            this.bPitar.ToolTipText = "Reproduïr un xiulet";
            this.bPitar.Click += new System.EventHandler(this.bPitar_Click);
            // 
            // bBloquejar
            // 
            this.bBloquejar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bBloquejar.Image = global::Examen.Suport.Properties.Resources.Bloquejar_32x32;
            this.bBloquejar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bBloquejar.Name = "bBloquejar";
            this.bBloquejar.Size = new System.Drawing.Size(21, 20);
            this.bBloquejar.Text = "Bloquejar estació";
            this.bBloquejar.Click += new System.EventHandler(this.bBloquejar_Click);
            // 
            // bAturar
            // 
            this.bAturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAturar.Image = global::Examen.Suport.Properties.Resources.Aturar_32x32;
            this.bAturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAturar.Name = "bAturar";
            this.bAturar.Size = new System.Drawing.Size(21, 20);
            this.bAturar.Text = "Aturar estació";
            this.bAturar.Click += new System.EventHandler(this.bAturar_Click);
            // 
            // bInfo
            // 
            this.bInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bInfo.Image = global::Examen.Suport.Properties.Resources.Informacio_32x32;
            this.bInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bInfo.Name = "bInfo";
            this.bInfo.Size = new System.Drawing.Size(21, 20);
            this.bInfo.Text = "Mostrar identificador";
            this.bInfo.ToolTipText = "Mostrar identificador";
            this.bInfo.Click += new System.EventHandler(this.bInfo_Click);
            // 
            // bTancar
            // 
            this.bTancar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bTancar.Image = global::Examen.Suport.Properties.Resources.Cancel_32x32;
            this.bTancar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTancar.Name = "bTancar";
            this.bTancar.Size = new System.Drawing.Size(21, 20);
            this.bTancar.Text = "Tancar";
            this.bTancar.Visible = false;
            this.bTancar.Click += new System.EventHandler(this.bTancar_Click);
            // 
            // bAplicacionsEnUs
            // 
            this.bAplicacionsEnUs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAplicacionsEnUs.Image = global::Examen.Suport.Properties.Resources.Aplicacions_32x32;
            this.bAplicacionsEnUs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAplicacionsEnUs.Name = "bAplicacionsEnUs";
            this.bAplicacionsEnUs.Size = new System.Drawing.Size(21, 20);
            this.bAplicacionsEnUs.Text = "Aplicacions en ús";
            this.bAplicacionsEnUs.Click += new System.EventHandler(this.bAplicacionsEnUs_Click);
            // 
            // imatges
            // 
            this.imatges.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imatges.ImageStream")));
            this.imatges.TransparentColor = System.Drawing.Color.Transparent;
            this.imatges.Images.SetKeyName(0, "Laptop_1.png");
            this.imatges.Images.SetKeyName(1, "Laptop_Nou.png");
            this.imatges.Images.SetKeyName(2, "Laptop_Atencio.png");
            this.imatges.Images.SetKeyName(3, "Laptop_Vell.png");
            // 
            // InfoEstacio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gb);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(0, 160);
            this.MinimumSize = new System.Drawing.Size(250, 160);
            this.Name = "InfoEstacio";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.Size = new System.Drawing.Size(250, 160);
            this.gb.ResumeLayout(false);
            this.taula.ResumeLayout(false);
            this.taula.PerformLayout();
            this.panelImatge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imatge)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.PictureBox imatge;
        private System.Windows.Forms.ImageList imatges;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Panel panelImatge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtEstat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtInformacio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtUsuari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtEstacio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtDataInci;
        private ToolStrip menu;
        private ToolStripButton bPitar;
        private ToolStripButton bBloquejar;
        private ToolStripButton bAturar;
        private ToolStripButton bInfo;
        private ToolStripButton bTancar;
        private ToolStripButton bAplicacionsEnUs;
    }
}
