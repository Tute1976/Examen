using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Examen.Suport.Funcions
{
    public static class Ip
    {
        public static int Port => Properties.Settings.Default.PortTcp;

        public static IPAddress ObtenirIp(out IPAddress mascara)
        {
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus != OperationalStatus.Up ||
                    ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                var props = ni.GetIPProperties();
                var gateway = props.GatewayAddresses.FirstOrDefault();
                if (gateway == null || gateway.Address.Equals(IPAddress.None))
                    continue;

                foreach (var ip in props.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily != AddressFamily.InterNetwork ||
                        IPAddress.IsLoopback(ip.Address)) 
                        continue;
                    
                    mascara = ip.IPv4Mask;
                    return ip.Address;
                }
            }

            mascara = IPAddress.None;
            return IPAddress.None;
        }

        public static IPAddress ObtenirAdreçaDeXarxa(IPAddress ip, IPAddress mascara)
        {
            var bytesIp = ip.GetAddressBytes();
            var bytesMascara = mascara.GetAddressBytes();

            if (bytesIp.Length != 4 || bytesMascara.Length != 4)
                throw new ArgumentException("Només es permeten adreces IPv4");

            var bytesXarxa = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                bytesXarxa[i] = (byte)(bytesIp[i] & bytesMascara[i]);
            }

            return new IPAddress(bytesXarxa);
        }

        public static int ProvarPort(IPAddress adreça, int port)
        {
            var portMaxim = port + 100;

            while (port <= portMaxim)
            {
                try
                {
                    var listener = new TcpListener(adreça, port);
                    listener.Start();
                    listener.Stop();
                    return port;
                }
                catch (SocketException)
                {
                    port++;
                }
            }

            throw new Exception("No s'ha trobat cap port lliure.");
        }

        public static string GenerarCodiDesdeAdreça(IPAddress adreça, IPAddress mascara, int port)
        {
            var bytesAdreça = adreça.GetAddressBytes();
            var bytesMascara = mascara.InvertirMascara().GetAddressBytes();

            if (bytesAdreça.Length != 4 || bytesMascara.Length != 4)
                throw new ArgumentException("Només es permeten adreces IPv4");

            var resultat = "";

            for (var i = 0; i < 4; i++)
            {
                var valor = bytesAdreça[i] & bytesMascara[i];
                if (valor != 0)
                    resultat += valor.ToString();
            }

            var numero = Convert.ToInt64(resultat);
            var codi = $"{numero:X}:{port:X}";
            return codi;
        }

        public static IPAddress ObtenirAdreçaDesdeCodi(this string codi, IPAddress xarxa, out int port)
        {
            port = 0;

            var parts = codi.Split(':');
            if (parts.Length != 2)
                throw new ArgumentException("El codi ha de tenir el format 'HEX_IP:HEX_PORT'");

            // Parseja la part host i el port
            if (!long.TryParse(parts[0], System.Globalization.NumberStyles.HexNumber, null, out var numeroHost))
                throw new ArgumentException("La part host no és hexadecimal vàlid");

            if (!int.TryParse(parts[1], System.Globalization.NumberStyles.HexNumber, null, out port))
                throw new ArgumentException("La part port no és hexadecimal vàlid");

            // Obtenim bytes de xarxa
            var bytesXarxa = xarxa.GetAddressBytes();
            if (bytesXarxa.Length != 4)
                throw new ArgumentException("Només es permeten adreces IPv4");

            // Convertim el número host en una seqüència de dígits decimal
            var textHostDecimal = numeroHost.ToString();

            // Convertim la part host en bytes a partir de la cadena
            var bytesHost = new List<byte>();
            var index = 0;
            while (index < textHostDecimal.Length)
            {
                var trobat = false;
                for (var len = 3; len >= 1; len--)
                {
                    if (index + len > textHostDecimal.Length) 
                        continue;

                    var sub = textHostDecimal.Substring(index, len);
                    if (!byte.TryParse(sub, out var b)) 
                        continue;
                    
                    bytesHost.Add(b);
                    index += len;
                    trobat = true;
                    break;
                }

                if (!trobat)
                    throw new Exception("No s'ha pogut interpretar la part host.");
            }

            // Omplir amb zeros si cal
            while (bytesHost.Count < 4)
                bytesHost.Insert(0, 0);  // afegim a l'inici per alinear amb màscara

            // Construir la IP final com xarxa OR host
            var ipFinal = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                ipFinal[i] = (byte)(bytesXarxa[i] | bytesHost[i]);
            }

            return new IPAddress(ipFinal);
        }

        private static IPAddress InvertirMascara(this IPAddress mascara)
        {
            var bytesMascara = mascara.GetAddressBytes();

            if (bytesMascara.Length != 4)
                throw new ArgumentException("Només es permeten màscares IPv4");

            var bytesInvertits = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                bytesInvertits[i] = (byte)~bytesMascara[i];
            }

            return new IPAddress(bytesInvertits);
        }
    }
}
