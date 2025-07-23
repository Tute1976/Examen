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

            string[] rt;

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

                var estatText = $"{estat}:{estacioAlumne.Serialitzar().ToBase64()}:{text}".CompressToBase64();
                var missatge = Encoding.UTF8.GetBytes(estatText);
                stream.Write(missatge, 0, missatge.Length);

                var resposta = new byte[8192];
                var bytesLlegits = stream.Read(resposta, 0, resposta.Length);
                var respostaText = Encoding.UTF8.GetString(resposta, 0, bytesLlegits);
                respostaText = respostaText.DecompressFromBase64();

                Trace.WriteLine($"Resposta del servidor: {respostaText}");

                rt = respostaText.Split('^');
                if (rt.Length > 1)
                {
                    pitar = bool.Parse(rt[1]);
                    bloquejar = bool.Parse(rt[2]);
                    aturar = bool.Parse(rt[3]);
                }

                return rt.First();
            }
            catch (SocketException exSocket)
            {
                var msg = $@"No es pot establir connexió amb el servidor\n\nError:\n{exSocket.Message}";
                msg.Mostrar(MessageBoxIcon.Exclamation);

                if (estat != TipusMissatge.Prova)
                    Application.Exit();
            }
            catch (InvalidOperationException exInvalidOperation)
            {
                var msg = $@"No es pot establir connexió amb el servidor\n\nError:\n{exInvalidOperation.Message}";
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