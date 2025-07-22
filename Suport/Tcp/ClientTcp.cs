using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using Syncfusion.Windows.Forms;

namespace Examen.Suport.Tcp
{
    public static class ClientTcp
    {
        public static string EnviarEstat(AdreçaPort adreçaPort, EstacioAlumne estacioAlumne, TipusMissatge estat, string text = null)
        {
            try
            {
                using var client = new TcpClient();
                client.Connect(adreçaPort.Adreça, adreçaPort.Port);

                var stream = client.GetStream();

                estacioAlumne ??= new EstacioAlumne("", Guid.Empty);

                var estatText = $"{estat}:{estacioAlumne.Serialitzar().ToBase64()}:{text}";
                var missatge = Encoding.UTF8.GetBytes(estatText.ToBase64());
                stream.Write(missatge, 0, missatge.Length);

                var resposta = new byte[1024];
                var bytesLlegits = stream.Read(resposta, 0, resposta.Length);
                var respostaText = Encoding.UTF8.GetString(resposta, 0, bytesLlegits);
                respostaText = respostaText.FromBase64();

                Trace.WriteLine($"Resposta del servidor: {respostaText}");

                return respostaText;
            }
            catch (SocketException exSocket)
            {
                MessageBoxAdv.Show(exSocket.Message, Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
                ex.Mostrar(false);
            }

            return null;
        }
    }
}