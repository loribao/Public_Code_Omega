namespace Enriquecimento.Service
{
    public class Logs
    {
        public static Models.SqlServer.Enriquecimento.LogProcessamento InserirLogDeProcessamento(int origemAppsettingsJson,
            Models.SqlServer.Enriquecimento.LogProcessamento logProcessamento)
        {
            logProcessamento = Data.SqlServer.Enriquecimento.LogProcessamento.Insert(origemAppsettingsJson, logProcessamento);
            return (logProcessamento);
        }

        public static Models.SqlServer.Enriquecimento.LogErro InserirLogDeErro(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.LogErro logErro)
        {
            logErro = Data.SqlServer.Enriquecimento.LogErro.Insert(origemAppsettingsJson, logErro);
            return (logErro);
        }
    }
}