namespace Examen.Professor.Formularis
{
    partial class FrmEdicioAplicacio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdicioAplicacio));
            this.lTitol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bDesar = new System.Windows.Forms.ToolStripButton();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.bDesfer = new System.Windows.Forms.ToolStripButton();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.chkIgnorar = new System.Windows.Forms.CheckBox();
            this.txtExecutable = new System.Windows.Forms.TextBox();
            this.txtDescripcio = new System.Windows.Forms.TextBox();
            this.lIcona = new System.Windows.Forms.Label();
            this.lExecutable = new System.Windows.Forms.Label();
            this.lIgnorar = new System.Windows.Forms.Label();
            this.lCalAturar = new System.Windows.Forms.Label();
            this.lDescripcio = new System.Windows.Forms.Label();
            this.lNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.chkCalAturar = new System.Windows.Forms.CheckBox();
            this.pbIcona = new System.Windows.Forms.PictureBox();
            this.bCercar = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.taula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcona)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitol
            // 
            this.lTitol.Dock = System.Windows.Forms.DockStyle.Top;
            this.lTitol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitol.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lTitol.Location = new System.Drawing.Point(22, 15);
            this.lTitol.Margin = new System.Windows.Forms.Padding(0);
            this.lTitol.Name = "lTitol";
            this.lTitol.Size = new System.Drawing.Size(640, 49);
            this.lTitol.TabIndex = 10;
            this.lTitol.Text = "Aplicació";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(662, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 236);
            this.panel1.TabIndex = 9;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDesar,
            this.bCancelar,
            this.bDesfer});
            this.menu.Location = new System.Drawing.Point(677, 15);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(36, 236);
            this.menu.TabIndex = 8;
            // 
            // bDesar
            // 
            this.bDesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDesar.Enabled = false;
            this.bDesar.Image = global::Examen.Professor.Properties.Resources.Desar_32x32;
            this.bDesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDesar.Name = "bDesar";
            this.bDesar.Size = new System.Drawing.Size(35, 36);
            this.bDesar.Text = "Desar";
            this.bDesar.Click += new System.EventHandler(this.BDesar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bCancelar.Image = global::Examen.Professor.Properties.Resources.Cancel_32x32;
            this.bCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(35, 36);
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // bDesfer
            // 
            this.bDesfer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDesfer.Image = global::Examen.Professor.Properties.Resources.Desfer_32x32;
            this.bDesfer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDesfer.Name = "bDesfer";
            this.bDesfer.Size = new System.Drawing.Size(35, 36);
            this.bDesfer.Text = "Desfer canvis";
            this.bDesfer.Visible = false;
            this.bDesfer.Click += new System.EventHandler(this.BDesfer_Click);
            // 
            // taula
            // 
            this.taula.ColumnCount = 5;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.taula.Controls.Add(this.chkIgnorar, 3, 4);
            this.taula.Controls.Add(this.txtExecutable, 1, 2);
            this.taula.Controls.Add(this.txtDescripcio, 1, 1);
            this.taula.Controls.Add(this.lIcona, 0, 3);
            this.taula.Controls.Add(this.lExecutable, 0, 2);
            this.taula.Controls.Add(this.lIgnorar, 2, 4);
            this.taula.Controls.Add(this.lCalAturar, 2, 3);
            this.taula.Controls.Add(this.lDescripcio, 0, 1);
            this.taula.Controls.Add(this.lNom, 0, 0);
            this.taula.Controls.Add(this.txtNom, 1, 0);
            this.taula.Controls.Add(this.chkCalAturar, 3, 3);
            this.taula.Controls.Add(this.pbIcona, 1, 3);
            this.taula.Controls.Add(this.bCercar, 4, 2);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Location = new System.Drawing.Point(22, 64);
            this.taula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taula.Name = "taula";
            this.taula.RowCount = 6;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.taula.Size = new System.Drawing.Size(640, 187);
            this.taula.TabIndex = 11;
            // 
            // chkIgnorar
            // 
            this.chkIgnorar.AutoSize = true;
            this.taula.SetColumnSpan(this.chkIgnorar, 2);
            this.chkIgnorar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkIgnorar.Location = new System.Drawing.Point(456, 153);
            this.chkIgnorar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnorar.Name = "chkIgnorar";
            this.chkIgnorar.Size = new System.Drawing.Size(180, 27);
            this.chkIgnorar.TabIndex = 36;
            this.chkIgnorar.UseVisualStyleBackColor = true;
            this.chkIgnorar.CheckedChanged += new System.EventHandler(this.ChkIgnorar_CheckedChanged);
            // 
            // txtExecutable
            // 
            this.txtExecutable.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtExecutable, 3);
            this.txtExecutable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExecutable.Location = new System.Drawing.Point(154, 79);
            this.txtExecutable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExecutable.Name = "txtExecutable";
            this.txtExecutable.Size = new System.Drawing.Size(446, 26);
            this.txtExecutable.TabIndex = 34;
            this.txtExecutable.TextChanged += new System.EventHandler(this.TxtExecutable_TextChanged);
            // 
            // txtDescripcio
            // 
            this.txtDescripcio.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtDescripcio, 4);
            this.txtDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcio.Location = new System.Drawing.Point(154, 42);
            this.txtDescripcio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescripcio.Name = "txtDescripcio";
            this.txtDescripcio.Size = new System.Drawing.Size(482, 26);
            this.txtDescripcio.TabIndex = 29;
            this.txtDescripcio.TextChanged += new System.EventHandler(this.TxtDescripcio_TextChanged);
            // 
            // lIcona
            // 
            this.lIcona.BackColor = System.Drawing.Color.Transparent;
            this.lIcona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lIcona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIcona.Location = new System.Drawing.Point(4, 111);
            this.lIcona.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIcona.Name = "lIcona";
            this.taula.SetRowSpan(this.lIcona, 2);
            this.lIcona.Size = new System.Drawing.Size(142, 74);
            this.lIcona.TabIndex = 25;
            this.lIcona.Text = "Icona";
            this.lIcona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lExecutable
            // 
            this.lExecutable.BackColor = System.Drawing.Color.Transparent;
            this.lExecutable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lExecutable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExecutable.Location = new System.Drawing.Point(4, 74);
            this.lExecutable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lExecutable.Name = "lExecutable";
            this.lExecutable.Size = new System.Drawing.Size(142, 37);
            this.lExecutable.TabIndex = 21;
            this.lExecutable.Text = "Executable";
            this.lExecutable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lIgnorar
            // 
            this.lIgnorar.BackColor = System.Drawing.Color.Transparent;
            this.lIgnorar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lIgnorar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIgnorar.Location = new System.Drawing.Point(306, 148);
            this.lIgnorar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIgnorar.Name = "lIgnorar";
            this.lIgnorar.Size = new System.Drawing.Size(142, 37);
            this.lIgnorar.TabIndex = 12;
            this.lIgnorar.Text = "Ignorar";
            this.lIgnorar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCalAturar
            // 
            this.lCalAturar.BackColor = System.Drawing.Color.Transparent;
            this.lCalAturar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCalAturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCalAturar.Location = new System.Drawing.Point(306, 111);
            this.lCalAturar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCalAturar.Name = "lCalAturar";
            this.lCalAturar.Size = new System.Drawing.Size(142, 37);
            this.lCalAturar.TabIndex = 4;
            this.lCalAturar.Text = "Cal aturar";
            this.lCalAturar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDescripcio
            // 
            this.lDescripcio.BackColor = System.Drawing.Color.Transparent;
            this.lDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDescripcio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescripcio.Location = new System.Drawing.Point(4, 37);
            this.lDescripcio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDescripcio.Name = "lDescripcio";
            this.lDescripcio.Size = new System.Drawing.Size(142, 37);
            this.lDescripcio.TabIndex = 2;
            this.lDescripcio.Text = "Descripció";
            this.lDescripcio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lNom
            // 
            this.lNom.BackColor = System.Drawing.Color.Transparent;
            this.lNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNom.Location = new System.Drawing.Point(4, 0);
            this.lNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNom.Name = "lNom";
            this.lNom.Size = new System.Drawing.Size(142, 37);
            this.lNom.TabIndex = 0;
            this.lNom.Text = "Nom";
            this.lNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtNom, 4);
            this.txtNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNom.Location = new System.Drawing.Point(154, 5);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(482, 26);
            this.txtNom.TabIndex = 26;
            this.txtNom.TextChanged += new System.EventHandler(this.TxtNom_TextChanged);
            // 
            // chkCalAturar
            // 
            this.chkCalAturar.AutoSize = true;
            this.taula.SetColumnSpan(this.chkCalAturar, 2);
            this.chkCalAturar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCalAturar.Location = new System.Drawing.Point(456, 116);
            this.chkCalAturar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCalAturar.Name = "chkCalAturar";
            this.chkCalAturar.Size = new System.Drawing.Size(180, 27);
            this.chkCalAturar.TabIndex = 35;
            this.chkCalAturar.UseVisualStyleBackColor = true;
            this.chkCalAturar.CheckedChanged += new System.EventHandler(this.ChkCalAturar_CheckedChanged);
            // 
            // pbIcona
            // 
            this.pbIcona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIcona.Location = new System.Drawing.Point(154, 123);
            this.pbIcona.Margin = new System.Windows.Forms.Padding(4, 12, 12, 12);
            this.pbIcona.MaximumSize = new System.Drawing.Size(48, 49);
            this.pbIcona.MinimumSize = new System.Drawing.Size(48, 49);
            this.pbIcona.Name = "pbIcona";
            this.taula.SetRowSpan(this.pbIcona, 2);
            this.pbIcona.Size = new System.Drawing.Size(48, 49);
            this.pbIcona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcona.TabIndex = 37;
            this.pbIcona.TabStop = false;
            this.pbIcona.DoubleClick += new System.EventHandler(this.PbIcona_DoubleClick);
            // 
            // bCercar
            // 
            this.bCercar.Image = global::Examen.Professor.Properties.Resources.Buscar;
            this.bCercar.Location = new System.Drawing.Point(604, 74);
            this.bCercar.Margin = new System.Windows.Forms.Padding(0);
            this.bCercar.Name = "bCercar";
            this.bCercar.Size = new System.Drawing.Size(36, 35);
            this.bCercar.TabIndex = 38;
            this.bCercar.UseVisualStyleBackColor = true;
            this.bCercar.Click += new System.EventHandler(this.BCercar_Click);
            // 
            // FrmEdicioAplicacio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 274);
            this.Controls.Add(this.taula);
            this.Controls.Add(this.lTitol);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmEdicioAplicacio";
            this.Padding = new System.Windows.Forms.Padding(22, 15, 15, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEdicioAplicacio";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.taula.ResumeLayout(false);
            this.taula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton bDesar;
        private System.Windows.Forms.ToolStripButton bCancelar;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Label lCalAturar;
        private System.Windows.Forms.Label lDescripcio;
        private System.Windows.Forms.Label lNom;
        private System.Windows.Forms.Label lIgnorar;
        private System.Windows.Forms.Label lIcona;
        private System.Windows.Forms.Label lExecutable;
        private System.Windows.Forms.TextBox txtExecutable;
        private System.Windows.Forms.TextBox txtDescripcio;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.CheckBox chkIgnorar;
        private System.Windows.Forms.CheckBox chkCalAturar;
        private System.Windows.Forms.PictureBox pbIcona;
        private System.Windows.Forms.ToolStripButton bDesfer;
        private System.Windows.Forms.Button bCercar;
    }
}