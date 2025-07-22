using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Examen.Suport.Tcp
{
    public static class ClientTcp
    {
        public static string EnviarEstat(AdreçaPort adreçaPort, EstacioAlumne estacioAlumne, TipusMissatge estat, out bool pitar, out bool bloquejar, out bool aturar, string text = null)
        {
            pitar = false;
            bloquejar = false;
            aturar = false;

            var nl = Environment.NewLine;

            try
            {
                using var client = new TcpClient();
                client.ReceiveTimeout = 5 * 1000;
                client.SendTimeout = 5 * 1000;
                client.NoDelay = true; // Disable Nagle's algorithm for low latency
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
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

                var rt = respostaText.Split('^');
                pitar = bool.Parse(rt[1]);
                bloquejar = bool.Parse(rt[2]);
                aturar = bool.Parse(rt[3]);

                return rt.First();
            }
            catch (SocketException exSocket)
            {
                var msg = $@"No es pot establir connexió amb el servidor{nl}{nl}Error:{nl}{exSocket.Message}";
                msg.Mostrar(MessageBoxIcon.Exclamation);

                if (estat != TipusMissatge.Prova)
                    Application.Exit();
            }
            catch (InvalidOperationException exInvalidOperation)
            {
                var msg = $@"No es pot establir connexió amb el servidor{nl}{nl}Error:{nl}{exInvalidOperation.Message}";
                msg.Mostrar(MessageBoxIcon.Exclamation);

                if (estat != TipusMissatge.Prova)
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