using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class LogProcessamento
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static Models.SqlServer.Enriquecimento.LogProcessamento Insert(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.LogProcessamento logProcessamento)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.LogProcessamento> list = new List<Models.SqlServer.Enriquecimento.LogProcessamento>();
            parametros.Add("@IdFila", logProcessamento.IdFila, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@Instrucao", logProcessamento.Instrucao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@Descricao", logProcessamento.Descricao, DbType.String, ParameterDirection.Input, 1000);
            parametros.Add("@Inclusao", logProcessamento.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.LogProcessamento>(
                    "[LogProcessamentoInsert]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.LogProcessamento>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                logProcessamento = list.First();
            }
            else
            {
                logProcessamento = new Models.SqlServer.Enriquecimento.LogProcessamento();
            }
            return (logProcessamento);
        }

        public static void Delete(int origemAppsettingsJson, long idLogProcessamento)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdLogProcessamento", idLogProcessamento, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                db.Query(
                    "[LogProcessamentoDelete]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void DeleteByIdFila(int origemAppsettingsJson, long idFila)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdFila", idFila, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                db.Query(
                    "[LogProcessamentoDeleteByIdFila]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}