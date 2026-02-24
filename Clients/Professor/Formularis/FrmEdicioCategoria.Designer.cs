namespace Examen.Professor.Formularis
{
    partial class FrmEdicioCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdicioCategoria));
            this.lTitol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bDesar = new System.Windows.Forms.ToolStripButton();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.bDesfer = new System.Windows.Forms.ToolStripButton();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.chkIgnorar = new System.Windows.Forms.CheckBox();
            this.txtDescripcio = new System.Windows.Forms.TextBox();
            this.lIgnorar = new System.Windows.Forms.Label();
            this.lCalAturar = new System.Windows.Forms.Label();
            this.lDescripcio = new System.Windows.Forms.Label();
            this.lNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.chkCalAturar = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menu.SuspendLayout();
            this.taula.SuspendLayout();
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
            this.lTitol.Text = "Categoria";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(662, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 199);
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
            this.menu.Size = new System.Drawing.Size(36, 199);
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
            this.taula.Controls.Add(this.chkIgnorar, 3, 3);
            this.taula.Controls.Add(this.txtDescripcio, 1, 1);
            this.taula.Controls.Add(this.lIgnorar, 2, 3);
            this.taula.Controls.Add(this.lCalAturar, 2, 2);
            this.taula.Controls.Add(this.lDescripcio, 0, 1);
            this.taula.Controls.Add(this.lNom, 0, 0);
            this.taula.Controls.Add(this.txtNom, 1, 0);
            this.taula.Controls.Add(this.chkCalAturar, 3, 2);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Location = new System.Drawing.Point(22, 64);
            this.taula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taula.Name = "taula";
            this.taula.RowCount = 5;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.taula.Size = new System.Drawing.Size(640, 150);
            this.taula.TabIndex = 11;
            // 
            // chkIgnorar
            // 
            this.chkIgnorar.AutoSize = true;
            this.taula.SetColumnSpan(this.chkIgnorar, 2);
            this.chkIgnorar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkIgnorar.Location = new System.Drawing.Point(456, 116);
            this.chkIgnorar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnorar.Name = "chkIgnorar";
            this.chkIgnorar.Size = new System.Drawing.Size(180, 27);
            this.chkIgnorar.TabIndex = 36;
            this.chkIgnorar.UseVisualStyleBackColor = true;
            this.chkIgnorar.CheckedChanged += new System.EventHandler(this.ChkIgnorar_CheckedChanged);
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
            // lIgnorar
            // 
            this.lIgnorar.BackColor = System.Drawing.Color.Transparent;
            this.lIgnorar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lIgnorar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIgnorar.Location = new System.Drawing.Point(306, 111);
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
            this.lCalAturar.Location = new System.Drawing.Point(306, 74);
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
            this.chkCalAturar.Location = new System.Drawing.Point(456, 79);
            this.chkCalAturar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCalAturar.Name = "chkCalAturar";
            this.chkCalAturar.Size = new System.Drawing.Size(180, 27);
            this.chkCalAturar.TabIndex = 35;
            this.chkCalAturar.UseVisualStyleBackColor = true;
            this.chkCalAturar.CheckedChanged += new System.EventHandler(this.ChkCalAturar_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.exe";
            this.openFileDialog.Filter = "*.exe|Executable";
            this.openFileDialog.Title = "Executables";
            // 
            // FrmEdicioCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 237);
            this.Controls.Add(this.taula);
            this.Controls.Add(this.lTitol);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmEdicioCategoria";
            this.Padding = new System.Windows.Forms.Padding(22, 15, 15, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEdicioAplicacio";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.taula.ResumeLayout(false);
            this.taula.PerformLayout();
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
        private System.Windows.Forms.TextBox txtDescripcio;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.CheckBox chkIgnorar;
        private System.Windows.Forms.CheckBox chkCalAturar;
        private System.Windows.Forms.ToolStripButton bDesfer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}