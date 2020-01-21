using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class HistoricoDownload
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static Models.SqlServer.Enriquecimento.HistoricoDownload Insert(int origemAppsettingsJson,
            Models.SqlServer.Enriquecimento.HistoricoDownload historicoDownload)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.HistoricoDownload> list = new List<Models.SqlServer.Enriquecimento.HistoricoDownload>();
            parametros.Add("@IdFila", historicoDownload.IdFila, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdCliente", historicoDownload.IdCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdUsuario", historicoDownload.IdUsuario, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdAcesso", historicoDownload.IdAcesso, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@ArquivoEntrada", historicoDownload.ArquivoEntrada, DbType.Boolean, ParameterDirection.Input, null);
            parametros.Add("@ArquivoSaida", historicoDownload.ArquivoSaida, DbType.Boolean, ParameterDirection.Input, null);
            parametros.Add("@Inclusao", historicoDownload.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.HistoricoDownload>(
                    "[HistoricoDownloadInsert]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.HistoricoDownload>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                historicoDownload = list.First();
            }
            else
            {
                historicoDownload = new Models.SqlServer.Enriquecimento.HistoricoDownload();
            }
            return (historicoDownload);
        }
    }
}