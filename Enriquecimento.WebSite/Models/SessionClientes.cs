using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class SessionClientes
    {
        ////Nome da Session = Clientes
        public List<Cliente> Clientes { get; set; }
        public class Cliente
        {
            public long Id { get; set; }
            public long IdCliente { get; set; }
            public string NomeCliente { get; set; }
        }
    }
}