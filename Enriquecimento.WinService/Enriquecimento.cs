using System;
using System.ServiceProcess;
using System.Threading;

namespace Enriquecimento.WinService
{
    public partial class Enriquecimento : ServiceBase
    {
        private Timer timerCompactacao;
        private bool servicoCompactacao = true;
        private bool continuarExecutando = true;

        public Enriquecimento()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                continuarExecutando = true;
                timerCompactacao = new System.Threading.Timer(ExecutarCompactacao, null, 0, Timeout.Infinite);
            }
            catch
            { }
            finally
            { }
        }

        protected override void OnStop()
        {
            try
            {
                continuarExecutando = false;
                timerCompactacao.Dispose();
            }
            catch
            { }
            finally
            { }
        }

        #region Compactação de Jobs
        private void ExecutarCompactacao(object state)
        {
            try
            {
                if (servicoCompactacao == true)
                {
                    System.Threading.Tasks.Parallel.Invoke(new Action[]
                    {
                        () => RunCompactacao()
                    });
                }
            }
            catch
            { }
            finally
            { }
        }

        private void RunCompactacao()
        {
            int tempoChamada = 3000;
            Models.SqlServer.Enriquecimento.Fila fila = new Models.SqlServer.Enriquecimento.Fila();
            try
            {
                while (continuarExecutando == true)
                {
                    Thread.Sleep(tempoChamada);
                    try
                    {
                        fila = new Models.SqlServer.Enriquecimento.Fila();
                        fila = Service.Fila.RetornarJobCompactando((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground);
                        if ((fila != null) && (fila.IdFila > 0))
                        {
                            Common.Compactacao.CompactarJob(fila.IdFila);
                        }
                    }
                    catch
                    { }
                    finally
                    { }
                }
            }
            catch
            { }
            finally
            { }
        }
        #endregion
    }
}