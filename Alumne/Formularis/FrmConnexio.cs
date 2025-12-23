using Examen.Suport.Controls;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                Shown -= FrmConnexio_Shown;

                await FluxConnexioAsync();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private Task FluxConnexioAsync()
        {
            try
            {
                var toastForm = new ToastForm(lMissatge.Text, 5, ToastType.Info);
                Helper.Invocar(toastForm, async void () =>
                {
                    try
                    {
                        toastForm.Show();

                        var ok = await Task.Run(() => _connexio());

                        if (ok)
                        {
                            DialogResult = DialogResult.OK;
                            toastForm.Close();
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
                    catch (Exception)
                    {
                        // ignore
                    }
                });
            }
            catch (InvalidOperationException)
            {
                // ignore
            }
            catch (Exception)
            {
                // ignore
            }

            return Task.CompletedTask;
        }
    }
}