using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;

namespace Examen.Intermediari.Redis
{
    public static class Alumne
    {
        private static long Enviar(string idSessio, TipusNotificacio tipusNotificacio, string nom)
        {
            try
            {
                return Connexio.EnviarNotificacio(idSessio, tipusNotificacio, DateTime.Now, nom, Environment.UserName, Environment.MachineName);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return -1;
        }

        public static long EnviarKeepAlive(string idSessio, Notificacio notificacio)
        {
            try
            {
                return Connexio.EnviarNotificacio(idSessio, TipusNotificacio.KeepAlive, notificacio, Environment.UserName, Environment.MachineName);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return -1;
        }

        public static long EnviarAplicacionsEnUs(string idSessio, Notificacio notificacio)
        {
            try
            {
                return Connexio.EnviarNotificacio(idSessio, TipusNotificacio.AplicacionsEnUs, notificacio, Environment.UserName, Environment.MachineName);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return -1;
        }

        public static long EnviarDeteccio(string idSessio, Deteccio deteccio)
        {
            try
            {
                return Connexio.EnviarNotificacio(idSessio, TipusNotificacio.Deteccio, deteccio, Environment.UserName, Environment.MachineName);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return -1;
        }

        public static void SubscriuresLlistaAplicacions(string idSessio, Action<List<Aplicacio>> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Aplicacions));
                Connexio.SubscriurePatro<List<Aplicacio>>(codificacio, (_, contenidorAplicacions) =>
                {
                    enRebre.Invoke(contenidorAplicacions);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresPitar(string idSessio, EstacioAlumne estacioAlumne, Action<string> enRebrePitar)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Pitar), estacioAlumne.Estacio, estacioAlumne.Nom);
                Connexio.SubscriurePatro(codificacio, enRebrePitar);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresBloquejar(string idSessio, EstacioAlumne estacioAlumne, Action<string> enRebreBloquejar)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Bloquejar), estacioAlumne.Estacio, estacioAlumne.Nom);
                Connexio.SubscriurePatro(codificacio, enRebreBloquejar);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresAturar(string idSessio, EstacioAlumne estacioAlumne, Action<string> enRebreAturar)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Aturar), estacioAlumne.Estacio, estacioAlumne.Nom);
                Connexio.SubscriurePatro(codificacio, enRebreAturar);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresCapturar(string idSessio, EstacioAlumne estacioAlumne, Action<string> enRebreCapturar)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Capturar), estacioAlumne.Estacio, estacioAlumne.Nom);
                Connexio.SubscriurePatro(codificacio, enRebreCapturar);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresFiServidor(string idSessio, EstacioAlumne estacioAlumne, Action<string> enRebreFiServidor)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.FiServidor), estacioAlumne.Estacio, estacioAlumne.Nom);
                Connexio.SubscriurePatro(codificacio, enRebreFiServidor);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        extension(TipusNotificacio tipusNotificacio)
        {
            public long Notificar(string idSessio, Notificacio notificacio, string nom = null)
            {
                try
                {
                    return string.IsNullOrEmpty(nom) ?
                        Connexio.EnviarNotificacio(idSessio, tipusNotificacio, notificacio, Environment.UserName, Environment.MachineName) :
                        Connexio.EnviarNotificacio(idSessio, tipusNotificacio, notificacio, Environment.UserName, Environment.MachineName, nom);
                }
                catch (Exception ex)
                {
                    ex.Mostrar();
                }

                return -1;
            }

            public long Detectar(string idSessio, Deteccio deteccio, string nom = null)
            {
                try
                {
                    return string.IsNullOrEmpty(nom) ?
                        Connexio.EnviarNotificacio(idSessio, tipusNotificacio, deteccio, Environment.UserName, Environment.MachineName) :
                        Connexio.EnviarNotificacio(idSessio, tipusNotificacio, deteccio, Environment.UserName, Environment.MachineName, nom);
                }
                catch (Exception ex)
                {
                    ex.Mostrar();
                }

                return -1;
            }
        }
    }
}
