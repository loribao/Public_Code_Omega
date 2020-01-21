using System;
using System.Collections.Generic;

namespace Enriquecimento.WinService.Common
{
    public class Compactacao
    {
        public static void CompactarJob(long idFila)
        {
            long idStatusJob = 0;
            DateTime? finalizacao = null;
            Models.SqlServer.Enriquecimento.Fila fila = new Models.SqlServer.Enriquecimento.Fila();
            Models.SqlServer.Enriquecimento.LogErro logErro = new Models.SqlServer.Enriquecimento.LogErro();
            Models.SqlServer.Enriquecimento.LogProcessamento logProcessamento = new Models.SqlServer.Enriquecimento.LogProcessamento();
            Models.SqlServer.Enriquecimento.ProcedimentoCliente procedimentoCliente = new Models.SqlServer.Enriquecimento.ProcedimentoCliente();
            List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados> listSufixoArquivosCompactados = new List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados>();
            try
            {
                fila = Service.Fila.RetornarJob((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground, idFila);
                idStatusJob = fila.IdStatusJob;
                if ((fila != null) && (fila.IdFila > 0))
                {
                    //Inserir no log de processamento
                    logProcessamento = new Models.SqlServer.Enriquecimento.LogProcessamento();
                    logProcessamento.IdFila = fila.IdFila;
                    logProcessamento.Instrucao = "Serviço de Compactação";
                    logProcessamento.Descricao = "Início do processo de compactação dos arquivos de saída";
                    logProcessamento.Inclusao = DateTime.Now;
                    logProcessamento = Service.Logs.InserirLogDeProcessamento((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground, logProcessamento);

                    //Deletar caso o arquivo .zip já existe na pasta /processado/
                    Service.Arquivo.DeletarArquivoZip(fila.CaminhoSaidaBanco, fila.ArquivoSaida);
                    //Copiar o arquivo original para a pasta /processado/
                    Service.Arquivo.CopiarArquivoOriginalParaPastaProcessado(fila.CaminhoEntradaBanco, fila.ArquivoEntrada, fila.CaminhoSaidaBanco);
                    //Gerar o arquivo .zip
                    procedimentoCliente = Service.Layout.GetProcedimentoCliente((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground, fila.IdProcedimento,
                        fila.IdLayoutEntrada, fila.IdLayoutSaida, fila.IdCliente);
                    listSufixoArquivosCompactados = Service.Arquivo.RetornarSufixoArquivosASerCompactados((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground,
                        procedimentoCliente.IdProcedimentoCliente);
                    Service.Arquivo.GerarArquivoCompactado(fila.NomeArquivo, fila.CaminhoSaidaBanco, fila.ArquivoSaida,
                        listSufixoArquivosCompactados);

                    //Inserir no log de processamento
                    logProcessamento = new Models.SqlServer.Enriquecimento.LogProcessamento();
                    logProcessamento.IdFila = fila.IdFila;
                    logProcessamento.Instrucao = "Serviço de Compactação";
                    logProcessamento.Descricao = "Finalizado o processo de compactação dos arquivos de saída";
                    logProcessamento.Inclusao = DateTime.Now;
                    logProcessamento = Service.Logs.InserirLogDeProcessamento((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground, logProcessamento);
                }
                idStatusJob = (long)Models.Enumeradores.StatusJob.Processado;
                finalizacao = DateTime.Now;
            }
            catch (Exception ex)
            {
                if ((fila != null) && (fila.IdFila > 0))
                {
                    logErro = new Models.SqlServer.Enriquecimento.LogErro();
                    logErro.IdFila = fila.IdFila;
                    logErro.Instrucao = "Serviço de Compactação";
                    logErro.Erro = ex.Message.ToString();
                    logErro.Inclusao = DateTime.Now;
                    logErro = Service.Logs.InserirLogDeErro((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground, logErro);
                }
                idStatusJob = (long)Models.Enumeradores.StatusJob.Erro;
            }
            finally
            {
                try
                {
                    if ((fila != null) && (fila.IdFila > 0))
                    {
                        fila.IdStatusJob = idStatusJob;
                        if (idStatusJob == (long)Models.Enumeradores.StatusJob.Processado)
                        {
                            fila.Finalizacao = finalizacao;
                        }
                        else
                        {
                            fila.Finalizacao = null;
                            fila.QuantidadeRegistrosSaida = 0;
                        }
                        fila = Service.Fila.AlterarInformacoesJob((int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground, fila);
                    }
                }
                catch
                { }
                finally
                { }
            }
        }
    }
}