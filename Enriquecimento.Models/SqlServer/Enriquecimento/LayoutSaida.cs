using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class LayoutSaida
    {
        public bool Ativo { get; set; }
        public bool NomesColunasPrimeiraLinha { get; set; }
        public DateTime Inclusao { get; set; }
        public long IdLayoutDelimitador { get; set; }
        public long IdLayoutSaida { get; set; }
        public string DatabaseTabela { get; set; }
        public string Nome { get; set; }
        public string Tabela { get; set; }
    }
}