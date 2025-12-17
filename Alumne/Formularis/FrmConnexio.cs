using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen.Suport.Controls;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;

namespace Examen.Alumne.Formularis
{
    public partial class FrmConnexio : FormAdv
    {
        private readonly Func<bool> _connexio;

        public FrmConnexio(Func<bool> connexio)
        {
            _connexio = connexio ?? throw new ArgumentNullException(nameof(connexio));
            InitializeComponent();

            Shown += FrmConnexio_Shown;
        }

        private async void FrmConnexio_Shown(object sender, EventArgs e)
        {
            Shown -= FrmConnexio_Shown;

            await FluxConnexioAsync();
        }

        private async Task FluxConnexioAsync()
        {
            try
            {
                using var frm = new ToastForm(lMissatge.Text, 5, ToastType.Info);

                var ok = await Task.Run(() => _connexio());

                if (ok)
                {
                    DialogResult = DialogResult.OK;
                    frm.Hide();
                }
                else
                {
                    "No s'ha pogut connectar amb el servidor. L'aplicació es tancarà."
                        .ShowToast(5, ToastType.Error);
                    await Task.Delay(5000);

                    DialogResult = DialogResult.Cancel;
                }

                Close();
            }
            catch (InvalidOperationException)
            {
                // ignore
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}