using Examen.Suport.Funcions;

namespace Examen.Intermediari.RabbitMQ
{
    public static class Info
    {
        public static string UserName => Properties.Settings.Default.UserName;
        public static string Password => Properties.Settings.Default.Password.ToStringFromBase64();
        public static string HostName => Properties.Settings.Default.HostName;
        public static string VirtualHost => Properties.Settings.Default.VirtualHost;
    }
}
