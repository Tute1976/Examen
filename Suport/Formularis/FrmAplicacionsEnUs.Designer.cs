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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAplicacionsEnUs));
            this.propietats = new System.Windows.Forms.PropertyGrid();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.bExportar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // propietats
            // 
            this.propietats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propietats.Location = new System.Drawing.Point(15, 10);
            this.propietats.Margin = new System.Windows.Forms.Padding(0);
            this.propietats.Name = "propietats";
            this.propietats.Size = new System.Drawing.Size(317, 305);
            this.propietats.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCancelar,
            this.bExportar});
            this.menu.Location = new System.Drawing.Point(342, 10);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(36, 305);
            this.menu.TabIndex = 1;
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
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bExportar
            // 
            this.bExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bExportar.Image = global::Examen.Suport.Properties.Resources.Exportar_32x32;
            this.bExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExportar.Name = "bExportar";
            this.bExportar.Size = new System.Drawing.Size(35, 36);
            this.bExportar.Text = "Exportar";
            this.bExportar.Click += new System.EventHandler(this.bExportar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(332, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 305);
            this.panel1.TabIndex = 2;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.json";
            this.saveFileDialog.FileName = "AplicacionsEnUs.json";
            this.saveFileDialog.Filter = "jSon|*.json|Tots els fitxers|*.*";
            this.saveFileDialog.Title = "Exportació";
            // 
            // FrmAplicacionsEnUs
            // 
            this.ClientSize = new System.Drawing.Size(388, 330);
            this.ControlBox = false;
            this.Controls.Add(this.propietats);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton bCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PropertyGrid propietats;
        private System.Windows.Forms.ToolStripButton bExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}