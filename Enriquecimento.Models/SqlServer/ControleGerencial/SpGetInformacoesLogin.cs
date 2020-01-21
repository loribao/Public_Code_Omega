using System;

namespace Enriquecimento.Models.SqlServer.ControleGerencial
{
    public class SpGetInformacoesLogin
    {
        public long IdCliente { get; set; }
        public string LoginCliente { get; set; }
        public string RazaoSocialCliente { get; set; }
        public DateTime InclusaoCliente { get; set; }
        public long IdUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public DateTime InclusaoUsuario { get; set; }
        public long IdProduto { get; set; }
        public string Produto { get; set; }
    }
}