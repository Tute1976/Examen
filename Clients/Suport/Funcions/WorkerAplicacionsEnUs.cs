using Examen.Suport.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Examen.Suport.Funcions
{
    public class WorkerAplicacionsEnUs
    {
        private BackgroundWorker _backgroundWorker;
        private readonly Action _onCompleted;

        public WorkerAplicacionsEnUs(Action onCompleted)
        {
            _onCompleted = onCompleted;

            InitializeWorker();

            _backgroundWorker.RunWorkerAsync();
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
                _backgroundWorker.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
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
                var ret = Helper.LlistarAplicacionsEnUs();
                _backgroundWorker.ReportProgress(0, ret);
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
                if (e.ProgressPercentage == 0 && e.UserState is List<AplicacioEnUs> aplicacionsEnUs)
                    Helper.AplicacionsEnUs = aplicacionsEnUs;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                _onCompleted.Invoke();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }
    }
}
