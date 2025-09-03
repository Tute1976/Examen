using Examen.Suport.Classes;
using Examen.Suport.Funcions;
using Examen.Suport.Tcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Examen.Alumne.Formularis;
using Examen.Suport.Formularis;

namespace Examen.Alumne.Funcions
{
    public class Worker
    {
        private BackgroundWorker _backgroundWorker;

        private List<Aplicacio> _aplicacions;
        private readonly AdreçaPort _adreçaPortProfessor;
        private readonly EstacioAlumne _estacioAlumne;
        private readonly Action<List<Aplicacio>> _completat;
        private readonly FrmPrincipal _frmPrincipal;

        public Worker(FrmPrincipal frmPrincipal, Action<List<Aplicacio>> completat)
        {
            try
            {
                _frmPrincipal = frmPrincipal;

                InitializeWorker();

                _aplicacions = frmPrincipal.Aplicacions;
                _adreçaPortProfessor = frmPrincipal.AdreçaPortProfessor;
                _estacioAlumne = frmPrincipal.EstacioAlumne;
                _completat = completat;

                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
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
                @"Executant worker".Mostrar(MostrarIcon.Asterisk);

                var deteccio = false;
                foreach (var aplicacio in _aplicacions.Where(aplicacio => aplicacio.EnExecucio()))
                {
                    @$"Aplicació {aplicacio.Nom} en execució detectada, enviant ...".Mostrar(MostrarIcon.Warning);
                    var aturada = aplicacio.Aturar(_backgroundWorker);
                    ClientTcp.EnviarEstat(_adreçaPortProfessor, _estacioAlumne, [],
                        TipusMissatge.Deteccio,
                        Pitar, Bloquejar, Aturar, FiServidor, $"{aplicacio.Nom}:{aturada.SiNo()}");

                    deteccio = true;
                }

                var tipus = deteccio ? TipusMissatge.TempsAmbDeteccio : TipusMissatge.Temps;
                @$"Enviant missatge de tipus {tipus} ...".Mostrar(MostrarIcon.Information);
                var json = ClientTcp.EnviarEstat(_adreçaPortProfessor, _estacioAlumne, Helper.AplicacionsEnUs, tipus, Pitar, Bloquejar, Aturar, FiServidor);

                var aplicacions = json.Deserialitzar<List<Aplicacio>>();
                _aplicacions = aplicacions;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }

        private void Pitar()
        {
            _backgroundWorker.ReportProgress(1);
        }

        private void Bloquejar()
        {
            _backgroundWorker.ReportProgress(2);
        }

        private void Aturar()
        {
            _backgroundWorker.ReportProgress(3);
        }

        private void FiServidor()
        {
            _backgroundWorker.ReportProgress(4);
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (e.ProgressPercentage)
                {
                    case 0 when e.UserState is List<Aplicacio> aplicacions:
                        _completat.Invoke(aplicacions);
                        break;

                    //case 0 when e.UserState is string missatge1:
                    //    missatge1.ShowToast(5, ToastType.Info);
                    //    break;

                    case 1:
                        Helper.Pitar();
                        break;
                    
                    case 2:
                        Helper.Bloquejar();
                        break;
                    
                    case 3:
                        Helper.Aturar();
                        break;

                    case 4:
                        _frmPrincipal.FiServidor();
                        break;

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

        private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                _completat.Invoke(_aplicacions);
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }
        }
    }
}
