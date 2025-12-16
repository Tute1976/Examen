namespace Examen.Professor.Formularis
{
    partial class FrmEdicioCodi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdicioCodi));
            this.lTitol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bDesar = new System.Windows.Forms.ToolStripButton();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.bDesfer = new System.Windows.Forms.ToolStripButton();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.lCodi = new System.Windows.Forms.Label();
            this.txtCodi = new System.Windows.Forms.TextBox();
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
            this.lTitol.Text = "Canvi del codi";
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
            this.taula.Controls.Add(this.lCodi, 0, 0);
            this.taula.Controls.Add(this.txtCodi, 1, 0);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Location = new System.Drawing.Point(22, 64);
            this.taula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taula.Name = "taula";
            this.taula.RowCount = 2;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.Size = new System.Drawing.Size(640, 150);
            this.taula.TabIndex = 11;
            // 
            // lCodi
            // 
            this.lCodi.BackColor = System.Drawing.Color.Transparent;
            this.lCodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCodi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCodi.Location = new System.Drawing.Point(4, 0);
            this.lCodi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCodi.Name = "lCodi";
            this.lCodi.Size = new System.Drawing.Size(142, 37);
            this.lCodi.TabIndex = 0;
            this.lCodi.Text = "Codi";
            this.lCodi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodi
            // 
            this.txtCodi.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtCodi, 4);
            this.txtCodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodi.Location = new System.Drawing.Point(154, 5);
            this.txtCodi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodi.Name = "txtCodi";
            this.txtCodi.Size = new System.Drawing.Size(482, 26);
            this.txtCodi.TabIndex = 26;
            this.txtCodi.TextChanged += new System.EventHandler(this.TxtNom_TextChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.exe";
            this.openFileDialog.Filter = "*.exe|Executable";
            this.openFileDialog.Title = "Executables";
            // 
            // FrmEdicioCodi
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
            this.Name = "FrmEdicioCodi";
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
        private System.Windows.Forms.Label lCodi;
        private System.Windows.Forms.TextBox txtCodi;
        private System.Windows.Forms.ToolStripButton bDesfer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}