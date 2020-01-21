using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Enriquecimento.Data.SqlServer.ControleGerencial
{
    public class Procedures
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.ControleGerencialInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto SpValidarClienteUsuarioProduto(int origemAppsettingsJson, string usuario,
            string senha, string cliente, string ip, long idProduto)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto spValidarClienteUsuarioProduto = null;
            List<Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto> list = new List<Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto>();
            parametros.Add("@Usuario", usuario, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@Senha", senha, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@Cliente", cliente, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@Ip", ip, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@IdProduto", idProduto, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                list = db.Query<Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto>(
                    "[SpValidarClienteUsuarioProduto]",
                    parametros,
                    commandType: CommandType.StoredProcedure).ToList<Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto>();
            }
            if ((list != null) && (list.Count > 0))
            {
                spValidarClienteUsuarioProduto = list.First();
            }
            else
            {
                spValidarClienteUsuarioProduto = new Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto();
            }
            return (spValidarClienteUsuarioProduto);
        }

        public static Models.SqlServer.ControleGerencial.SpGetInformacoesLogin SpGetInformacoesLogin(int origemAppsettingsJson, long idAcesso)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.ControleGerencial.SpGetInformacoesLogin spGetInformacoesLogin = null;
            List<Models.SqlServer.ControleGerencial.SpGetInformacoesLogin> list = null;
            parametros.Add("@IdAcesso", idAcesso, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                list = db.Query<Models.SqlServer.ControleGerencial.SpGetInformacoesLogin>(
                    "[SpGetInformacoesLogin]",
                    parametros,
                    commandType: CommandType.StoredProcedure).ToList<Models.SqlServer.ControleGerencial.SpGetInformacoesLogin>();
            }
            if ((list != null) && (list.Count > 0))
            {
                spGetInformacoesLogin = list.First();
            }
            else
            {
                spGetInformacoesLogin = new Models.SqlServer.ControleGerencial.SpGetInformacoesLogin();
            }
            return (spGetInformacoesLogin);
        }
    }
}