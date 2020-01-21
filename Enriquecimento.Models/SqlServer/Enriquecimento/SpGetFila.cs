using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class SpGetFila
    {
        public long? IdFila { get; set; }
        public string Job { get; set; }
        public long? IdCliente { get; set; }
        public string Cliente { get; set; }
        public long? IdUsuario { get; set; }
        public string Usuario { get; set; }
        public DateTime? Inclusao { get; set; }
        public string DataEntrada { get; set; }
        public DateTime? Finalizacao { get; set; }
        public string DataSaida { get; set; }
        public long IdStatusJob { get; set; }
        public string StatusJob { get; set; }
        public int QuantidadeRegistrosEntrada { get; set; }
        public string QuantidadeRegistrosEntradaFormatado { get; set; }
        public int QuantidadeRegistrosSaida { get; set; }
        public string QuantidadeRegistrosSaidaFormatado { get; set; }
    }
}