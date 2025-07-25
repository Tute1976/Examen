namespace Examen.Professor.Formularis
{
    partial class FrmAplicacions
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
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAplicacions));
            this.propietats = new System.Windows.Forms.PropertyGrid();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bDesar = new System.Windows.Forms.ToolStripButton();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bImportar = new System.Windows.Forms.ToolStripButton();
            this.bExportar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // propietats
            // 
            this.propietats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propietats.Location = new System.Drawing.Point(5, 5);
            this.propietats.Margin = new System.Windows.Forms.Padding(0);
            this.propietats.Name = "propietats";
            this.propietats.Size = new System.Drawing.Size(337, 320);
            this.propietats.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDesar,
            this.bCancelar,
            this.toolStripSeparator1,
            this.bImportar,
            this.bExportar});
            this.menu.Location = new System.Drawing.Point(352, 5);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(31, 320);
            this.menu.TabIndex = 1;
            this.menu.Text = "toolStrip1";
            // 
            // bDesar
            // 
            this.bDesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDesar.Image = global::Examen.Professor.Properties.Resources.Validation_32x32;
            this.bDesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDesar.Name = "bDesar";
            this.bDesar.Size = new System.Drawing.Size(30, 28);
            this.bDesar.Text = "Desar";
            this.bDesar.Click += new System.EventHandler(this.bDesar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bCancelar.Image = global::Examen.Professor.Properties.Resources.Cancel_32x32;
            this.bCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(30, 28);
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(30, 6);
            // 
            // bImportar
            // 
            this.bImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bImportar.Image = global::Examen.Professor.Properties.Resources.Importar_32x32;
            this.bImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bImportar.Name = "bImportar";
            this.bImportar.Size = new System.Drawing.Size(30, 28);
            this.bImportar.Text = "Importar";
            this.bImportar.Click += new System.EventHandler(this.bImportar_Click);
            // 
            // bExportar
            // 
            this.bExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bExportar.Image = global::Examen.Professor.Properties.Resources.Exportar_32x32;
            this.bExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExportar.Name = "bExportar";
            this.bExportar.Size = new System.Drawing.Size(30, 28);
            this.bExportar.Text = "Exportar";
            this.bExportar.Click += new System.EventHandler(this.bExportar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(342, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 320);
            this.panel1.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.json";
            this.openFileDialog.FileName = "Aplicacions.json";
            this.openFileDialog.Filter = "jSon|*.json|Tots els fitxers|*.*";
            this.openFileDialog.Title = "Importació";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.json";
            this.saveFileDialog.FileName = "Aplicacions.json";
            this.saveFileDialog.Filter = "jSon|*.json|Tots els fitxers|*.*";
            this.saveFileDialog.Title = "Exportació";
            // 
            // FrmAplicacions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.Gray;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.CaptionBarHeight = 64;
            this.CaptionButtonColor = System.Drawing.Color.Gray;
            this.CaptionButtonHoverColor = System.Drawing.Color.Gray;
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = global::Examen.Professor.Properties.Resources.Examen21;
            captionImage1.Location = new System.Drawing.Point(16, 16);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(32, 32);
            this.CaptionImages.Add(captionImage1);
            this.ClientSize = new System.Drawing.Size(388, 330);
            this.ControlBox = false;
            this.Controls.Add(this.propietats);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.MinimizeBox = false;
            this.Name = "FrmAplicacions";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracdor d\'aplicacions";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton bDesar;
        private System.Windows.Forms.ToolStripButton bCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PropertyGrid propietats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bImportar;
        private System.Windows.Forms.ToolStripButton bExportar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}