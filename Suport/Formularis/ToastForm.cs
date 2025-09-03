using System;
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Controls;
using Examen.Suport.Funcions;

namespace Examen.Suport.Formularis
{
    public enum ToastType
    {
        Info,
        Alert,
        Error
    }
    public sealed partial class ToastForm : FormAdv
    {
        public ToastForm(string missatge, int interval, ToastType toastType)
        {
            // Ocultar
            Visible = false;
            Opacity = 0.8;

            InitializeComponent();

            // Ocultar
            Visible = false;
            Opacity = 0.8;

            // Missatge
            lMissatge.Text = missatge;

            // Barra de progrés
            progressBar.Maximum = interval;
            progressBar.Value = 1;
            progressBar.Step = 1;
            progressBar.Hide();

            BackColor = toastType switch
            {
                ToastType.Alert => Color.LightYellow,
                ToastType.Error => Color.LightCoral,
                _ => Color.LightBlue
            };
        }

        private void timerInici_Tick(object sender, EventArgs e)
        {
            timerInici.Stop();
            timerInici.Dispose();

            Helper.Beep();

            progressBar.Show();
            timerBarra.Interval = 1000;
            timerBarra.Start();

            Opacity = 1;
            Visible = true;
        }

        private void timerBarra_Tick(object sender, EventArgs e)
        {
            progressBar.Increment();
            if (progressBar.Value < progressBar.Maximum) 
                return;
            
            timerBarra.Stop();
            timerBarra.Dispose();
            Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var x = Screen.PrimaryScreen.WorkingArea.Width - Width - 10;
            var y = Screen.PrimaryScreen.WorkingArea.Height - Height - 10;
            Location = new Point(x, y);
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToastForm_Shown(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void BCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(lMissatge.Text);
        }
    }
}
