using Examen.Suport.Funcions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        Captura
    }

    public static class Connexio
    {
        private static ConnectionMultiplexer Redis { get; set; }
        private static IDatabase Db { get; set; }
        private static string FitxerTraces { get; set; }
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

        static Connexio()
        {
            if (!Properties.Settings.Default.Traces)
                return;

            var directoriTraces = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
            if (directoriTraces == null)
                return;

            directoriTraces = Path.Combine(directoriTraces, "Traces");
            if (!Directory.Exists(directoriTraces))
                Directory.CreateDirectory(directoriTraces);

            FitxerTraces = Path.Combine(directoriTraces, "RedisTraces.log");
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

        public static void Connectar(Codificacio codificacio = null)
        {
            try
            {
                if (Redis != null)
                    return;

                if (codificacio != null && Codificacio != null)
                    Codificacio = codificacio;

                var servidor = Properties.Settings.Default.Servidor;
                var port = Properties.Settings.Default.Port;
                var contrasenya = Properties.Settings.Default.Contrasenya.ToStringFromBase64();

                var configurationOptions = new ConfigurationOptions
                {
                    EndPoints =
                    {
                        { servidor, port }
                    },
                    KeepAlive = 180,
                    Password = contrasenya,
                    AllowAdmin = true,
                    AbortOnConnectFail = false
                };

                Redis = ConnectionMultiplexer.Connect(configurationOptions);
                Db = Redis.GetDatabase();

                TipusTraça.Connexió.Traça($"Connexió a {servidor}:{port}");
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void Desconnectar()
        {
            try
            {
                if (Redis == null)
                    return;

                Redis.Close();
                Redis.Dispose();
                Redis = null;

                TipusTraça.Desconnexió.Traça("Desconnexió");
            }
            catch
            {
                // ignore
            }
        }

        public static bool EnviaMissatge(Codificacio codificacio, object objecte)
        {
            try
            {
                Connectar(codificacio);

                if (objecte is not string missatge)
                    missatge = objecte.Serialitzar();

                Db.ListLeftPush(codificacio.ToString(), missatge);

                TipusTraça.EnviaMissatge.Traça(missatge);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
                return false;
            }

            return true;
        }

        public static bool CrearClau(string clau, object objecte, TimeSpan duracio)
        {
            try
            {
                Connectar();

                if (objecte is not string missatge)
                    missatge = objecte.Serialitzar();

                TipusTraça.CrearClau.Traça(clau);

                return Db.StringSet(clau, missatge, duracio, When.Always);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static bool EsborrarClau(string clau)
        {
            try
            {
                Connectar();

                TipusTraça.EsborrarClau.Traça(clau);

                return Db.KeyDelete(clau);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static bool ExisteixClau(string clau)
        {
            try
            {
                Connectar();

                TipusTraça.ExisteixClau.Traça(clau);

                return Db.KeyExists(clau);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return false;
        }

        public static string LlegirClau(string clau)
        {
            try
            {
                Connectar();

                TipusTraça.LlegirClau.Traça(clau);

                return Db.StringGet(clau.Replace(":", "_"));
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return null;
        }

        public static T LlegirClau<T>(string clau)
        {
            try
            {
                Connectar();

                var json = Db.StringGet(clau);
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

        public static T RebreMissatge<T>(Codificacio codificacio)
        {
            try
            {
                Connectar(codificacio);

                var valor = Db.ListRightPop(codificacio.ToString());

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

        public static void Subscriure<T>(Codificacio codificacio, Action<string, T> accioAlRebre)
        {
            Connectar(codificacio);

            var sub = Redis.GetSubscriber();
            var redisChannel = RedisChannel.Literal(codificacio.ToString());
            sub.Subscribe(redisChannel, (rc, rv) => Subscripcio(rc, rv, accioAlRebre));

            TipusTraça.Subscriure.Traça($"{codificacio}");
        }

        public static void SubscriurePatro<T>(Codificacio codificacio, Action<string, T> accioAlRebre)
        {
            Connectar(codificacio);

            var sub = Redis.GetSubscriber();
            var redisChannel = RedisChannel.Pattern(codificacio.ToString());
            sub.Subscribe(redisChannel, (rc, rv) => SubscripcioPatro(rc, rv, accioAlRebre));

            TipusTraça.SubscriurePatro.Traça($"{codificacio}");
        }

        public static void SubscriurePatro(Codificacio codificacio, Action<string> accioAlRebre)
        {
            Connectar(codificacio);

            var sub = Redis.GetSubscriber();
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

        private static long Publicar<T>(Codificacio codificacio, T missatge)
        {
            Connectar(codificacio);

            var sub = Redis.GetSubscriber();

            var contingut = typeof(T) == typeof(string) ? missatge.ToString() : missatge.Serialitzar();

            var redisChannel = RedisChannel.Literal(codificacio.ToString());
            var ret = sub.Publish(redisChannel, contingut, CommandFlags.FireAndForget);

            TipusTraça.Publicar.Traça($"{codificacio} --> {contingut} --> {ret}");

            return ret;
        }

        public static long EnviarNotificacio<T>(string idSessio, TipusNotificacio tipusNotificacio, T objecte, params string[] altresParametres)
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
                Connectar(codificacio);

                var ret = Publicar(codificacio, objecte);

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
