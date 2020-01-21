using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class LayoutDelimitador
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static async Task<Models.SqlServer.Enriquecimento.LayoutDelimitador> GetByIdLayoutDelimitador(int origemAppsettingsJson, long idLayoutDelimitador)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.LayoutDelimitador layoutDelimitador = new Models.SqlServer.Enriquecimento.LayoutDelimitador();
            List<Models.SqlServer.Enriquecimento.LayoutDelimitador> list = new List<Models.SqlServer.Enriquecimento.LayoutDelimitador>();
            parametros.Add("@IdLayoutDelimitador", idLayoutDelimitador, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.LayoutDelimitador>(
                    "[LayoutDelimitadorGetByIdLayoutDelimitador]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.LayoutDelimitador>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                layoutDelimitador = list.First();
            }
            else
            {
                layoutDelimitador = new Models.SqlServer.Enriquecimento.LayoutDelimitador();
            }
            return (layoutDelimitador);
        }
    }
}