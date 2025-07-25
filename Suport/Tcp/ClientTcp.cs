using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Examen.Suport.Tcp
{
    public static class ClientTcp
    {
        public static string EnviarEstat(AdreçaPort adreçaPort, EstacioAlumne estacioAlumne, List<AplicacioEnUs> aplicacionsEnUs, TipusMissatge estat, Action pitar, Action bloquejar, Action aturar, Action fiServidor, string text = null)
        {
            try
            {
                using var client = new TcpClient();
                client.NoDelay = true; // Disable Nagle's algorithm for low latency
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.Connect(adreçaPort.Adreça, adreçaPort.Port);

                var stream = client.GetStream();

                estacioAlumne ??= new EstacioAlumne("", Guid.Empty);

                var estatText = $"{estat}:{estacioAlumne.Serialitzar().ToBase64()}:{text}:{aplicacionsEnUs.Serialitzar().ToBase64()}".CompressToBase64();
                var missatge = Encoding.UTF8.GetBytes(estatText);
                stream.Write(missatge, 0, missatge.Length);

                var resposta = new byte[8192];
                var bytesLlegits = stream.Read(resposta, 0, resposta.Length);
                var respostaText = Encoding.UTF8.GetString(resposta, 0, bytesLlegits);
                respostaText = respostaText.DecompressFromBase64();

                Trace.WriteLine($"Resposta del servidor: {respostaText}");

                var rt = respostaText.Split('^');
                if (rt.Length > 1)
                {
                    if (bool.Parse(rt[1]))
                        pitar.Invoke();
                    if (bool.Parse(rt[2]))
                        bloquejar.Invoke();
                    if (bool.Parse(rt[3]))
                        aturar.Invoke();
                    if (bool.Parse(rt[4]))
                        fiServidor.Invoke();
                }

                return rt.First();
            }
            catch (SocketException exSocket)
            {
                if (estat != TipusMissatge.FiServidor)
                    MostraError(exSocket, estat);
            }
            catch (InvalidOperationException exInvalidOperation)
            {
                if (estat != TipusMissatge.FiServidor)
                    MostraError(exInvalidOperation, estat);
            }
            catch (IOException exIo)
            {
                if (estat != TipusMissatge.FiServidor)
                    MostraError(exIo, estat);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return null;
        }

        private static void MostraError(Exception ex, TipusMissatge estat)
        {
            var nl = Environment.NewLine;
            var msg = $@"No es pot establir connexió amb el servidor{nl}{nl}Error:{ex.Message}{nl}{nl}Detalls: {ex.StackTrace}";

            Helper.ShowToast(msg, 5);
            msg.Mostrar(MessageBoxIcon.Exclamation);

            if (estat != TipusMissatge.Prova)
                Application.Exit();
        }
    }
}