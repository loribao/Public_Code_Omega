using System;

namespace Enriquecimento.Models.SqlServer.ControleGerencial
{
    public class Usuario
    {
        public bool Ativo { get; set; }
        public DateTime Inclusao { get; set; }
        public long IdCliente { get; set; }
        public long IdUsuario { get; set; }
        public string Email { get; set; }
        public string LoginUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}