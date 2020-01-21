using System;

namespace Enriquecimento.Models.SqlServer.ControleGerencial
{
    public class Cliente
    {
        public bool Ativo { get; set; }
        public DateTime Inclusao { get; set; }
        public long IdCliente { get; set; }
        public string LoginCliente { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
    }
}