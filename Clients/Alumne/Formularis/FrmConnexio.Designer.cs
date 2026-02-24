namespace Examen.Alumne.Formularis
{
    partial class FrmConnexio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnexio));
            this.lTitol = new System.Windows.Forms.Label();
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.lMissatge = new System.Windows.Forms.Label();
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
            this.lTitol.Size = new System.Drawing.Size(691, 49);
            this.lTitol.TabIndex = 10;
            this.lTitol.Text = "Connexió";
            // 
            // taula
            // 
            this.taula.ColumnCount = 1;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.taula.Controls.Add(this.lMissatge, 0, 0);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Location = new System.Drawing.Point(22, 64);
            this.taula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taula.Name = "taula";
            this.taula.RowCount = 2;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.Size = new System.Drawing.Size(691, 150);
            this.taula.TabIndex = 11;
            // 
            // lMissatge
            // 
            this.lMissatge.BackColor = System.Drawing.Color.Transparent;
            this.lMissatge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMissatge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMissatge.Location = new System.Drawing.Point(4, 0);
            this.lMissatge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMissatge.Name = "lMissatge";
            this.lMissatge.Size = new System.Drawing.Size(683, 37);
            this.lMissatge.TabIndex = 0;
            this.lMissatge.Text = "Connectant amb el servidor ...";
            this.lMissatge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmConnexio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 237);
            this.Controls.Add(this.taula);
            this.Controls.Add(this.lTitol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConnexio";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(22, 15, 15, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEdicioAplicacio";
            this.taula.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lTitol;
        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Label lMissatge;
    }
}