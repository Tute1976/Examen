using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using System.Net;

namespace Examen.Suport.Classes
{
    public class AdreçaPort
    {
        public IPAddress Adreça { get; set; } = IPAddress.None;
        public int Port { get; set; }
        public IPAddress Mascara { get; set; } = IPAddress.None;
        public IPAddress Xarxa { get; set; } = IPAddress.None;

        public AdreçaPort()
        {
        }

        public AdreçaPort(IPEndPoint ipEndPoint)
        {
            Adreça = ipEndPoint.Address;
            Port = ipEndPoint.Port;
        }

        public AdreçaPort(IPAddress adreça, int port, IPAddress mascara = null, IPAddress xarxa = null)
        {
            Adreça = adreça;
            Port = port;
            Mascara = mascara ?? IPAddress.None;
            Xarxa = xarxa ?? IPAddress.None;
        }

        public override string ToString()
        {
            return Equals(Mascara, IPAddress.None) ?
                $"{Adreça}:{Port}" :
                $"{Adreça}/{Mascara.ComptarBitsDeXarxa()}:{Port}";
        }

        public IPEndPoint ToIpEndPoint()
        {
            return new IPEndPoint(Adreça, Port);
        }

        public bool Provar(EstacioAlumne estacioAlumne)
        {
            try
            {
                ClientTcp.EnviarEstat(this, estacioAlumne, TipusMissatge.Prova);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
