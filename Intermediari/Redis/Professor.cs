using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;

namespace Examen.Intermediari.Redis
{
    public static class Professor
    {
        public static void EnviarAplicacions(string idSessio, EstacioAlumne estacioAlumne, List<Aplicacio> aplicacions)
        {
            try
            {
                Connexio.EnviarNotificacio(idSessio, TipusNotificacio.Aplicacions, aplicacions, estacioAlumne.Estacio, estacioAlumne.Nom);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresLlistaAplicacionsEnUs(string idSessio, Action<string, string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.AplicacionsEnUs), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 3];
                    var estacio = cc[cc.Length - 2];
                    var nom = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, nom, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresInici(string idSessio, Action<string, string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Inici), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 3];
                    var estacio = cc[cc.Length - 2];
                    var nom = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, nom, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresFi(string idSessio, Action<string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Fi), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 2];
                    var estacio = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresFiServidor(string idSessio, Action<string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.FiServidor), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 2];
                    var estacio = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresKeepAlive(string idSessio, Action<string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.KeepAlive), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 2];
                    var estacio = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresKeepAliveAmdDeteccio(string idSessio, Action<string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.KeepAliveAmdDeteccio), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 2];
                    var estacio = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresDeteccio(string idSessio, Action<string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Deteccio), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 2];
                    var estacio = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresCaptura(string idSessio, Action<string, string, Notificacio> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Captura), "*");
                Connexio.SubscriurePatro<Notificacio>(codificacio, (canal, notificacio) =>
                {
                    var cc = canal.Split(':');
                    var usuari = cc[cc.Length - 2];
                    var estacio = cc[cc.Length - 1];

                    enRebre.Invoke(usuari, estacio, notificacio);
                });
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void CreaClauSessio(string codi, TimeSpan duracio)
        {
            Connexio.CrearClau(codi, DateTime.Now.ToString("G"), duracio);
        }

        public static void EsborrarClauSessio(string codi)
        {
            Connexio.EsborrarClau(codi);
        }

        extension(TipusNotificacio tipusNotificacio)
        {
            public void EnviarNotificacio(string idSessio, EstacioAlumne estacioAlumne)
            {
                try
                {
                    Connexio.EnviarNotificacio(idSessio, tipusNotificacio, true, estacioAlumne.Estacio, estacioAlumne.Nom);
                }
                catch (Exception ex)
                {
                    ex.Mostrar();
                }
            }

            public void EnviarNotificacio(string idSessio)
            {
                try
                {
                    Connexio.EnviarNotificacio(idSessio, tipusNotificacio, true, "*");
                }
                catch (Exception ex)
                {
                    ex.Mostrar();
                }
            }
        }
    }
}
