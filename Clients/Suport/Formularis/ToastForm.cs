using System;
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Controls;

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

            // Temporitzador
            timerFi.Interval = Convert.ToInt32(interval * 1000 * 1.5);
            timerFi.Enabled = true;
            timerFi.Start();

            BackColor = toastType switch
            {
                ToastType.Alert => Color.LightYellow,
                ToastType.Error => Color.LightCoral,
                _ => Color.LightBlue
            };
        }

        private void TimerInici_Tick(object sender, EventArgs e)
        {
            timerInici.Stop();
            timerInici.Dispose();

            progressBar.Show();
            timerBarra.Interval = 1000;
            timerBarra.Start();

            Opacity = 1;
            Visible = true;
        }

        private void TimerBarra_Tick(object sender, EventArgs e)
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

        private void TimerFi_Tick(object sender, EventArgs e)
        {
            timerInici.Stop();
            timerInici.Dispose();

            timerFi.Stop();
            timerFi.Dispose();

            timerBarra.Stop();
            timerBarra.Dispose();

            Close();
        }
    }
}
