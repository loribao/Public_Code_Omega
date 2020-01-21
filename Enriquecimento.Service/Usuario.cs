namespace Enriquecimento.Service
{
    public class Usuario
    {
        public static Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto AutenticarUsuario(int origemAppsettingsJson, string usuario, string senha,
            string cliente, string ip, long idProduto)
        {
            Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto spValidarClienteUsuarioProduto = null;
            spValidarClienteUsuarioProduto = Data.SqlServer.ControleGerencial.Procedures.SpValidarClienteUsuarioProduto(origemAppsettingsJson, usuario, senha,
                cliente, ip, idProduto);
            return (spValidarClienteUsuarioProduto);
        }

        public static Models.SqlServer.ControleGerencial.Acesso InserirNoHistoricoDeAcesso(int origemAppsettingsJson, Models.SqlServer.ControleGerencial.Acesso acesso)
        {
            acesso = Enriquecimento.Data.SqlServer.ControleGerencial.Acesso.Insert(origemAppsettingsJson, acesso);
            return (acesso);
        }

        public static Models.SqlServer.ControleGerencial.SpGetInformacoesLogin GetInformacoesLogin(int origemAppsettingsJson, long idAcesso)
        {
            Models.SqlServer.ControleGerencial.SpGetInformacoesLogin spGetInformacoesLogin = null;
            spGetInformacoesLogin = Enriquecimento.Data.SqlServer.ControleGerencial.Procedures.SpGetInformacoesLogin(origemAppsettingsJson, idAcesso);
            return (spGetInformacoesLogin);
        }
    }
}