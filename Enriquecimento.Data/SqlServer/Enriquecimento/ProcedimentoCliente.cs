using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class ProcedimentoCliente
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static Models.SqlServer.Enriquecimento.ProcedimentoCliente GetByIdProcedimentoIdLayoutEntradaIdLayoutSaidaIdCliente(int origemAppsettingsJson,
            long idProcedimento, long idLayoutEntrada, long idLayoutSaida, long idCliente)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.ProcedimentoCliente procedimentoCliente = new Models.SqlServer.Enriquecimento.ProcedimentoCliente();
            List<Models.SqlServer.Enriquecimento.ProcedimentoCliente> list = new List<Models.SqlServer.Enriquecimento.ProcedimentoCliente>();
            parametros.Add("@IdProcedimento", idProcedimento, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutEntrada", idLayoutEntrada, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutSaida", idLayoutSaida, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdCliente", idCliente, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.ProcedimentoCliente>(
                    "[ProcedimentoClienteGetByIdProcedimentoIdLayoutEntradaIdLayoutSaidaIdCliente]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.ProcedimentoCliente>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                procedimentoCliente = list.First();
            }
            else
            {
                procedimentoCliente = new Models.SqlServer.Enriquecimento.ProcedimentoCliente();
            }
            return (procedimentoCliente);
        }
    }
}