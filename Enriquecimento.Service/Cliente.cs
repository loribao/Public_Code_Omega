using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enriquecimento.Service
{
    public class Cliente
    {
        public static async Task<List<Models.SqlServer.Enriquecimento.SpGetClientes>> GetClientesAtivos(int origemAppsettingsJson, long idCliente, long idUsuario)
        {
            long idProduto = (long)Models.Enumeradores.Produto.Enriquecimento;
            long idClienteEmpresa = (long)Models.Enumeradores.Cliente.Infinit;
            List<Models.SqlServer.Enriquecimento.SpGetClientes> list = new List<Models.SqlServer.Enriquecimento.SpGetClientes>();
            list = await Data.SqlServer.Enriquecimento.Procedures.SpGetClientes(origemAppsettingsJson, idCliente, idUsuario, idProduto, idClienteEmpresa);
            return (list);
        }
    }
}