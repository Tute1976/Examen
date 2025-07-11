using System;
using System.Diagnostics;
using System.Text;
using TcpSharp;

namespace Examen.Suport.Tcp
{
    public class Client (string host, int port)
    {
        private string Host { get; set; } = host;
        private int Port { get; set; } = port;

        public void Connectar()
        {
            var client = new TcpSharpSocketClient(Host, Port);
            client.OnConnected += Client_OnConnected;
            client.OnReconnected += Client_OnReconnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnDataReceived += Client_OnDataReceived;
            client.OnError += Client_OnError;
            client.Reconnect = true;
            client.ReconnectDelayInSeconds = 5;

            Console.Write("Press <ENTER> to connect");
            Console.ReadLine();
            client.Connect();

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{i}] Press <ENTER> to send Hello World!");
                Console.ReadLine();

                Console.WriteLine("IsConnected: " + client.Connected);
                client.SendString("Hello World!");
                Console.WriteLine("IsConnected: " + client.Connected);
            }

            while (true)
            {
                Console.WriteLine("Press <ENTER> to start speed test");
                Console.ReadLine();
                Console.WriteLine("Starting 1GB test speed test");
                client.OnDataReceived -= Client_OnDataReceived;

                var bytes = Encoding.UTF8.GetBytes("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234");
                var sw = Stopwatch.StartNew();
                for (var i = 0; i < 1024 * 1024; i++)
                {
                    client.SendBytes(bytes);
                }
                sw.Stop();
                Console.WriteLine("Finished in " + sw.Elapsed);
            }
        }

        public void Desconnectar()
        {
        }

        private static void Client_OnError(object sender, OnClientErrorEventArgs e)
        {
            Console.WriteLine("Client_OnError");
        }

        private static void Client_OnDataReceived(object sender, OnClientDataReceivedEventArgs e)
        {
            Console.WriteLine("Client_OnDataReceived: " + Encoding.UTF8.GetString(e.Data));
        }

        private static void Client_OnDisconnected(object sender, OnClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Client_OnDisconnected");
        }

        private static void Client_OnConnected(object sender, OnClientConnectedEventArgs e)
        {
            Console.WriteLine("Client_OnConnected");
        }

        private static void Client_OnReconnected(object sender, OnClientReconnectedEventArgs e)
        {
            Console.WriteLine("Client_OnReconnected");
        }
    }
}
