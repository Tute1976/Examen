using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Examen.Suport.Classes;

namespace Examen.Suport.Funcions
{
    public static class Ip
    {
        public static int Port { get; set; }
        
        public static bool ObtenirIp(out AdreçaPort adreçaPortMascara)
        {
            adreçaPortMascara = new AdreçaPort();

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

                    adreçaPortMascara.Adreça = ip.Address;
                    adreçaPortMascara.Mascara = ip.IPv4Mask;
                    return true;
                }
            }

            return false;
        }

        private static IPAddress ObtenirAdreçaDeXarxa(this AdreçaPort adreçaPortMascara)
        {
            var bytesIp = adreçaPortMascara.Adreça.GetAddressBytes();
            var bytesMascara = adreçaPortMascara.Mascara.GetAddressBytes();

            if (bytesIp.Length != 4 || bytesMascara.Length != 4)
                throw new ArgumentException("Només es permeten adreces IPv4");

            var bytesXarxa = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                bytesXarxa[i] = (byte)(bytesIp[i] & bytesMascara[i]);
            }

            return new IPAddress(bytesXarxa);
        }

        public static int ObtenirPort(AdreçaPort adreçaPort)
        {
            var portMaxim = adreçaPort.Port + 100;

            while (adreçaPort.Port <= portMaxim)
            {
                try
                {
                    var listener = new TcpListener(adreçaPort.Adreça, adreçaPort.Port);
                    listener.Start();
                    listener.Stop();
                    return adreçaPort.Port;
                }
                catch (SocketException)
                {
                    adreçaPort.Port++;
                }
            }

            throw new Exception("No s'ha trobat cap port lliure.");
        }

        public static int ObtenirPort(int port)
        {
            var portMaxim = port + 100;

            while (port <= portMaxim)
            {
                try
                {
                    var listener = new TcpListener(IPAddress.Any, port);
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

        private static string GenerarCodiDesdeAdreça(AdreçaPort adreçaPortMascara)
        {
            var bytesAdreça = adreçaPortMascara.Adreça.GetAddressBytes();
            var bytesMascara = adreçaPortMascara.Mascara.InvertirMascara().GetAddressBytes();

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
            var codi = $"{numero:X}:{adreçaPortMascara.Port:X}";
            return codi;
        }

        private static IPAddress ObtenirAdreçaDesdeCodi(this string codi, IPAddress xarxa, out int port)
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

        public static bool ObtenirCodi(out string codi, out AdreçaPort adreçaPort)
        {
            codi = "";
            adreçaPort = new AdreçaPort();

            try
            {
                if (!ObtenirIp(out var adreçaPortMascara))
                    throw new Exception("No s'ha pogut obtenir la IP de l'estació.");
                adreçaPort = adreçaPortMascara;
                adreçaPort.Port = Port;
                adreçaPort.Port = ObtenirPort(adreçaPort);
                codi = GenerarCodiDesdeAdreça(adreçaPort);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ObtenirAdreça(this string codi, out AdreçaPort adreçaPort)
        {
            adreçaPort = new AdreçaPort();

            try
            {
                if (!ObtenirIp(out var adreçaPortMascara))
                    throw new Exception("No s'ha pogut obtenir la IP de l'estació.");
                var xarxa = adreçaPortMascara.ObtenirAdreçaDeXarxa();
                adreçaPort.Adreça = codi.ObtenirAdreçaDesdeCodi(xarxa, out var port);
                adreçaPort.Port = port;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int ComptarBitsDeXarxa(this IPAddress mascara)
        {
            var bytes = mascara.GetAddressBytes();

            return bytes.Sum(ComptarBits);
        }

        private static int ComptarBits(byte b)
        {
            var count = 0;
            while (b != 0)
            {
                count += b & 1;
                b >>= 1;
            }
            return count;
        }
    }
}
