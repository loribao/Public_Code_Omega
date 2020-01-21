using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Enriquecimento.Data.SqlServer.Enriquecimento
{
    public class Fila
    {
        private static Models.Enumeradores.DBSqlServer dBSqlServer = (Models.Enumeradores.DBSqlServer)Models.Enumeradores.DBSqlServer.EnriquecimentoInfinit;
        private static string connectionString = dBSqlServer.ToString();

        public static async Task<Models.SqlServer.Enriquecimento.Fila> InsertAsync(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.Fila fila)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.Fila> list = new List<Models.SqlServer.Enriquecimento.Fila>();
            parametros.Add("@IdCliente", fila.IdCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@LoginCliente", fila.LoginCliente, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@IdUsuario", fila.IdUsuario, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@LoginUsuario", fila.LoginUsuario, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@IdAcesso", fila.IdAcesso, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@NomeJob", fila.NomeJob, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@NomeTabela", fila.NomeTabela, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@NomeArquivo", fila.NomeArquivo, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@CaminhoEntradaAplicacao", fila.CaminhoEntradaAplicacao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@CaminhoEntradaBanco", fila.CaminhoEntradaBanco, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@ArquivoEntrada", fila.ArquivoEntrada, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@ArquivoEntradaOriginal", fila.ArquivoEntradaOriginal, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@CaminhoSaidaAplicacao", fila.CaminhoSaidaAplicacao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@CaminhoSaidaBanco", fila.CaminhoSaidaBanco, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@ArquivoSaida", fila.ArquivoSaida, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@IdStatusJob", fila.IdStatusJob, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", fila.IdProcedimento, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutEntrada", fila.IdLayoutEntrada, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutSaida", fila.IdLayoutSaida, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@QuantidadeRegistrosEntrada", fila.QuantidadeRegistrosEntrada, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add("@QuantidadeRegistrosSaida", fila.QuantidadeRegistrosSaida, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add("@Inclusao", fila.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            parametros.Add("@Finalizacao", fila.Finalizacao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.Fila>(
                    "[FilaInsert]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.Fila>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                fila = list.First();
            }
            else
            {
                fila = new Models.SqlServer.Enriquecimento.Fila();
            }
            return (fila);
        }

        public static async Task<Models.SqlServer.Enriquecimento.Fila> UpdateAsync(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.Fila fila)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.Fila> list = new List<Models.SqlServer.Enriquecimento.Fila>();
            parametros.Add("@IdFila", fila.IdFila, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdCliente", fila.IdCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@LoginCliente", fila.LoginCliente, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@IdUsuario", fila.IdUsuario, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@LoginUsuario", fila.LoginUsuario, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@IdAcesso", fila.IdAcesso, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@NomeJob", fila.NomeJob, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@NomeTabela", fila.NomeTabela, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@NomeArquivo", fila.NomeArquivo, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@CaminhoEntradaAplicacao", fila.CaminhoEntradaAplicacao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@CaminhoEntradaBanco", fila.CaminhoEntradaBanco, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@ArquivoEntrada", fila.ArquivoEntrada, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@ArquivoEntradaOriginal", fila.ArquivoEntradaOriginal, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@CaminhoSaidaAplicacao", fila.CaminhoSaidaAplicacao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@CaminhoSaidaBanco", fila.CaminhoSaidaBanco, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@ArquivoSaida", fila.ArquivoSaida, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@IdStatusJob", fila.IdStatusJob, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", fila.IdProcedimento, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutEntrada", fila.IdLayoutEntrada, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutSaida", fila.IdLayoutSaida, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@QuantidadeRegistrosEntrada", fila.QuantidadeRegistrosEntrada, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add("@QuantidadeRegistrosSaida", fila.QuantidadeRegistrosSaida, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add("@Inclusao", fila.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            parametros.Add("@Finalizacao", fila.Finalizacao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = (await db.QueryAsync<Models.SqlServer.Enriquecimento.Fila>(
                    "[FilaUpdate]",
                    parametros,
                    commandType: CommandType.StoredProcedure));
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.Fila>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                fila = list.First();
            }
            else
            {
                fila = new Models.SqlServer.Enriquecimento.Fila();
            }
            return (fila);
        }

        public static Models.SqlServer.Enriquecimento.Fila Update(int origemAppsettingsJson, Models.SqlServer.Enriquecimento.Fila fila)
        {
            var parametros = new DynamicParameters();
            List<Models.SqlServer.Enriquecimento.Fila> list = new List<Models.SqlServer.Enriquecimento.Fila>();
            parametros.Add("@IdFila", fila.IdFila, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdCliente", fila.IdCliente, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@LoginCliente", fila.LoginCliente, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@IdUsuario", fila.IdUsuario, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@LoginUsuario", fila.LoginUsuario, DbType.String, ParameterDirection.Input, 30);
            parametros.Add("@IdAcesso", fila.IdAcesso, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@NomeJob", fila.NomeJob, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@NomeTabela", fila.NomeTabela, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@NomeArquivo", fila.NomeArquivo, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@CaminhoEntradaAplicacao", fila.CaminhoEntradaAplicacao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@CaminhoEntradaBanco", fila.CaminhoEntradaBanco, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@ArquivoEntrada", fila.ArquivoEntrada, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@ArquivoEntradaOriginal", fila.ArquivoEntradaOriginal, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@CaminhoSaidaAplicacao", fila.CaminhoSaidaAplicacao, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@CaminhoSaidaBanco", fila.CaminhoSaidaBanco, DbType.String, ParameterDirection.Input, 500);
            parametros.Add("@ArquivoSaida", fila.ArquivoSaida, DbType.String, ParameterDirection.Input, 255);
            parametros.Add("@IdStatusJob", fila.IdStatusJob, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdProcedimento", fila.IdProcedimento, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutEntrada", fila.IdLayoutEntrada, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@IdLayoutSaida", fila.IdLayoutSaida, DbType.Int64, ParameterDirection.Input, null);
            parametros.Add("@QuantidadeRegistrosEntrada", fila.QuantidadeRegistrosEntrada, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add("@QuantidadeRegistrosSaida", fila.QuantidadeRegistrosSaida, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add("@Inclusao", fila.Inclusao, DbType.DateTime, ParameterDirection.Input, null);
            parametros.Add("@Finalizacao", fila.Finalizacao, DbType.DateTime, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.Fila>(
                    "[FilaUpdate]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.Fila>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                fila = list.First();
            }
            else
            {
                fila = new Models.SqlServer.Enriquecimento.Fila();
            }
            return (fila);
        }

        public static Models.SqlServer.Enriquecimento.Fila GetByIdFila(int origemAppsettingsJson, long idFila)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.Fila fila = new Models.SqlServer.Enriquecimento.Fila();
            List<Models.SqlServer.Enriquecimento.Fila> list = new List<Models.SqlServer.Enriquecimento.Fila>();
            parametros.Add("@IdFila", idFila, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.Fila>(
                    "[FileGetByIdFila]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.Fila>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                fila = list.First();
            }
            else
            {
                fila = new Models.SqlServer.Enriquecimento.Fila();
            }
            return (fila);
        }

        public static Models.SqlServer.Enriquecimento.Fila GetByIdStatusJob(int origemAppsettingsJson, long idStatusJob)
        {
            var parametros = new DynamicParameters();
            Models.SqlServer.Enriquecimento.Fila fila = new Models.SqlServer.Enriquecimento.Fila();
            List<Models.SqlServer.Enriquecimento.Fila> list = new List<Models.SqlServer.Enriquecimento.Fila>();
            parametros.Add("@IdStatusJob", idStatusJob, DbType.Int64, ParameterDirection.Input, null);
            using (SqlConnection db = new SqlConnection(Utils.AppConfiguration.GetAppConfiguration(origemAppsettingsJson).GetConnectionString(connectionString)))
            {
                var result = db.Query<Models.SqlServer.Enriquecimento.Fila>(
                    "[FileGetByIdStatusJob]",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    list = result.ToList<Models.SqlServer.Enriquecimento.Fila>();
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                fila = list.First();
            }
            else
            {
                fila = new Models.SqlServer.Enriquecimento.Fila();
            }
            return (fila);
        }
    }
}