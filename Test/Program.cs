using System;
using System.Threading.Tasks;
using Examen.Suport.Funcions;

namespace Examen.Test
{
    public static class Program
    {
        static void Main()
        {
            try
            {
                var ret = Task.Run(() => Intermediari.RabbitMQ.Client.GetRabbitMQConnectionAsync(
                    hostName: "localhost"));
                ret.Wait();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }
    }
}
