using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class LayoutEntrada
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static async Task<Models.SqlServer.Enriquecimento.LayoutEntrada> GetByIdLayoutEntrada(int origemAppsettingsJson, long idLayoutEntrada)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.LayoutEntrada layoutEntrada = new Models.SqlServer.Enriquecimento.LayoutEntrada();
            List<Models.SqlServer.Enriquecimento.LayoutEntrada> list = new List<Models.SqlServer.Enriquecimento.LayoutEntrada>();
            parametros.Add("@IdLayoutEntrada", idLayoutEntrada, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.LayoutEntrada>(
                    "[LayoutEntradaGetByIdLayoutEntrada]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.LayoutEntrada>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                layoutEntrada = list.First();
            }
            else
            {
                layoutEntrada = new Models.SqlServer.Enriquecimento.LayoutEntrada();
            }
            return (layoutEntrada);
        }
    }
}