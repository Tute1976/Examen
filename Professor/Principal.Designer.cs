namespace Examen.Professor
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel1 = new Syncfusion.Windows.Forms.CaptionLabel();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel2 = new Syncfusion.Windows.Forms.CaptionLabel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.split = new System.Windows.Forms.SplitContainer();
            this.llistaHistoric = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerInici = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Margin = new System.Windows.Forms.Padding(0);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.llistaHistoric);
            this.split.Panel2MinSize = 200;
            this.split.Size = new System.Drawing.Size(1477, 791);
            this.split.SplitterDistance = 585;
            this.split.SplitterWidth = 6;
            this.split.TabIndex = 0;
            // 
            // llistaHistoric
            // 
            this.llistaHistoric.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.llistaHistoric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llistaHistoric.FullRowSelect = true;
            this.llistaHistoric.HideSelection = false;
            this.llistaHistoric.Location = new System.Drawing.Point(0, 0);
            this.llistaHistoric.Margin = new System.Windows.Forms.Padding(0);
            this.llistaHistoric.Name = "llistaHistoric";
            this.llistaHistoric.Size = new System.Drawing.Size(3324, 450);
            this.llistaHistoric.TabIndex = 0;
            this.llistaHistoric.UseCompatibleStateImageBehavior = false;
            this.llistaHistoric.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Temps";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Estació";
            this.columnHeader2.Width = 160;
            // 
            // timerInici
            // 
            this.timerInici.Enabled = true;
            this.timerInici.Tick += new System.EventHandler(this.TimerInici_Tick);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.CaptionBarHeight = 96;
            this.CaptionButtonColor = System.Drawing.Color.Gray;
            this.CaptionButtonHoverColor = System.Drawing.Color.Gray;
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = global::Examen.Professor.Properties.Resources.Examen2;
            captionImage1.Location = new System.Drawing.Point(18, 12);
            captionImage1.Name = "Logo";
            captionImage1.Size = new System.Drawing.Size(64, 64);
            this.CaptionImages.Add(captionImage1);
            captionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel1.Location = new System.Drawing.Point(700, 64);
            captionLabel1.Name = "TxtCodi";
            captionLabel1.Text = "Codi";
            captionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel2.Location = new System.Drawing.Point(700, 8);
            captionLabel2.Name = "Codi";
            captionLabel2.Size = new System.Drawing.Size(500, 64);
            captionLabel2.Text = "XXXXX";
            this.CaptionLabels.Add(captionLabel1);
            this.CaptionLabels.Add(captionLabel2);
            this.ClientSize = new System.Drawing.Size(1477, 791);
            this.Controls.Add(this.split);
            this.DropShadow = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(237)))));
            this.Name = "Principal";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ListView llistaHistoric;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Timer timerInici;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

