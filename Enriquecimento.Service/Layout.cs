using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enriquecimento.Service
{
    public class Layout
    {
        public static List<Models.SqlServer.Enriquecimento.SpGetProcedimentos> GetProcedimentosAtivos(int origemAppsettingsJson, long idCliente)
        {
            List<Models.SqlServer.Enriquecimento.SpGetProcedimentos> list = new List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            list = Data.SqlServer.Enriquecimento.Procedures.SpGetProcedimentos(origemAppsettingsJson, idCliente);
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>> GetProcedimentosAtivosAsync(int origemAppsettingsJson, long idCliente)
        {
            List<Models.SqlServer.Enriquecimento.SpGetProcedimentos> list = new List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetProcedimentosAsync(origemAppsettingsJson, idCliente);
            return (list);
        }

        public static List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada> GetLayoutsEntradaAtivos(int origemAppsettingsJson, long idCliente,
            long idProcedimento)
        {
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            list = Data.SqlServer.Enriquecimento.Procedures.SpGetLayoutsEntrada(origemAppsettingsJson, idCliente, idProcedimento);
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>> GetLayoutsEntradaAtivosAsync(int origemAppsettingsJson, long idCliente,
            long idProcedimento)
        {
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetLayoutsEntradaAsync(origemAppsettingsJson, idCliente, idProcedimento);
            return (list);
        }

        public static List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida> GetLayoutsSaidaAtivos(int origemAppsettingsJson, long idCliente, long idProcedimento)
        {
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            list = Data.SqlServer.Enriquecimento.Procedures.SpGetLayoutsSaida(origemAppsettingsJson, idCliente, idProcedimento);
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>> GetLayoutsSaidaAtivosAsync(int origemAppsettingsJson, long idCliente,
            long idProcedimento)
        {
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetLayoutsSaidaAsync(origemAppsettingsJson, idCliente, idProcedimento);
            return (list);
        }

        public static async Task<Models.SqlServer.Enriquecimento.LayoutEntrada> GetLayoutEntrada(int origemAppsettingsJson, long idLayoutEntrada)
        {
            Models.SqlServer.Enriquecimento.LayoutEntrada layoutEntrada = new Models.SqlServer.Enriquecimento.LayoutEntrada();
            layoutEntrada = await Data.SqlServer.Enriquecimento.LayoutEntrada.GetByIdLayoutEntrada(origemAppsettingsJson, idLayoutEntrada);
            return (layoutEntrada);
        }

        public static async Task<Models.SqlServer.Enriquecimento.LayoutSaida> GetLayoutSaida(int origemAppsettingsJson, long idLayoutSaida)
        {
            Models.SqlServer.Enriquecimento.LayoutSaida layoutSaida = new Models.SqlServer.Enriquecimento.LayoutSaida();
            layoutSaida = await Data.SqlServer.Enriquecimento.LayoutSaida.GetByIdLayoutSaida(origemAppsettingsJson, idLayoutSaida);
            return (layoutSaida);
        }

        public static async Task<Models.SqlServer.Enriquecimento.LayoutDelimitador> GetLayoutDelimitador(int origemAppsettingsJson, long idLayoutDelimitador)
        {
            Models.SqlServer.Enriquecimento.LayoutDelimitador layoutDelimitador = new Models.SqlServer.Enriquecimento.LayoutDelimitador();
            layoutDelimitador = await Data.SqlServer.Enriquecimento.LayoutDelimitador.GetByIdLayoutDelimitador(origemAppsettingsJson, idLayoutDelimitador);
            return (layoutDelimitador);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>> GetSchemaLayoutEntrada(int origemAppsettingsJson,
            long idLayoutEntrada)
        {
            List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada> list = new List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetResumoLayoutEntrada(origemAppsettingsJson, idLayoutEntrada);
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>> GetSchemaLayoutSaida(int origemAppsettingsJson, long idLayoutSaida)
        {
            List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida> list = new List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetResumoLayoutSaida(origemAppsettingsJson, idLayoutSaida);
            return (list);
        }

        public static Models.SqlServer.Enriquecimento.ProcedimentoCliente GetProcedimentoCliente(int origemAppsettingsJson, long idProcedimento,
            long idLayoutEntrada, long idLayoutSaida, long idCliente)
        {
            Models.SqlServer.Enriquecimento.ProcedimentoCliente procedimentoCliente = new Models.SqlServer.Enriquecimento.ProcedimentoCliente();
            procedimentoCliente = Data.SqlServer.Enriquecimento.ProcedimentoCliente.GetByIdProcedimentoIdLayoutEntradaIdLayoutSaidaIdCliente(origemAppsettingsJson,
                idProcedimento, idLayoutEntrada, idLayoutSaida, idCliente);
            return (procedimentoCliente);
        }
    }
}