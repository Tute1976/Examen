using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Examen.Professor
{
    public partial class Principal : MetroForm
    {
        private string Codi { get; set; }
        private IPAddress Adreça { get; set; }
        private int Port { get; set; }

        public Principal()
        {
            InitializeComponent();

            Principal_Resize(null, null);
        }

        private void Principal_Resize(object sender, System.EventArgs e)
        {
            CaptionLabels[0].Location = new Point(Width - 330, 64);
            CaptionLabels[1].Location = new Point(Width - 330, 8);
            CaptionLabels[1].Text = "";
        }

        private void Principal_Load(object sender, System.EventArgs e)
        {
            if (Suport.Funcions.Ip.ObtenirCodi(out var codi, out var adreça, out var port))
            {
                Codi = codi;
                Adreça = adreça;
                Port = port;

                CaptionLabels[1].Text = codi;
            }
        }

        private void Principal_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (MessageBoxAdv.Show("Vols finalitzar el programa?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
