using Syncfusion.Windows.Forms;
using System; 
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Funcions;

namespace Examen.Suport.Formularis
{
    public sealed partial class ToastForm : MetroForm
    {
        public ToastForm(string missatge, int interval)
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
    }
}
