namespace Enriquecimento.Models.SqlServer.ControleGerencial
{
    public class SpValidarClienteUsuarioProduto
    {
        public long? IdCliente { get; set; }
        public string Cliente { get; set; }
        public long? IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Erro { get; set; }
    }
}