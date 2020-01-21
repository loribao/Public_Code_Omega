using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class LogErro
    {
        public DateTime Inclusao { get; set; }
        public long IdFila { get; set; }
        public long IdLogErro { get; set; }
        public string Erro { get; set; }
        public string Instrucao { get; set; }
    }
}