using Examen.Suport.Classes;
using Examen.Suport.Controls;

namespace Examen.Professor.Formularis
{
    public partial class FrmEdicioAplicacio : FormAdv
    {
        private Node _node;

        public FrmEdicioAplicacio()
        {
            InitializeComponent();
        }

        public FrmEdicioAplicacio(Node node)
        {
            InitializeComponent();

            _node = node;
        }

        private void BCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
