namespace Examen.Professor.Formularis
{
    partial class FrmInformacio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformacio));
            this.lTitol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFabricant = new System.Windows.Forms.TextBox();
            this.txtUsuari = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lIcona = new System.Windows.Forms.Label();
            this.lExecutable = new System.Windows.Forms.Label();
            this.lDescripcio = new System.Windows.Forms.Label();
            this.lEstacio = new System.Windows.Forms.Label();
            this.txtEstacio = new System.Windows.Forms.TextBox();
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
            this.lTitol.Text = "Informació de l\'estació";
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
            this.bCancelar});
            this.menu.Location = new System.Drawing.Point(677, 15);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(36, 236);
            this.menu.TabIndex = 8;
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
            // taula
            // 
            this.taula.ColumnCount = 5;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.taula.Controls.Add(this.txtModel, 1, 4);
            this.taula.Controls.Add(this.label1, 0, 4);
            this.taula.Controls.Add(this.txtFabricant, 1, 3);
            this.taula.Controls.Add(this.txtUsuari, 1, 2);
            this.taula.Controls.Add(this.txtNom, 1, 1);
            this.taula.Controls.Add(this.lIcona, 0, 3);
            this.taula.Controls.Add(this.lExecutable, 0, 2);
            this.taula.Controls.Add(this.lDescripcio, 0, 1);
            this.taula.Controls.Add(this.lEstacio, 0, 0);
            this.taula.Controls.Add(this.txtEstacio, 1, 0);
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
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtModel, 4);
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModel.Location = new System.Drawing.Point(154, 153);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(482, 26);
            this.txtModel.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 37);
            this.label1.TabIndex = 30;
            this.label1.Text = "Model";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFabricant
            // 
            this.txtFabricant.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtFabricant, 4);
            this.txtFabricant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFabricant.Location = new System.Drawing.Point(154, 116);
            this.txtFabricant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFabricant.Name = "txtFabricant";
            this.txtFabricant.ReadOnly = true;
            this.txtFabricant.Size = new System.Drawing.Size(482, 26);
            this.txtFabricant.TabIndex = 29;
            // 
            // txtUsuari
            // 
            this.txtUsuari.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtUsuari, 4);
            this.txtUsuari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuari.Location = new System.Drawing.Point(154, 79);
            this.txtUsuari.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuari.Name = "txtUsuari";
            this.txtUsuari.ReadOnly = true;
            this.txtUsuari.Size = new System.Drawing.Size(482, 26);
            this.txtUsuari.TabIndex = 28;
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtNom, 4);
            this.txtNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNom.Location = new System.Drawing.Point(154, 42);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNom.Name = "txtNom";
            this.txtNom.ReadOnly = true;
            this.txtNom.Size = new System.Drawing.Size(482, 26);
            this.txtNom.TabIndex = 27;
            // 
            // lIcona
            // 
            this.lIcona.BackColor = System.Drawing.Color.Transparent;
            this.lIcona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lIcona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIcona.Location = new System.Drawing.Point(4, 111);
            this.lIcona.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIcona.Name = "lIcona";
            this.lIcona.Size = new System.Drawing.Size(142, 37);
            this.lIcona.TabIndex = 25;
            this.lIcona.Text = "Fabricant";
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
            this.lExecutable.Text = "Usuari";
            this.lExecutable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lDescripcio.Text = "Nom";
            this.lDescripcio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lEstacio
            // 
            this.lEstacio.BackColor = System.Drawing.Color.Transparent;
            this.lEstacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lEstacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEstacio.Location = new System.Drawing.Point(4, 0);
            this.lEstacio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lEstacio.Name = "lEstacio";
            this.lEstacio.Size = new System.Drawing.Size(142, 37);
            this.lEstacio.TabIndex = 0;
            this.lEstacio.Text = "Estació";
            this.lEstacio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEstacio
            // 
            this.txtEstacio.BackColor = System.Drawing.Color.White;
            this.taula.SetColumnSpan(this.txtEstacio, 4);
            this.txtEstacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstacio.Location = new System.Drawing.Point(154, 5);
            this.txtEstacio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstacio.Name = "txtEstacio";
            this.txtEstacio.ReadOnly = true;
            this.txtEstacio.Size = new System.Drawing.Size(482, 26);
            this.txtEstacio.TabIndex = 26;
            // 
            // FrmInformacio
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
            this.Name = "FrmInformacio";
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
        private System.Windows.Forms.ToolStripButton bCancelar;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Label lDescripcio;
        private System.Windows.Forms.Label lEstacio;
        private System.Windows.Forms.Label lIcona;
        private System.Windows.Forms.Label lExecutable;
        private System.Windows.Forms.TextBox txtEstacio;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFabricant;
        private System.Windows.Forms.TextBox txtUsuari;
        private System.Windows.Forms.TextBox txtNom;
    }
}