using System;

namespace Enriquecimento.Models.SqlServer.ControleGerencial
{
    public class Acesso
    {
        public DateTime Inclusao { get; set; }
        public long IdAcesso { get; set; }
        public long IdProduto { get; set; }
        public long IdUsuario { get; set; }
        public string IP { get; set; }
    }
}