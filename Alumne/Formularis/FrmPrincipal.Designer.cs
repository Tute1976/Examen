namespace Examen.Alumne.Formularis
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.imatgesConnecta = new System.Windows.Forms.ImageList();
            this.lCodi = new System.Windows.Forms.Label();
            this.txtCodi = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lNom = new System.Windows.Forms.Label();
            this.panelFons = new System.Windows.Forms.Panel();
            this.bInfo = new System.Windows.Forms.Button();
            this.bTancar = new System.Windows.Forms.Button();
            this.bIniciar = new System.Windows.Forms.Button();
            this.imatge = new System.Windows.Forms.PictureBox();
            this.timerTemps = new System.Windows.Forms.Timer();
            this.timerImatge = new System.Windows.Forms.Timer();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.txtId = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.txtVersio = new System.Windows.Forms.Label();
            this.timerAplicacionsEnUs = new System.Windows.Forms.Timer();
            this.panelFons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imatge)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // imatgesConnecta
            // 
            this.imatgesConnecta.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imatgesConnecta.ImageStream")));
            this.imatgesConnecta.TransparentColor = System.Drawing.Color.Transparent;
            this.imatgesConnecta.Images.SetKeyName(0, "NoConnectat.png");
            this.imatgesConnecta.Images.SetKeyName(1, "Connectant_01.png");
            this.imatgesConnecta.Images.SetKeyName(2, "Connectant_02.png");
            this.imatgesConnecta.Images.SetKeyName(3, "Connectant_03.png");
            this.imatgesConnecta.Images.SetKeyName(4, "Connectant_04.png");
            this.imatgesConnecta.Images.SetKeyName(5, "Connectant_05.png");
            this.imatgesConnecta.Images.SetKeyName(6, "Connectant_06.png");
            this.imatgesConnecta.Images.SetKeyName(7, "Connectant_07.png");
            this.imatgesConnecta.Images.SetKeyName(8, "Connectant_08.png");
            this.imatgesConnecta.Images.SetKeyName(9, "Connectant_09.png");
            this.imatgesConnecta.Images.SetKeyName(10, "Connectant_10.png");
            this.imatgesConnecta.Images.SetKeyName(11, "Connectant_11.png");
            this.imatgesConnecta.Images.SetKeyName(12, "Connectant_12.png");
            this.imatgesConnecta.Images.SetKeyName(13, "Connectant_13.png");
            this.imatgesConnecta.Images.SetKeyName(14, "Connectant_14.png");
            this.imatgesConnecta.Images.SetKeyName(15, "Connectant_15.png");
            this.imatgesConnecta.Images.SetKeyName(16, "Connectant_16.png");
            this.imatgesConnecta.Images.SetKeyName(17, "Connectant_17.png");
            // 
            // lCodi
            // 
            this.lCodi.AutoSize = true;
            this.lCodi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCodi.Location = new System.Drawing.Point(100, 275);
            this.lCodi.Name = "lCodi";
            this.lCodi.Size = new System.Drawing.Size(64, 29);
            this.lCodi.TabIndex = 1;
            this.lCodi.Text = "Codi";
            // 
            // txtCodi
            // 
            this.txtCodi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodi.Location = new System.Drawing.Point(100, 300);
            this.txtCodi.Name = "txtCodi";
            this.txtCodi.Size = new System.Drawing.Size(300, 43);
            this.txtCodi.TabIndex = 1;
            this.txtCodi.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(20, 225);
            this.txtNom.Margin = new System.Windows.Forms.Padding(0);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(455, 43);
            this.txtNom.TabIndex = 0;
            this.txtNom.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // lNom
            // 
            this.lNom.AutoSize = true;
            this.lNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNom.Location = new System.Drawing.Point(25, 200);
            this.lNom.Name = "lNom";
            this.lNom.Size = new System.Drawing.Size(65, 29);
            this.lNom.TabIndex = 3;
            this.lNom.Text = "Nom";
            // 
            // panelFons
            // 
            this.panelFons.BackColor = System.Drawing.Color.White;
            this.panelFons.Controls.Add(this.bInfo);
            this.panelFons.Controls.Add(this.bTancar);
            this.panelFons.Controls.Add(this.bIniciar);
            this.panelFons.Controls.Add(this.txtNom);
            this.panelFons.Controls.Add(this.lNom);
            this.panelFons.Controls.Add(this.txtCodi);
            this.panelFons.Controls.Add(this.lCodi);
            this.panelFons.Controls.Add(this.imatge);
            this.panelFons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFons.Location = new System.Drawing.Point(10, 15);
            this.panelFons.Margin = new System.Windows.Forms.Padding(0);
            this.panelFons.Name = "panelFons";
            this.panelFons.Size = new System.Drawing.Size(490, 437);
            this.panelFons.TabIndex = 7;
            // 
            // bInfo
            // 
            this.bInfo.BackColor = System.Drawing.Color.LightCyan;
            this.bInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInfo.Image = global::Examen.Alumne.Properties.Resources.Informacio_32x32;
            this.bInfo.Location = new System.Drawing.Point(425, 375);
            this.bInfo.Name = "bInfo";
            this.bInfo.Size = new System.Drawing.Size(50, 50);
            this.bInfo.TabIndex = 4;
            this.bInfo.UseVisualStyleBackColor = false;
            this.bInfo.Visible = false;
            this.bInfo.Click += new System.EventHandler(this.BInfo_Click);
            // 
            // bTancar
            // 
            this.bTancar.BackColor = System.Drawing.Color.MistyRose;
            this.bTancar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTancar.Image = global::Examen.Alumne.Properties.Resources.Cancel_32x32;
            this.bTancar.Location = new System.Drawing.Point(300, 375);
            this.bTancar.Name = "bTancar";
            this.bTancar.Size = new System.Drawing.Size(175, 50);
            this.bTancar.TabIndex = 3;
            this.bTancar.Text = "Tancar";
            this.bTancar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bTancar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bTancar.UseVisualStyleBackColor = false;
            this.bTancar.Click += new System.EventHandler(this.BTancar_Click);
            // 
            // bIniciar
            // 
            this.bIniciar.BackColor = System.Drawing.Color.LightYellow;
            this.bIniciar.Enabled = false;
            this.bIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIniciar.Image = global::Examen.Alumne.Properties.Resources.Validation_32x32;
            this.bIniciar.Location = new System.Drawing.Point(20, 375);
            this.bIniciar.Margin = new System.Windows.Forms.Padding(0);
            this.bIniciar.Name = "bIniciar";
            this.bIniciar.Size = new System.Drawing.Size(250, 50);
            this.bIniciar.TabIndex = 2;
            this.bIniciar.Text = "Connectar";
            this.bIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bIniciar.UseVisualStyleBackColor = false;
            this.bIniciar.Click += new System.EventHandler(this.BIniciar_Click);
            // 
            // imatge
            // 
            this.imatge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imatge.Image = global::Examen.Alumne.Properties.Resources.Connectant;
            this.imatge.Location = new System.Drawing.Point(100, 25);
            this.imatge.Margin = new System.Windows.Forms.Padding(0);
            this.imatge.Name = "imatge";
            this.imatge.Size = new System.Drawing.Size(300, 150);
            this.imatge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imatge.TabIndex = 0;
            this.imatge.TabStop = false;
            this.imatge.Tag = "0";
            // 
            // timerTemps
            // 
            this.timerTemps.Interval = 5000;
            this.timerTemps.Tick += new System.EventHandler(this.TimerTemps_Tick);
            // 
            // timerImatge
            // 
            this.timerImatge.Interval = 200;
            this.timerImatge.Tick += new System.EventHandler(this.TimerImatge_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Alumne connectat";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtId.Location = new System.Drawing.Point(20, 0);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(250, 16);
            this.txtId.TabIndex = 8;
            this.txtId.Text = "id";
            this.txtId.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelInfo.Controls.Add(this.txtVersio);
            this.panelInfo.Controls.Add(this.txtId);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInfo.Location = new System.Drawing.Point(10, 452);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.panelInfo.Size = new System.Drawing.Size(490, 16);
            this.panelInfo.TabIndex = 9;
            // 
            // txtVersio
            // 
            this.txtVersio.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtVersio.Location = new System.Drawing.Point(230, 0);
            this.txtVersio.Margin = new System.Windows.Forms.Padding(0);
            this.txtVersio.Name = "txtVersio";
            this.txtVersio.Size = new System.Drawing.Size(250, 16);
            this.txtVersio.TabIndex = 9;
            this.txtVersio.Text = "versio";
            this.txtVersio.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // timerAplicacionsEnUs
            // 
            this.timerAplicacionsEnUs.Interval = 60000;
            this.timerAplicacionsEnUs.Tick += new System.EventHandler(this.TimerAplicacionsEnUs_Tick);
            // 
            // FrmPrincipal
            // 
            this.BorderThickness = 2;
            this.ClientSize = new System.Drawing.Size(510, 483);
            this.ControlBox = false;
            this.Controls.Add(this.panelFons);
            this.Controls.Add(this.panelInfo);
            this.CornerRadius = 10;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StripeWidth = 10;
            this.Text = "Alumne";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Shown += new System.EventHandler(this.FrmPrincipal_Shown);
            this.panelFons.ResumeLayout(false);
            this.panelFons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imatge)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imatge;
        private System.Windows.Forms.ImageList imatgesConnecta;
        private System.Windows.Forms.Label lCodi;
        private System.Windows.Forms.TextBox txtCodi;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lNom;
        private System.Windows.Forms.Button bIniciar;
        private System.Windows.Forms.Button bTancar;
        private System.Windows.Forms.Panel panelFons;
        private System.Windows.Forms.Timer timerTemps;
        private System.Windows.Forms.Timer timerImatge;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button bInfo;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label txtVersio;
        private System.Windows.Forms.Timer timerAplicacionsEnUs;
    }
}

