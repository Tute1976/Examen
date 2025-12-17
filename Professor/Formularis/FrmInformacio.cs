using Examen.Suport.Classes;
using Examen.Suport.Controls;
using System;
using System.Windows.Forms;

namespace Examen.Professor.Formularis
{
    public partial class FrmInformacio : FormAdv
    {
        private EstacioAlumne EstacioAlumne { get; set; }

        public FrmInformacio(EstacioAlumne estacioAlumne)
        {
            InitializeComponent();

            EstacioAlumne = estacioAlumne;
            OmpleCamps();
        }


        private void OmpleCamps()
        {
            txtEstacio.Text = EstacioAlumne.Estacio;
            txtNom.Text = EstacioAlumne.Nom;
            txtUsuari.Text = EstacioAlumne.Usuari;
            txtFabricant.Text = EstacioAlumne.Fabricant;
            txtModel.Text = EstacioAlumne.Model;
        }
        
        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
