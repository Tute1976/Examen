using System.Windows.Forms;

namespace Examen.Suport.Controls
{
    partial class InfoEstacioV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoEstacioV2));
            this.imatges = new System.Windows.Forms.ImageList(this.components);
            this.panelFons = new Examen.Suport.Controls.PanelAdv();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.lNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.Label();
            this.lEstacio = new System.Windows.Forms.Label();
            this.txtEstacio = new System.Windows.Forms.Label();
            this.lUsuari = new System.Windows.Forms.Label();
            this.txtUsuari = new System.Windows.Forms.Label();
            this.lTemps = new System.Windows.Forms.Label();
            this.txtTemps = new System.Windows.Forms.Label();
            this.panelImatge = new System.Windows.Forms.Panel();
            this.imatge = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bPitar = new System.Windows.Forms.ToolStripButton();
            this.bBloquejar = new System.Windows.Forms.ToolStripButton();
            this.bAturar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bAplicacionsEnUs = new System.Windows.Forms.ToolStripButton();
            this.bHistoric = new System.Windows.Forms.ToolStripButton();
            this.bTancar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bInfo = new System.Windows.Forms.ToolStripButton();
            this.panelFons.SuspendLayout();
            this.taula.SuspendLayout();
            this.panelImatge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imatge)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
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
            // panelFons
            // 
            this.panelFons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFons.Controls.Add(this.taula);
            this.panelFons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFons.Location = new System.Drawing.Point(8, 8);
            this.panelFons.Margin = new System.Windows.Forms.Padding(0);
            this.panelFons.Name = "panelFons";
            this.panelFons.Padding = new System.Windows.Forms.Padding(8, 0, 15, 8);
            this.panelFons.Size = new System.Drawing.Size(359, 193);
            this.panelFons.TabIndex = 19;
            // 
            // taula
            // 
            this.taula.BackColor = System.Drawing.Color.Transparent;
            this.taula.ColumnCount = 3;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.Controls.Add(this.lNom, 1, 0);
            this.taula.Controls.Add(this.txtNom, 2, 0);
            this.taula.Controls.Add(this.lEstacio, 1, 1);
            this.taula.Controls.Add(this.txtEstacio, 2, 1);
            this.taula.Controls.Add(this.lUsuari, 1, 2);
            this.taula.Controls.Add(this.txtUsuari, 2, 2);
            this.taula.Controls.Add(this.lTemps, 1, 3);
            this.taula.Controls.Add(this.txtTemps, 2, 3);
            this.taula.Controls.Add(this.panelImatge, 0, 0);
            this.taula.Controls.Add(this.menu, 0, 5);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taula.Location = new System.Drawing.Point(8, 0);
            this.taula.Margin = new System.Windows.Forms.Padding(0);
            this.taula.Name = "taula";
            this.taula.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.taula.RowCount = 2;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.Size = new System.Drawing.Size(336, 185);
            this.taula.TabIndex = 2;
            // 
            // lNom
            // 
            this.lNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNom.Location = new System.Drawing.Point(59, 8);
            this.lNom.Margin = new System.Windows.Forms.Padding(0);
            this.lNom.Name = "lNom";
            this.lNom.Size = new System.Drawing.Size(90, 31);
            this.lNom.TabIndex = 19;
            this.lNom.Text = "Nom";
            this.lNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNom
            // 
            this.txtNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNom.Location = new System.Drawing.Point(149, 8);
            this.txtNom.Margin = new System.Windows.Forms.Padding(0);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(179, 31);
            this.txtNom.TabIndex = 20;
            this.txtNom.Text = "nom";
            this.txtNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lEstacio
            // 
            this.lEstacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lEstacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEstacio.Location = new System.Drawing.Point(59, 39);
            this.lEstacio.Margin = new System.Windows.Forms.Padding(0);
            this.lEstacio.Name = "lEstacio";
            this.lEstacio.Size = new System.Drawing.Size(90, 31);
            this.lEstacio.TabIndex = 2;
            this.lEstacio.Text = "Estació";
            this.lEstacio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEstacio
            // 
            this.txtEstacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstacio.Location = new System.Drawing.Point(149, 39);
            this.txtEstacio.Margin = new System.Windows.Forms.Padding(0);
            this.txtEstacio.Name = "txtEstacio";
            this.txtEstacio.Size = new System.Drawing.Size(179, 31);
            this.txtEstacio.TabIndex = 3;
            this.txtEstacio.Text = "estacio";
            this.txtEstacio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lUsuari
            // 
            this.lUsuari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsuari.Location = new System.Drawing.Point(59, 70);
            this.lUsuari.Margin = new System.Windows.Forms.Padding(0);
            this.lUsuari.Name = "lUsuari";
            this.lUsuari.Size = new System.Drawing.Size(90, 31);
            this.lUsuari.TabIndex = 6;
            this.lUsuari.Text = "Usuari";
            this.lUsuari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsuari
            // 
            this.txtUsuari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuari.Location = new System.Drawing.Point(149, 70);
            this.txtUsuari.Margin = new System.Windows.Forms.Padding(0);
            this.txtUsuari.Name = "txtUsuari";
            this.txtUsuari.Size = new System.Drawing.Size(179, 31);
            this.txtUsuari.TabIndex = 7;
            this.txtUsuari.Text = "usuari";
            this.txtUsuari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lTemps
            // 
            this.lTemps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTemps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemps.Location = new System.Drawing.Point(59, 101);
            this.lTemps.Margin = new System.Windows.Forms.Padding(0);
            this.lTemps.Name = "lTemps";
            this.lTemps.Size = new System.Drawing.Size(90, 31);
            this.lTemps.TabIndex = 13;
            this.lTemps.Text = "Temps";
            this.lTemps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTemps
            // 
            this.txtTemps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTemps.Location = new System.Drawing.Point(149, 101);
            this.txtTemps.Margin = new System.Windows.Forms.Padding(0);
            this.txtTemps.Name = "txtTemps";
            this.txtTemps.Size = new System.Drawing.Size(179, 31);
            this.txtTemps.TabIndex = 17;
            this.txtTemps.Text = "dInici";
            this.txtTemps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelImatge
            // 
            this.panelImatge.BackColor = System.Drawing.Color.Transparent;
            this.panelImatge.Controls.Add(this.imatge);
            this.panelImatge.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelImatge.Location = new System.Drawing.Point(8, 8);
            this.panelImatge.Margin = new System.Windows.Forms.Padding(0);
            this.panelImatge.Name = "panelImatge";
            this.panelImatge.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.taula.SetRowSpan(this.panelImatge, 4);
            this.panelImatge.Size = new System.Drawing.Size(51, 124);
            this.panelImatge.TabIndex = 1;
            // 
            // imatge
            // 
            this.imatge.Dock = System.Windows.Forms.DockStyle.Top;
            this.imatge.Location = new System.Drawing.Point(8, 8);
            this.imatge.Margin = new System.Windows.Forms.Padding(0);
            this.imatge.MaximumSize = new System.Drawing.Size(36, 37);
            this.imatge.MinimumSize = new System.Drawing.Size(36, 37);
            this.imatge.Name = "imatge";
            this.imatge.Size = new System.Drawing.Size(36, 37);
            this.imatge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imatge.TabIndex = 0;
            this.imatge.TabStop = false;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.taula.SetColumnSpan(this.menu, 3);
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bPitar,
            this.bBloquejar,
            this.bAturar,
            this.toolStripSeparator1,
            this.bAplicacionsEnUs,
            this.bHistoric,
            this.bTancar,
            this.toolStripSeparator2,
            this.bInfo});
            this.menu.Location = new System.Drawing.Point(8, 140);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(320, 33);
            this.menu.TabIndex = 18;
            // 
            // bPitar
            // 
            this.bPitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bPitar.Image = global::Examen.Suport.Properties.Resources.Altaveu_32x32;
            this.bPitar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bPitar.Name = "bPitar";
            this.bPitar.Size = new System.Drawing.Size(34, 28);
            this.bPitar.Text = "Reproduïr un xiulet";
            this.bPitar.ToolTipText = "Reproduïr un xiulet";
            this.bPitar.Click += new System.EventHandler(this.BPitar_Click);
            // 
            // bBloquejar
            // 
            this.bBloquejar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bBloquejar.Image = global::Examen.Suport.Properties.Resources.Bloquejar_32x32;
            this.bBloquejar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bBloquejar.Name = "bBloquejar";
            this.bBloquejar.Size = new System.Drawing.Size(34, 28);
            this.bBloquejar.Text = "Bloquejar estació";
            this.bBloquejar.Click += new System.EventHandler(this.BBloquejar_Click);
            // 
            // bAturar
            // 
            this.bAturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAturar.Image = global::Examen.Suport.Properties.Resources.Aturar_32x32;
            this.bAturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAturar.Name = "bAturar";
            this.bAturar.Size = new System.Drawing.Size(34, 28);
            this.bAturar.Text = "Aturar estació";
            this.bAturar.Click += new System.EventHandler(this.BAturar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bAplicacionsEnUs
            // 
            this.bAplicacionsEnUs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAplicacionsEnUs.Image = global::Examen.Suport.Properties.Resources.Aplicacions_32x32;
            this.bAplicacionsEnUs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAplicacionsEnUs.Name = "bAplicacionsEnUs";
            this.bAplicacionsEnUs.Size = new System.Drawing.Size(34, 28);
            this.bAplicacionsEnUs.Text = "Aplicacions en ús";
            this.bAplicacionsEnUs.Click += new System.EventHandler(this.BAplicacionsEnUs_Click);
            // 
            // bHistoric
            // 
            this.bHistoric.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bHistoric.Image = global::Examen.Suport.Properties.Resources.Historic_32x32;
            this.bHistoric.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bHistoric.Name = "bHistoric";
            this.bHistoric.Size = new System.Drawing.Size(34, 28);
            this.bHistoric.Text = "Històric";
            this.bHistoric.Click += new System.EventHandler(this.BHistoric_Click);
            // 
            // bTancar
            // 
            this.bTancar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bTancar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bTancar.Image = global::Examen.Suport.Properties.Resources.Cancel_32x32;
            this.bTancar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTancar.Name = "bTancar";
            this.bTancar.Size = new System.Drawing.Size(34, 28);
            this.bTancar.Text = "Tancar";
            this.bTancar.Visible = false;
            this.bTancar.Click += new System.EventHandler(this.BTancar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            this.toolStripSeparator2.Visible = false;
            // 
            // bInfo
            // 
            this.bInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bInfo.Image = global::Examen.Suport.Properties.Resources.Informacio_32x32;
            this.bInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bInfo.Name = "bInfo";
            this.bInfo.Size = new System.Drawing.Size(34, 28);
            this.bInfo.Text = "Mostrar identificador";
            this.bInfo.ToolTipText = "Mostrar identificador";
            this.bInfo.Click += new System.EventHandler(this.BInfo_Click);
            // 
            // InfoEstacioV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelFons);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(0, 209);
            this.MinimumSize = new System.Drawing.Size(375, 209);
            this.Name = "InfoEstacioV2";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Size = new System.Drawing.Size(375, 209);
            this.panelFons.ResumeLayout(false);
            this.taula.ResumeLayout(false);
            this.taula.PerformLayout();
            this.panelImatge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imatge)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox imatge;
        private System.Windows.Forms.ImageList imatges;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Panel panelImatge;
        private System.Windows.Forms.Label lEstacio;
        private System.Windows.Forms.Label txtUsuari;
        private System.Windows.Forms.Label lUsuari;
        private System.Windows.Forms.Label txtEstacio;
        private System.Windows.Forms.Label lTemps;
        private System.Windows.Forms.Label txtTemps;
        private PanelAdv panelFons;
        private Label lNom;
        private Label txtNom;
        private ToolStrip menu;
        private ToolStripButton bPitar;
        private ToolStripButton bBloquejar;
        private ToolStripButton bAturar;
        private ToolStripButton bInfo;
        private ToolStripButton bTancar;
        private ToolStripButton bAplicacionsEnUs;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton bHistoric;
        private ToolStripSeparator toolStripSeparator2;
    }
}
