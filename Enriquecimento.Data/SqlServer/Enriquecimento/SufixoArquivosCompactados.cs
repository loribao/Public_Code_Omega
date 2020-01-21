using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class SufixoArquivosCompactados
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados> GetByIdProcedimentoCliente(int origemAppsettingsJson,
            long idProcedimentoCliente)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados> list = new List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados>();
            parametros.Add("@IdProcedimentoCliente", idProcedimentoCliente, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados>(
                    "[SufixoArquivosCompactadosGetByIdProcedimentoCliente]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados>();
                }
            }
            if (list == null)
            {
                list = new List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados>();
            }
            return (list);
        }
    }
}