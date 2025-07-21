using System;
using System.Drawing;
using System.Windows.Forms;
using Examen.Suport.Classes;

namespace Examen.Suport.Controls
{
    public partial class InfoEstacio : UserControl
    {
        public EstacioAlumne EstacioAlumne { get; set; }

        public string Estat
        {
            get => txtEstat.Text;
            set => txtEstat.Text = value;
        }

        public DateTime DataInci
        {
            get => DateTime.Parse(txtDataInci.Text);
            set => txtDataInci.Text = $@"{value:G}";
        }

        public DateTime DataConnexio
        {
            get => DateTime.Parse(txtDataConnexio.Text);
            set => txtDataConnexio.Text = $@"{value:G}";
        }

        public int Imatge
        {
            set => imatge.Image = imatges.Images[value];
        }

        public Color BackgroundColor
        {
            get => taula.BackColor; 
            set => taula.BackColor = value;
        }

        public InfoEstacio(EstacioAlumne estacioAlumne)
        {
            InitializeComponent();

            imatge.Image = imatges.Images[0];

            gb.Text = estacioAlumne.Nom;
            txtEstacio.Text = $@"{estacioAlumne.Estacio} (Id: {estacioAlumne.Id})";
            txtInformacio.Text = $@"{estacioAlumne.Fabricant} / {estacioAlumne.Model}";
            txtDataInci.Text = $@"{estacioAlumne.DataInici:G}";
            txtDataConnexio.Text = $@"{estacioAlumne.DataDarreraConnexio:G}";
            txtEstat.Text = "";
        }
    }
}
