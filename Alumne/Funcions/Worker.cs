using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Examen.Alumne.Formularis;
using Examen.Intermediari.Redis;
using Examen.Suport.Formularis;

namespace Examen.Alumne.Funcions
{
    public class Worker : IDisposable
    {
        private BackgroundWorker _backgroundWorker;

        private readonly FrmPrincipal _frmPrincipal;
        private bool EnExecucio { get; set; }

        public Worker(FrmPrincipal frmPrincipal)
        {
            try
            {
                _frmPrincipal = frmPrincipal;

                InitializeWorker();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public void Inici()
        {
            EnExecucio = true;
            _backgroundWorker.RunWorkerAsync();
        }

        public void Fi()
        {
            EnExecucio = false;
        }

        private void InitializeWorker()
        {
            try
            {
                _backgroundWorker = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                _backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
                _backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                @"Executant worker".Mostrar(MostrarIcon.Asterisk);

                while (EnExecucio)
                {
                    foreach (var aplicacio in _frmPrincipal.Aplicacions.Where(aplicacio => aplicacio.EnExecucio()))
                    {

                        @$"Aplicació {aplicacio.Nom} en execució detectada, enviant ...".Mostrar(MostrarIcon.Warning);
                        var aturada = aplicacio.Aturar(_backgroundWorker);
                        if (!aturada)
                            aturada = aplicacio.Aturar(_backgroundWorker);

                        TipusNotificacio.Deteccio.Notificar(_frmPrincipal.Codi, new Notificacio(_frmPrincipal.EstacioAlumne, aplicacio, aturada));
                    }

                    Thread.Sleep(Properties.Settings.Default.IntervalTemps * 1000);
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (e.ProgressPercentage)
                {
                  
                    default:
                        if (e.UserState is Dictionary<ToastType, string> missatge2)
                        {
                            var missatge3 = missatge2.First();
                            missatge3.Value.ShowToast(e.ProgressPercentage, missatge3.Key);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        public void Dispose()
        {
            _backgroundWorker?.Dispose();
        }
    }
}
