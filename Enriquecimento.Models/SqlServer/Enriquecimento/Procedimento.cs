using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class Procedimento
    {
        public bool Ativo { get; set; }
        public DateTime Inclusao { get; set; }
        public long IdProcedimento { get; set; }
        public string Execucao { get; set; }
        public string Nome { get; set; }
        public string SufixoTabela { get; set; }
    }
}