using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class LayoutSaida
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static async Task<Models.SqlServer.Enriquecimento.LayoutSaida> GetByIdLayoutSaida(int origemAppsettingsJson, long idLayoutSaida)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.LayoutSaida layoutSaida = new Models.SqlServer.Enriquecimento.LayoutSaida();
            List<Models.SqlServer.Enriquecimento.LayoutSaida> list = new List<Models.SqlServer.Enriquecimento.LayoutSaida>();
            parametros.Add("@IdLayoutSaida", idLayoutSaida, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.LayoutSaida>(
                    "[LayoutSaidaGetByIdLayoutSaida]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.LayoutSaida>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                layoutSaida = list.First();
            }
            else
            {
                layoutSaida = new Models.SqlServer.Enriquecimento.LayoutSaida();
            }
            return (layoutSaida);
        }
    }
}