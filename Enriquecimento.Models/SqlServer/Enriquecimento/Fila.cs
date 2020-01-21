using System;

namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class Fila
    {
        public DateTime Inclusao { get; set; }
        public DateTime? Finalizacao { get; set; }
        public int QuantidadeRegistrosEntrada { get; set; }
        public int QuantidadeRegistrosSaida { get; set; }
        public long IdAcesso { get; set; }
        public long IdCliente { get; set; }
        public long IdFila { get; set; }
        public long IdLayoutEntrada { get; set; }
        public long IdLayoutSaida { get; set; }
        public long IdProcedimento { get; set; }
        public long IdStatusJob { get; set; }
        public long IdUsuario { get; set; }
        public string ArquivoEntrada { get; set; }
        public string ArquivoEntradaOriginal { get; set; }
        public string ArquivoSaida { get; set; }
        public string CaminhoEntradaAplicacao { get; set; }
        public string CaminhoEntradaBanco { get; set; }
        public string CaminhoSaidaAplicacao { get; set; }
        public string CaminhoSaidaBanco { get; set; }
        public string LoginCliente { get; set; }
        public string LoginUsuario { get; set; }
        public string NomeArquivo { get; set; }
        public string NomeJob { get; set; }
        public string NomeTabela { get; set; }
    }
}