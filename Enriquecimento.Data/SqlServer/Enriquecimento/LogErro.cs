using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class LogErro
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static Models.SqlServer.Enriquecimento.LogErro Insert(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.LogErro logErro)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.LogErro> list = new List<Models.SqlServer.Enriquecimento.LogErro>();
            parametros.Add("@IdFila", logErro.IdFila, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@Instrucao", logErro.Instrucao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@Erro", logErro.Erro, DbType.String, ParameterDirection.Input, 1000);
            parametros.Add("@Inclusao", logErro.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.LogErro>(
                    "[LogErroInsert]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.LogErro>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                logErro = list.First();
            }
            else
            {
                logErro = new Models.SqlServer.Enriquecimento.LogErro();
            }
            return (logErro);
        }

        public static void Delete(int origemAppsettingsJson, long idLogErro)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdLogErro", idLogErro, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                db.Query(
                    "[LogErroDelete]",
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
                    "[LogErroDeleteByIdFila]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}