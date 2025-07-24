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
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lMissatge
            // 
            this.lMissatge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMissatge.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMissatge.Location = new System.Drawing.Point(0, 0);
            this.lMissatge.Name = "lMissatge";
            this.lMissatge.Size = new System.Drawing.Size(488, 141);
            this.lMissatge.TabIndex = 0;
            this.lMissatge.Text = ".";
            this.lMissatge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerInici
            // 
            this.timerInici.Enabled = true;
            this.timerInici.Tick += new System.EventHandler(this.timerInici_Tick);
            // 
            // timerBarra
            // 
            this.timerBarra.Interval = 1000;
            this.timerBarra.Tick += new System.EventHandler(this.timerBarra_Tick);
            // 
            // progressBar
            // 
            this.progressBar.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressBar.BackSegments = false;
            this.progressBar.CustomText = null;
            this.progressBar.CustomWaitingRender = false;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.progressBar.ForegroundImage = null;
            this.progressBar.Location = new System.Drawing.Point(0, 141);
            this.progressBar.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressBar.Name = "progressBar";
            this.progressBar.SegmentWidth = 10;
            this.progressBar.Size = new System.Drawing.Size(488, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            this.progressBar.TextStyle = Syncfusion.Windows.Forms.Tools.ProgressBarTextStyles.Custom;
            this.progressBar.ThemeName = "Constant";
            this.progressBar.Visible = false;
            this.progressBar.WaitingGradientWidth = 400;
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.CaptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(488, 164);
            this.Controls.Add(this.lMissatge);
            this.Controls.Add(this.progressBar);
            this.DropShadow = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "ToastForm";
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Missatge";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lMissatge;
        private System.Windows.Forms.Timer timerInici;
        private System.Windows.Forms.Timer timerBarra;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressBar;
    }
}