using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;

namespace Examen.Intermediari.Redis
{
    public static class Alumne
    {
        public static void SubscriuresLlistaAplicacions(string idSessio, EstacioAlumne estacioAlumne, Action<List<Aplicacio>> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Aplicacions), estacioAlumne.Estacio, estacioAlumne.Nom);
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

        public static void SubscriuresTancament(string idSessio, EstacioAlumne estacioAlumne, Action<string> enRebreTancament)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.Tancament), estacioAlumne.Estacio, estacioAlumne.Nom);
                Connexio.SubscriurePatro(codificacio, enRebreTancament);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresIniciSessio(string idSessio, Action<string> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.IniciSessió), "*");
                Connexio.SubscriurePatro(codificacio, enRebre);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public static void SubscriuresFiSessio(string idSessio, Action<string> enRebre)
        {
            try
            {
                Connexio.Connectar();
                var codificacio = new Codificacio(idSessio, nameof(TipusNotificacio.FiSessió), "*");
                Connexio.SubscriurePatro(codificacio, enRebre);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        extension(TipusNotificacio tipusNotificacio)
        {
            public void Notificar(string idSessio, Notificacio notificacio, string nom = null)
            {
                try
                {
                    if (string.IsNullOrEmpty(nom))
                        Connexio.EnviarNotificacio(idSessio, tipusNotificacio, notificacio, Environment.UserName, Environment.MachineName);
                    else
                        Connexio.EnviarNotificacio(idSessio, tipusNotificacio, notificacio, Environment.UserName, Environment.MachineName, nom);
                }
                catch (Exception ex)
                {
                    ex.Mostrar();
                }
            }
        }
    }
}
