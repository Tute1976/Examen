using Examen.Suport.Funcions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Examen.Intermediari.Redis
{
    public enum TipusNotificacio
    {
        Deteccio,
        Tancament,
        KeepAlive,
        AplicacionsEnUs,
        Aplicacions,
        Inici,
        Fi,
        KeepAliveAmdDeteccio,
        FiServidor,
        Pitar,
        Bloquejar,
        Aturar,
        Capturar,
        IniciSessió,
        FiSessió,
        Captura,
        Refrescar
    }

    public static class Connexio
    {
        private static ConnectionMultiplexer RedisPersistent { get; set; }
        private static ConnectionMultiplexer RedisVolatil { get; set; }
        private static IDatabase DbPersistent { get; set; }
        private static IDatabase DbVolatil { get; set; }

        private static string FitxerTraces { get; set; }
        private static string FitxerCertificat { get; set; }
        public static X509Certificate2 Certificat { get; set; }

        private static  Codificacio Codificacio { get; set; }

        public enum TipusTraça
        {
            Connexió,
            Desconnexió,
            EnviaMissatge,
            CrearClau,
            EsborrarClau,
            ExisteixClau,
            LlegirClau,
            Subscriure,
            SubscriurePatro,
            Publicar,
            EnviarNotificacio,
            AlRebreAplicacions,
            AlRebrePitar, 
            AlRebreBloquejar,
            AlRebreAturar,
            AlRebreCapturar,
            AlRebreFiServidor,
            AlRebreFi,
            AlRebreInici,
            AlRebreDetecció,
            AlRebreKeepAlive,
            AlRebreAplicacionsEnUs,
            AlRebreIniciSessió,
            AlRebreFiSessió,
            AlRebreTancament
        }

        public enum TipusRedis
        {
            Persistent = 6380,
            Volatil = 6379
        }

        static Connexio()
        {
            if (!Properties.Settings.Default.Traces)
                return;

            var directoriExecutable= Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
            if (directoriExecutable == null)
                return;

            var directoriTraces = Path.Combine(directoriExecutable, "Traces");
            if (!Directory.Exists(directoriTraces))
                Directory.CreateDirectory(directoriTraces);
            FitxerTraces = Path.Combine(directoriTraces, "RedisTraces.log");

            var directoriCertificat= Path.Combine(directoriExecutable, "Certificat");
            if (!Directory.Exists(directoriCertificat))
                Directory.CreateDirectory(directoriCertificat);
            var fitxers = Directory.GetFiles(directoriCertificat);
            if (fitxers.Length > 0)
            {
                FitxerCertificat = fitxers.First();
                Certificat = new X509Certificate2(FitxerCertificat);
            }
        }

        public static void Traça(this TipusTraça tipus, string missatge)
        {
            try
            {
                if (!Properties.Settings.Default.Traces)
                    return;

                var txt = $@"{DateTime.Now:G} | {tipus} | [{Codificacio}] | {missatge}";
                File.AppendAllLines(FitxerTraces, [txt], new UTF8Encoding());
            }
            catch
            {
                // ignore
            }
        }

        public static bool Connectar()
        {
            return Connectar(null, TipusRedis.Volatil);
        }

        public static bool Connectar(TipusRedis tipusRedis)
        {
            return Connectar(null, tipusRedis);
        }

        public static bool Connectar(Codificacio codificacio, TipusRedis tipusRedis)
        {
            try
            {
                switch (tipusRedis)
                {
                    case TipusRedis.Persistent:
                        if (RedisPersistent is { IsConnected: true })
                            return true;
                        break;
                    case TipusRedis.Volatil:
                        if (RedisVolatil is { IsConnected: true })
                            return true;
                        break;
                }

                if (codificacio != null && Codificacio != null)
                    Codificacio = codificacio;

                var servidor = Properties.Settings.Default.Servidor;
                var port = (int)tipusRedis;
                var contrasenya = Properties.Settings.Default.Contrasenya.ToStringFromBase64();

                var configurationOptions = new ConfigurationOptions
                {
                    EndPoints =
                    {
                        { servidor, port }
                    },

                    ConnectTimeout = 5000,
                    SyncTimeout = 5000,
                    AsyncTimeout = 5000,

                    ConnectRetry = 0,
                    ResolveDns = true,

                    AbortOnConnectFail = false,
                    KeepAlive = 180,

                    Password = contrasenya,
                    AllowAdmin = true,

                    Ssl = true,
                    SslProtocols = SslProtocols.Tls12,
                    SslHost = servidor,
                    CheckCertificateRevocation = false
                };
                configurationOptions.CertificateValidation += CertificateValidation;

                if (tipusRedis == TipusRedis.Persistent)
                {
                    RedisPersistent = ConnectionMultiplexer.Connect(configurationOptions);
                    if (!RedisPersistent.IsConnected)
                        return false;
                    DbPersistent = RedisPersistent.GetDatabase();
                }
                else
                {
                    RedisVolatil = ConnectionMultiplexer.Connect(configurationOptions);
                    if (!RedisVolatil.IsConnected)
                        return false;
                    DbVolatil = RedisVolatil.GetDatabase();
                }

                TipusTraça.Connexió.Traça($"Connexió a {servidor}:{port}");
                return true;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
                return false;
            }
        }

        private static bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            $"Error al validar el certificat: {sslPolicyErrors}".Mostrar(MostrarIcon.Error);

            return false;
        }

        public static void Desconnectar()
        {
            try
            {
                RedisPersistent?.Close();
                RedisPersistent?.Dispose();
                RedisPersistent = null;

                RedisVolatil?.Close();
                RedisVolatil?.Dispose();
                RedisVolatil = null;
            }
            catch
            {
                // ignore
            }

            TipusTraça.Desconnexió.Traça("Desconnexió");
        }

        public static bool EnviaMissatge(Codificacio codificacio, object objecte, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(codificacio, tipusRedis);

                if (objecte is not string missatge)
                    missatge = objecte.Serialitzar();

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                db.ListLeftPush(codificacio.ToString(), missatge);

                TipusTraça.EnviaMissatge.Traça(missatge);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
                return false;
            }

            return true;
        }

        public static bool CrearClau(string clau, object objecte, TimeSpan duracio, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(tipusRedis);

                if (objecte is not string missatge)
                    missatge = objecte.Serialitzar();

                TipusTraça.CrearClau.Traça(clau);

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                return db.StringSet(clau, missatge, duracio, When.Always);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static bool EsborrarClau(string clau, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(tipusRedis);

                TipusTraça.EsborrarClau.Traça(clau);

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                return db.KeyDelete(clau);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static bool ExisteixClau(string clau, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(tipusRedis);

                TipusTraça.ExisteixClau.Traça(clau);

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                return db.KeyExists(clau);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static string LlegirClau(string clau, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(tipusRedis);

                TipusTraça.LlegirClau.Traça(clau);

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                return db.StringGet(clau.Replace(":", "_"));
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return null;
        }

        public static T LlegirClau<T>(string clau, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(tipusRedis);

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                var json = db.StringGet(clau);
                if (json.HasValue)
                {
                    var ret = json.ToString().Deserialitzar<T>();

                    TipusTraça.LlegirClau.Traça($"{clau} --> {ret}");

                    return ret;
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return default;
        }

        public static T RebreMissatge<T>(Codificacio codificacio, TipusRedis tipusRedis)
        {
            try
            {
                Connectar(codificacio, tipusRedis);

                var db = tipusRedis == TipusRedis.Persistent ? DbPersistent : DbVolatil;
                var valor = db.ListRightPop(codificacio.ToString());

                if (valor.HasValue)
                {
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)valor.ToString();
                    }

                    var json = valor.ToString();
                    var ret = json.Deserialitzar<T>();

                    TipusTraça.LlegirClau.Traça($"{codificacio} --> {ret}");

                    return ret;
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
                return default;
            }

            return default;
        }

        public static void Subscriure<T>(Codificacio codificacio, Action<string, T> accioAlRebre, TipusRedis tipusRedis)
        {
            Connectar(codificacio, tipusRedis);

            var redis = tipusRedis == TipusRedis.Persistent ? RedisPersistent : RedisVolatil;
            var sub = redis.GetSubscriber();
            var redisChannel = RedisChannel.Literal(codificacio.ToString());
            sub.Subscribe(redisChannel, (rc, rv) => Subscripcio(rc, rv, accioAlRebre));

            TipusTraça.Subscriure.Traça($"{codificacio}");
        }

        public static void SubscriurePatro<T>(Codificacio codificacio, Action<string, T> accioAlRebre, TipusRedis tipusRedis)
        {
            Connectar(codificacio, tipusRedis);

            var redis = tipusRedis == TipusRedis.Persistent ? RedisPersistent : RedisVolatil;
            var sub = redis.GetSubscriber();
            var redisChannel = RedisChannel.Pattern(codificacio.ToString());
            sub.Subscribe(redisChannel, (rc, rv) => SubscripcioPatro(rc, rv, accioAlRebre));

            TipusTraça.SubscriurePatro.Traça($"{codificacio}");
        }

        public static void SubscriurePatro(Codificacio codificacio, Action<string> accioAlRebre, TipusRedis tipusRedis)
        {
            Connectar(codificacio, tipusRedis);

            var redis = tipusRedis == TipusRedis.Persistent ? RedisPersistent : RedisVolatil;
            var sub = redis.GetSubscriber();
            var redisChannel = RedisChannel.Pattern(codificacio.ToString());
            sub.Subscribe(redisChannel, (rc, rv) => SubscripcioPatro(rc, rv, accioAlRebre));

            TipusTraça.SubscriurePatro.Traça($"{codificacio}");
        }

        private static void Subscripcio<T>(RedisChannel canal, RedisValue redisValue, Action<string, T> accioAlRebre)
        {
            try
            {
                if (!redisValue.HasValue)
                    return;

                T objecteRebut;

                if (typeof(T) == typeof(string))
                {
                    objecteRebut = (T)(object)redisValue.ToString();
                }
                else
                {
                    var json = redisValue.ToString();
                    objecteRebut = json.Deserialitzar<T>();
                }

                accioAlRebre(canal.ToString(), objecteRebut);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private static void SubscripcioPatro<T>(RedisChannel canal, RedisValue redisValue, Action<string, T> accioAlRebre)
        {
            try
            {
                if (!redisValue.HasValue)
                    return;

                T objecteRebut;

                if (typeof(T) == typeof(string))
                {
                    objecteRebut = (T)(object)redisValue.ToString();
                }
                else
                {
                    var json = redisValue.ToString();
                    objecteRebut = json.Deserialitzar<T>();
                }

                accioAlRebre(canal.ToString(), objecteRebut);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private static void SubscripcioPatro(RedisChannel canal, RedisValue redisValue, Action<string> accioAlRebre)
        {
            try
            {
                if (!redisValue.HasValue)
                    return;

                accioAlRebre(canal.ToString());
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private static long Publicar<T>(Codificacio codificacio, T missatge, TipusRedis tipusRedis)
        {
            Connectar(codificacio, tipusRedis);

            var redis = tipusRedis == TipusRedis.Persistent ? RedisPersistent : RedisVolatil;
            var sub = redis.GetSubscriber();

            var contingut = typeof(T) == typeof(string) ? missatge.ToString() : missatge.Serialitzar();

            var redisChannel = RedisChannel.Literal(codificacio.ToString());
            var ret = sub.Publish(redisChannel, contingut, CommandFlags.FireAndForget);

            TipusTraça.Publicar.Traça($"{codificacio} --> {contingut} --> {ret}");

            return ret;
        }

        public static long EnviarNotificacio<T>(string idSessio, TipusNotificacio tipusNotificacio, T objecte, TipusRedis tipusRedis, params string[] altresParametres)
        {
            try
            {
                var llistaParametres = new List<string>
                {
                    tipusNotificacio.ToString()
                };
                if (altresParametres.Length > 0)
                    llistaParametres.AddRange(altresParametres);

                var codificacio = new Codificacio(idSessio, [.. llistaParametres]);
                Connectar(codificacio, tipusRedis);

                var ret = Publicar(codificacio, objecte, tipusRedis);

                TipusTraça.EnviarNotificacio.Traça($"{codificacio} --> {ret}");

                return ret;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return -1;
        }
    }

    public class Codificacio(string id, params string[] noms)
    {
        private string Id { get; set; } = id;
        private string[] Noms { get; set; } = noms;

        public override string ToString()
        {
            return $@"{Id}:{string.Join(":", Noms)}";
        }
    }
}
