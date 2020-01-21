using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class Procedures
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetClientes>> SpGetClientes(int origemAppsettingsJson, long idCliente, long idUsuario,
            long idProduto, long idClienteEmpresa)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetClientes> list = new List<Models.SqlServer.Enriquecimento.SpGetClientes>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdUsuario", idUsuario, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProduto", idProduto, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdClienteEmpresa", idClienteEmpresa, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetClientes>(
                    "[SpGetClientes]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetClientes>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetClientes>();
            }
            return (list);
        }

        public static List<Models.SqlServer.Enriquecimento.SpGetProcedimentos> SpGetProcedimentos(int origemAppsettingsJson, long idCliente)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetProcedimentos> list = new List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.SpGetProcedimentos>(
                    "[SpGetProcedimentos]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            }
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>> SpGetProcedimentosAsync(int origemAppsettingsJson, long idCliente)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetProcedimentos> list = new List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetProcedimentos>(
                    "[SpGetProcedimentos]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            }
            return (list);
        }

        public static List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada> SpGetLayoutsEntrada(int origemAppsettingsJson, long idCliente, long idProcedimento)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", idProcedimento, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>(
                    "[SpGetLayoutsEntrada]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            }
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>> SpGetLayoutsEntradaAsync(int origemAppsettingsJson, long idCliente,
            long idProcedimento)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", idProcedimento, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>(
                    "[SpGetLayoutsEntrada]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            }
            return (list);
        }

        public static List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida> SpGetLayoutsSaida(int origemAppsettingsJson, long idCliente, long idProcedimento)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", idProcedimento, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>(
                    "[SpGetLayoutsSaida]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            }
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>> SpGetLayoutsSaidaAsync(int origemAppsettingsJson, long idCliente,
            long idProcedimento)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida> list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", idProcedimento, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>(
                    "[SpGetLayoutsSaida]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            }
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>> SpGetResumoLayoutEntrada(int origemAppsettingsJson,
            long idLayoutEntrada)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada> list = new List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>();
            parametros.Add("@IdLayoutEntrada", idLayoutEntrada, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>(
                    "[SpGetResumoLayoutEntrada]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>();
            }
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>> SpGetResumoLayoutSaida(int origemAppsettingsJson, long idLayoutSaida)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida> list = new List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>();
            parametros.Add("@IdLayoutSaida", idLayoutSaida, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>(
                    "[SpGetResumoLayoutSaida]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>();
            }
            return (list);
        }

        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetFila>> SpGetFila(int origemAppsettingsJson, long idCliente)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SpGetFila> list = new List<Models.SqlServer.Enriquecimento.SpGetFila>();
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetFila>(
                    "[SpGetFila]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetFila>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SpGetFila>();
            }
            return (list);
        }

        public static Models.SqlServer.Enriquecimento.SpGetInformacoesJob SpGetInformacoesJob(int origemAppsettingsJson, long idFila)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.SpGetInformacoesJob spGetInformacoesJob = new Models.SqlServer.Enriquecimento.SpGetInformacoesJob();
            List<Models.SqlServer.Enriquecimento.SpGetInformacoesJob> list = new List<Models.SqlServer.Enriquecimento.SpGetInformacoesJob>();
            parametros.Add("@IdFila", idFila, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.SpGetInformacoesJob>(
                    "[SpGetInformacoesJob]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetInformacoesJob>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                spGetInformacoesJob = list.First();
            }
            else
            {
                spGetInformacoesJob = new Models.SqlServer.Enriquecimento.SpGetInformacoesJob();
            }
            return (spGetInformacoesJob);
        }

        public static async Task<Models.SqlServer.Enriquecimento.SpGetInformacoesJob> SpGetInformacoesJobAsync(int origemAppsettingsJson, long idFila)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.SpGetInformacoesJob spGetInformacoesJob = new Models.SqlServer.Enriquecimento.SpGetInformacoesJob();
            List<Models.SqlServer.Enriquecimento.SpGetInformacoesJob> list = new List<Models.SqlServer.Enriquecimento.SpGetInformacoesJob>();
            parametros.Add("@IdFila", idFila, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = await db.QueryAsync<Models.SqlServer.Enriquecimento.SpGetInformacoesJob>(
                    "[SpGetInformacoesJob]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SpGetInformacoesJob>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                spGetInformacoesJob = list.First();
            }
            else
            {
                spGetInformacoesJob = new Models.SqlServer.Enriquecimento.SpGetInformacoesJob();
            }
            return (spGetInformacoesJob);
        }
    }
}