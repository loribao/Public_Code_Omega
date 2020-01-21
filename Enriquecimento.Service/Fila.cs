using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enriquecimento.Service
{
    public class Fila
    {
        public static string GerarNomeJob(string arquivo)
        {
            string job = "";
            if (string.IsNullOrEmpty(arquivo) == true)
            {
                arquivo = "";
            }
            job = arquivo;
            //Retirar a extensão do arquivo
            if (job.Contains(".") == true)
            {
                job = Utils.Funcoes.Reverse(job);
                job = job.Substring(job.IndexOf('.') + 1);
                job = Utils.Funcoes.Reverse(job);
            }
            job = Utils.Funcoes.RemoverEspacoDuplos(job);
            job = job.Trim();
            job = Utils.Funcoes.RemoverAcentos(job);
            job = Utils.Funcoes.RemoverCaractersInvalidos(job);
            job = Utils.Funcoes.RemoverEspacoDuplos(job);
            job = job.Trim();
            job = job.Replace(" ", "_");
            return (job);
        }

        public static string GerarNomeTabela(string arquivo, DateTime dataHora)
        {
            string tabela = "";
            string data = "";
            string hora = "";
            if (String.IsNullOrEmpty(arquivo) == true)
            {
                arquivo = "";
            }
            tabela = arquivo;
            //Retirar a extensão do arquivo
            if (tabela.Contains(".") == true)
            {
                tabela = Utils.Funcoes.Reverse(tabela);
                tabela = tabela.Substring(tabela.IndexOf('.') + 1);
                tabela = Utils.Funcoes.Reverse(tabela);
            }
            tabela = Utils.Funcoes.RemoverEspacoDuplos(tabela);
            tabela = tabela.Trim();
            tabela = Utils.Funcoes.RemoverAcentos(tabela);
            tabela = Utils.Funcoes.RemoverCaractersInvalidos(tabela);
            tabela = Utils.Funcoes.RemoverEspacoDuplos(tabela);
            tabela = tabela.Trim();
            tabela = tabela.Replace(" ", "_");
            data = dataHora.ToString("ddMMyyyy");
            tabela = tabela + "_" + "DT" + data;
            hora = dataHora.ToString("HH:mm:ss.fff");
            hora = hora.Replace(":", "");
            hora = hora.Replace(".", "");
            tabela = tabela + "_" + "HR" + hora;
            return (tabela);
        }

        public static async Task<Models.SqlServer.Enriquecimento.Fila> InserirJob(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.Fila fila)
        {
            fila = await Data.SqlServer.Enriquecimento.Fila.InsertAsync(origemAppsettingsJson, fila);
            return (fila);
        }

        public static Models.SqlServer.Enriquecimento.Fila AlterarInformacoesJob(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.Fila fila)
        {
            fila = Data.SqlServer.Enriquecimento.Fila.Update(origemAppsettingsJson, fila);
            return (fila);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetFila>> RetornarFilaDeJobs(int origemAppsettingsJson, long idCliente)
        {
            List<Models.SqlServer.Enriquecimento.SpGetFila> list = new List<Models.SqlServer.Enriquecimento.SpGetFila>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetFila(origemAppsettingsJson, idCliente);
            return (list);
        }

        public static Models.SqlServer.Enriquecimento.SpGetInformacoesJob RetornarInformacoesJob(int origemAppsettingsJson, long idFila)
        {
            Models.SqlServer.Enriquecimento.SpGetInformacoesJob spGetInformacoesJob = new Models.SqlServer.Enriquecimento.SpGetInformacoesJob();
            spGetInformacoesJob = Data.SqlServer.Enriquecimento.Procedures.SpGetInformacoesJob(origemAppsettingsJson, idFila);
            return (spGetInformacoesJob);
        }

        public static async Task<Models.SqlServer.Enriquecimento.SpGetInformacoesJob> RetornarInformacoesJobAsync(int origemAppsettingsJson, long idFila)
        {
            {
                Models.SqlServer.Enriquecimento.SpGetInformacoesJob spGetInformacoesJob = new Models.SqlServer.Enriquecimento.SpGetInformacoesJob();
                spGetInformacoesJob = await Data.SqlServer.Enriquecimento.Procedures.SpGetInformacoesJobAsync(origemAppsettingsJson, idFila);
                return (spGetInformacoesJob);
            }
        }

        public static Models.SqlServer.Enriquecimento.Fila RetornarJob(int origemAppsettingsJson, long idFila)
        {
            Models.SqlServer.Enriquecimento.Fila fila = new Models.SqlServer.Enriquecimento.Fila();
            fila = Enriquecimento.Data.SqlServer.Enriquecimento.Fila.GetByIdFila(origemAppsettingsJson, idFila);
            return (fila);
        }

        public static Models.SqlServer.Enriquecimento.HistoricoDownload InserirDownloadArquivoEntrada(int origemAppsettingsJson,
            Models.SqlServer.Enriquecimento.HistoricoDownload historicoDownload)
        {
            historicoDownload = Data.SqlServer.Enriquecimento.HistoricoDownload.Insert(origemAppsettingsJson, historicoDownload);
            return (historicoDownload);
        }

        public static Models.SqlServer.Enriquecimento.Fila RetornarJobCompactando(int origemAppsettingsJson)
        {
            long idStatusJob = 0;
            Models.SqlServer.Enriquecimento.Fila fila = new Models.SqlServer.Enriquecimento.Fila();
            idStatusJob = (long)Models.Enumeradores.StatusJob.Compactando;
            fila = Data.SqlServer.Enriquecimento.Fila.GetByIdStatusJob(origemAppsettingsJson, idStatusJob);
            return (fila);
        }
    }
}