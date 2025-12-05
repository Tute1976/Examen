using Examen.Suport.Funcions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

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
        Capturar
    }

    public static class Connexio
    {
        private static ConnectionMultiplexer Redis { get; set; }
        private static IDatabase Db { get; set; }

        public static void Connectar()
        {
            try
            {
                if (Redis != null)
                    return;

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
                Connectar();

                if (objecte is not string missatge)
                    missatge = objecte.Serialitzar();

                Db.ListLeftPush(codificacio.ToString(), missatge);
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
                    return json.ToString().Deserialitzar<T>();
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
                var valor = Db.ListRightPop(codificacio.ToString());

                if (valor.HasValue)
                {
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)valor.ToString();
                    }

                    var json = valor.ToString();
                    return json.Deserialitzar<T>();
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
            var sub = Redis.GetSubscriber();
            var redisChannel = RedisChannel.Literal(codificacio.ToString());
            sub.Subscribe(redisChannel, (canal, redisValue) =>
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
            );
        }

        public static void SubscriurePatro<T>(Codificacio codificacio, Action<string, T> accioAlRebre)
        {
            var sub = Redis.GetSubscriber();
            var redisChannel = RedisChannel.Pattern(codificacio.ToString());

            sub.Subscribe(redisChannel, (canal, redisValue) =>
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
            });
        }

        public static void SubscriurePatro(Codificacio codificacio, Action<string> accioAlRebre)
        {
            var sub = Redis.GetSubscriber();
            var redisChannel = RedisChannel.Pattern(codificacio.ToString());

            sub.Subscribe(redisChannel, (canal, redisValue) =>
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
            });
        }

        private static long Publicar<T>(Codificacio codificacio, T missatge)
        {
            var sub = Redis.GetSubscriber();

            var contingut = typeof(T) == typeof(string) ? missatge.ToString() : missatge.Serialitzar();

            var redisChannel = RedisChannel.Literal(codificacio.ToString());
            return sub.Publish(redisChannel, contingut, CommandFlags.FireAndForget);
        }

        public static long EnviarNotificacio<T>(string idSessio, TipusNotificacio tipusNotificacio, T objecte, params string[] altresParametres)
        {
            try
            {
                Connectar();
                
                var llistaParametres = new List<string>
                {
                    tipusNotificacio.ToString()
                };
                if (altresParametres.Length > 0)
                    llistaParametres.AddRange(altresParametres);

                var codificacio = new Codificacio(idSessio, llistaParametres.ToArray());

                return Publicar(codificacio, objecte);
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
        public string Id { get; set; } = id;
        public string[] Noms { get; set; } = noms;

        public override string ToString()
        {
            return $@"{Id}:{string.Join(":", Noms)}";
        }
    }
}
