using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Examen.Suport.Classes;
using Examen.Suport.Funcions;

namespace Examen.Suport.Tcp
{
    public static class ServidorTcp
    {
        private static TcpListener _listener;
        private static Func<TipusMissatge, EstacioAlumne, string> _gestorEstat;
        private static Action<TipusMissatge, EstacioAlumne, string> _callbackFinalitzacio;

        public static void Iniciar(AdreçaPort adreçaPort, Func<TipusMissatge, EstacioAlumne, string> gestorEstat, Action<TipusMissatge, EstacioAlumne, string> callback)
        {
            _gestorEstat = gestorEstat;
            _callbackFinalitzacio = callback;
            _listener = new TcpListener(adreçaPort.ToIpEndPoint());
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

                var buffer = new byte[1024];
                var bytesLlegits = stream.Read(buffer, 0, buffer.Length);
                var textRebut = Encoding.UTF8.GetString(buffer, 0, bytesLlegits);
                textRebut = textRebut.FromBase64();
                var tt = textRebut.Split(':');
                var estatRebutText = tt.First();
                var estacioAlumne = tt[1].FromBase64().Deserialitzar<EstacioAlumne>();
                textRebut = textRebut.Substring(tt[0].Length + tt[1].Length + 2);

                var ipEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                estacioAlumne.AdreçaPort = new AdreçaPort(ipEndPoint);

                Trace.WriteLine($"Missatge rebut com a string: {estatRebutText}");

                if (Enum.TryParse(estatRebutText, out TipusMissatge tipus))
                {
                    var resposta = _gestorEstat?.Invoke(tipus, estacioAlumne) ?? "Resposta per defecte";
                    resposta = resposta.ToBase64();
                    var respostaBytes = Encoding.UTF8.GetBytes(resposta);
                    stream.Write(respostaBytes, 0, respostaBytes.Length);

                    _callbackFinalitzacio?.Invoke(tipus, estacioAlumne, textRebut);
                }
                else
                {
                    var resposta = "Missatge no vàlid, s'esperava un tipus de missatge.";
                    resposta = resposta.ToBase64().CompressToBase64();
                    var respostaBytes = Encoding.UTF8.GetBytes(resposta);
                    stream.Write(respostaBytes, 0, respostaBytes.Length);
                }

                stream.Close();
                client.Close();

                _listener.BeginAcceptTcpClient(AcceptCallback, null);
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
            catch (Exception ex)
            {
                ex.Mostrar(false);
            }
        }

        public static void Aturar()
        {
            _listener?.Stop();
            Trace.WriteLine("Servidor aturat.");
        }
    }
}