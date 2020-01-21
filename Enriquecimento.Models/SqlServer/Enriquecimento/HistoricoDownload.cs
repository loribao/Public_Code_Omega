using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class HistoricoDownload
    {
        public bool ArquivoEntrada { get; set; }
        public bool ArquivoSaida { get; set; }
        public DateTime Inclusao { get; set; }
        public long IdAcesso { get; set; }
        public long IdCliente { get; set; }
        public long IdFila { get; set; }
        public long IdHistoricoDownload { get; set; }
        public long IdUsuario { get; set; }
    }
}