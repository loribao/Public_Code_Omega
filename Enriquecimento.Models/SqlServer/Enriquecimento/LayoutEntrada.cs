using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class LayoutEntrada
    {
        public bool Ativo { get; set; }
        public bool NomesColunasPrimeiraLinha { get; set; }
        public DateTime Inclusao { get; set; }
        public long IdLayoutDelimitador { get; set; }
        public long IdLayoutEntrada { get; set; }
        public string DatabaseTabela { get; set; }
        public string Nome { get; set; }
        public string SufixoTabela { get; set; }
        public string Tabela { get; set; }
    }
}