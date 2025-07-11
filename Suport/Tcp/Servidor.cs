using System;
using System.Text;
using TcpSharp;

namespace Examen.Suport.Tcp
{
    public class Servidor
    {
        private readonly TcpSharpSocketServer _servidor;

        public Servidor()
        {
            _servidor = new TcpSharpSocketServer();
            _servidor.OnStarted += Servidor_OnStarted;
            _servidor.OnStopped += Servidor_OnStopped;
            _servidor.OnConnectionRequest += Servidor_OnConnectionRequest;
            _servidor.OnConnected += Servidor_OnConnected;
            _servidor.OnDisconnected += Servidor_OnDisconnected;
            _servidor.OnDataReceived += Servidor_OnDataReceived;
            _servidor.OnError += Servidor_OnError;
        }

        public void Iniciar()
        {
            _servidor.StartListening();
        }

        public void Aturar()
        {
            _servidor.StopListening();
        }

        private void Servidor_OnStarted(object sender, OnServerStartedEventArgs e)
        {
            Console.WriteLine("Servidor_OnStarted");
        }

        private void Servidor_OnStopped(object sender, OnServerStoppedEventArgs e)
        {
            Console.WriteLine("Servidor_OnStopped");
        }
        private void Servidor_OnConnectionRequest(object sender, OnServerConnectionRequestEventArgs e)
        {
            Console.WriteLine($"Servidor_OnConnectionRequest. IPEndPoint: {e.IPEndPoint} Address {e.IPAddress}:{e.Port}");
            //e.Accept = false;
        }

        private  void Servidor_OnConnected(object sender, OnServerConnectedEventArgs e)
        {
            Console.WriteLine($"Servidor_OnConnected. ConnectionId: {e.ConnectionId} Address {e.IPAddress}:{e.Port}");
        }

        private void Servidor_OnDisconnected(object sender, OnServerDisconnectedEventArgs e)
        {
            Console.WriteLine("Servidor_OnDisconnected");
        }

        private  void Servidor_OnDataReceived(object sender, OnServerDataReceivedEventArgs e)
        {
            // bytesReceived += e.Data.Length;
            // server.SendBytes(e.ConnectionId, Encoding.UTF8.GetBytes("Sana da selam!"));
            // Console.WriteLine("Servidor_OnDataReceived: "+ Encoding.UTF8.GetString(e.Data));
            // Console.WriteLine("Servidor_OnDataReceived: Packet Size: "+ e.Data.Length);
            if (e.Data.Length < 20)
            {
                var data = Encoding.UTF8.GetString(e.Data);
                Console.WriteLine("Servidor_OnDataReceived: " + data);
                _servidor.SendString(e.ConnectionId, "Echo: " + data);
            }
        }

        private  void Servidor_OnError(object sender, OnServerErrorEventArgs e)
        {
            Console.WriteLine("Servidor_OnError");
        }
    }
}
