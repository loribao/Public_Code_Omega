using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.ControleGerencial
{
    public class Acesso
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.ControleGerencialInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static Models.SqlServer.ControleGerencial.Acesso Insert(int origemAppsettingsJson, Models.SqlServer.ControleGerencial.Acesso acesso)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.ControleGerencial.Acesso> list = null;
            parametros.Add("@IdUsuario", acesso.IdUsuario, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProduto", acesso.IdProduto, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IP", acesso.IP, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@Inclusao", acesso.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                list = db.Query<Models.SqlServer.ControleGerencial.Acesso>(
                    "[AcessoInsert]",
                    parametros,
                    commandType: CommandType.StoredProcedure).ToList<Models.SqlServer.ControleGerencial.Acesso>();
            }
            if ((list != null) && (list.Count > 0))
            {
                acesso = list.First();
            }
            else
            {
                acesso = new Models.SqlServer.ControleGerencial.Acesso();
            }
            return (acesso);
        }
    }
}