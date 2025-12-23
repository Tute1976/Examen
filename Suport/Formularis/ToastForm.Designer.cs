using System;

namespace Examen.Suport.Formularis
{
    sealed partial class ToastForm
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
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch
            {
                // ignore
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToastForm));
            this.lMissatge = new System.Windows.Forms.Label();
            this.timerInici = new System.Windows.Forms.Timer(this.components);
            this.timerBarra = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.bCancelar = new System.Windows.Forms.ToolStripButton();
            this.bCopiar = new System.Windows.Forms.ToolStripButton();
            this.lTitol = new System.Windows.Forms.Label();
            this.timerFi = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lMissatge
            // 
            this.lMissatge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMissatge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMissatge.Location = new System.Drawing.Point(22, 64);
            this.lMissatge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMissatge.Name = "lMissatge";
            this.lMissatge.Size = new System.Drawing.Size(657, 263);
            this.lMissatge.TabIndex = 0;
            this.lMissatge.Text = ".";
            this.lMissatge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerInici
            // 
            this.timerInici.Enabled = true;
            this.timerInici.Tick += new System.EventHandler(this.TimerInici_Tick);
            // 
            // timerBarra
            // 
            this.timerBarra.Interval = 1000;
            this.timerBarra.Tick += new System.EventHandler(this.TimerBarra_Tick);
            // 
            // progressBar
            // 
            this.progressBar.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressBar.BackSegments = false;
            this.progressBar.CustomText = null;
            this.progressBar.CustomWaitingRender = false;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.progressBar.ForegroundImage = null;
            this.progressBar.Location = new System.Drawing.Point(22, 327);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressBar.Name = "progressBar";
            this.progressBar.SegmentWidth = 10;
            this.progressBar.Size = new System.Drawing.Size(657, 35);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            this.progressBar.TextStyle = Syncfusion.Windows.Forms.Tools.ProgressBarTextStyles.Custom;
            this.progressBar.ThemeName = "Constant";
            this.progressBar.Visible = false;
            this.progressBar.WaitingGradientWidth = 400;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(679, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 347);
            this.panel1.TabIndex = 4;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCancelar,
            this.bCopiar});
            this.menu.Location = new System.Drawing.Point(694, 15);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(34, 347);
            this.menu.TabIndex = 3;
            // 
            // bCancelar
            // 
            this.bCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bCancelar.Image = global::Examen.Suport.Properties.Resources.Cancel_32x32;
            this.bCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(33, 28);
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // bCopiar
            // 
            this.bCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bCopiar.Image = global::Examen.Suport.Properties.Resources.Copiar_32x32;
            this.bCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCopiar.Name = "bCopiar";
            this.bCopiar.Size = new System.Drawing.Size(33, 28);
            this.bCopiar.Text = "Copiar missatge";
            this.bCopiar.Click += new System.EventHandler(this.BCopiar_Click);
            // 
            // lTitol
            // 
            this.lTitol.Dock = System.Windows.Forms.DockStyle.Top;
            this.lTitol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitol.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lTitol.Location = new System.Drawing.Point(22, 15);
            this.lTitol.Margin = new System.Windows.Forms.Padding(0);
            this.lTitol.Name = "lTitol";
            this.lTitol.Size = new System.Drawing.Size(657, 49);
            this.lTitol.TabIndex = 7;
            this.lTitol.Text = "Informació del programa d\'Examens";
            // 
            // timerFi
            // 
            this.timerFi.Tick += new System.EventHandler(this.TimerFi_Tick);
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(750, 385);
            this.Controls.Add(this.lMissatge);
            this.Controls.Add(this.lTitol);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(-10000, -10000);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 385);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 385);
            this.Name = "ToastForm";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(22, 15, 22, 23);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Missatge";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.ToastForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lMissatge;
        private System.Windows.Forms.Timer timerInici;
        private System.Windows.Forms.Timer timerBarra;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton bCancelar;
        private System.Windows.Forms.Label lTitol;
        private System.Windows.Forms.ToolStripButton bCopiar;
        private System.Windows.Forms.Timer timerFi;
    }
}