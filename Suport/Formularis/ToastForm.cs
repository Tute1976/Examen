using System;
using System.Drawing;
using System.Windows.Forms;

namespace Examen.Suport.Formularis
{
    public partial class ToastForm : Form
    {
        private readonly Timer _timer;

        public ToastForm(string missatge)
        {
            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            BackColor = Color.LightYellow;
            ShowInTaskbar = false;
            TopMost = true;
            Size = new Size(300, 80);

            // Ubicació a la cantonada inferior dreta
            var x = Screen.PrimaryScreen.WorkingArea.Width - Width - 10;
            var y = Screen.PrimaryScreen.WorkingArea.Height - Height - 10;
            Location = new Point(x, y);

            // Missatge
            var lblMissatge = new Label();
            lblMissatge.Text = missatge;
            lblMissatge.Dock = DockStyle.Fill;
            lblMissatge.TextAlign = ContentAlignment.MiddleCenter;
            lblMissatge.Font = new Font("Segoe UI", 10);
            Controls.Add(lblMissatge);

            // Temporitzador per tancar
            _timer = new Timer();
            _timer.Interval = 5000; // 5 segons
            _timer.Tick += (_, e) =>
            {
                _timer.Stop();
                Close();
            };
        }
        
        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _timer.Start();

            Console.Beep(750, 1000);
        }
    }
}
