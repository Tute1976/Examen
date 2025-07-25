using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Examen.Suport.Tcp
{
    public static class ServidorTcp
    {
        private static TcpListener _listener;
        private static Func<TipusMissatge, EstacioAlumne, string> _gestorEstat;
        private static Action<TipusMissatge, EstacioAlumne, string, List<AplicacioEnUs>> _callbackFinalitzacio;
        private static bool _aturat;

        public static void Iniciar(AdreçaPort adreçaPort, Func<TipusMissatge, EstacioAlumne, string> gestorEstat, Action<TipusMissatge, EstacioAlumne, string, List<AplicacioEnUs>> callback)
        {
            _gestorEstat = gestorEstat;
            _callbackFinalitzacio = callback;
            _listener = new TcpListener(adreçaPort.ToIpEndPoint())
            {
                Server =
                {
                    NoDelay = true // Disable Nagle's algorithm for low latency
                }
            };
            _listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _listener.Start();
            _listener.BeginAcceptTcpClient(AcceptCallback, null);

            Trace.WriteLine($"Servidor iniciat a {adreçaPort.Adreça}:{adreçaPort.Port}");
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                var client = _listener.EndAcceptTcpClient(ar);
                var stream = client.GetStream();

                var buffer = new byte[8192];
                var bytesLlegits = stream.Read(buffer, 0, buffer.Length);
                var textRebut = Encoding.UTF8.GetString(buffer, 0, bytesLlegits);
                textRebut = textRebut.DecompressFromBase64();
                var tt = textRebut.Split(':');
                var estatRebutText = tt.First();
                var estacioAlumne = tt[1].FromBase64().Deserialitzar<EstacioAlumne>();
                textRebut = textRebut.Substring(tt[0].Length + tt[1].Length + 2);

                var index = textRebut.LastIndexOf(':');
                var aplicacionsEnUs = textRebut.Substring(index + 1).FromBase64().Deserialitzar<List<AplicacioEnUs>>();

                textRebut = textRebut.Substring(0, index);

                var ipEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                estacioAlumne.AdreçaPort = new AdreçaPort(ipEndPoint);

                Trace.WriteLine($"Missatge rebut com a string: {estatRebutText}");

                if (Enum.TryParse(estatRebutText, out TipusMissatge tipus))
                {
                    var resposta = _gestorEstat?.Invoke(tipus, estacioAlumne) ?? "Resposta per defecte";
                    var respostaBytes = Encoding.UTF8.GetBytes(resposta.CompressToBase64());
                    stream.Write(respostaBytes, 0, respostaBytes.Length);

                    _callbackFinalitzacio?.Invoke(tipus, estacioAlumne, textRebut, aplicacionsEnUs);
                }
                else
                {
                    var resposta = "Missatge no vàlid, s'esperava un tipus de missatge.";
                    var respostaBytes = Encoding.UTF8.GetBytes(resposta.CompressToBase64());
                    stream.Write(respostaBytes, 0, respostaBytes.Length);
                }

                stream.Close();
                client.Close();

                if (!_aturat)
                    _listener.BeginAcceptTcpClient(AcceptCallback, null);
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
            catch (SocketException)
            {
                // ignore
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void Aturar()
        {
            _aturat = true;
            _listener?.Stop();
            Trace.WriteLine("Servidor aturat.");
        }
    }
}