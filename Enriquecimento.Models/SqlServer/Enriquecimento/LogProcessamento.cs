using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class LogProcessamento
    {
        public DateTime Inclusao { get; set; }
        public long IdFila { get; set; }
        public long IdLogProcessamento { get; set; }
        public string Descricao { get; set; }
        public string Instrucao { get; set; }
    }
}