using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Examen.Intermediari.RabbitMQ
{
    public static class Client
    {
        // ReSharper disable once InconsistentNaming
        public static async Task<IConnection> GetRabbitMQConnectionAsync(string hostName = null, string userName = null, string password = null, string virtualHost = null)
        {
            hostName ??= Info.HostName;
            userName ??= Info.UserName;
            password ??= Info.Password;
            virtualHost ??= Info.VirtualHost;

            var factory = new ConnectionFactory
            {
                UserName = userName,
                Password = password,
                HostName = hostName,
                VirtualHost = virtualHost
            };
            var conn = await factory.CreateConnectionAsync();

            return conn;
        }
    }
}
