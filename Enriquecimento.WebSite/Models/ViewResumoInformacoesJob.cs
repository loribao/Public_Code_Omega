using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class ViewResumoInformacoesJob
    {
        public long IdFila { get; set; }
        public string NomeJob { get; set; }
        public string DataHoraEntrada { get; set; }
		public string ArquivoEntrada { get; set; }
		public string CaminhoEntradaAplicacao { get; set; }
		public long IdLayoutEntrada { get; set; }
        public string NomeLayoutEntrada { get; set; }
		public string DataHoraSaida { get; set; }
		public string ArquivoSaida { get; set; }
		public string CaminhoSaidaAplicacao { get; set; }
		public long IdLayoutSaida { get; set; }
        public string NomeLayoutSaida { get; set; }
		public long IdProcedimento { get; set; }
        public string NomeProcedimento { get; set; }
		public string DownloadsRealizados { get; set; }
        public long IdStatusJob { get; set; }
        public string NomeStatusJob { get; set; }
        public long IdLogErro { get; set; }
        public string InstrucaoErro { get; set; }
        public string Erro { get; set; }
        public List<CampoLayoutEntrada> CamposLayoutEntrada { get; set; }
        public class CampoLayoutEntrada
        {
            public int Id { get; set; }
            public string NomeCampo { get; set; }
            public int Tamanho { get; set; }
        }
        public List<CampoLayoutSaida> CamposLayoutSaida { get; set; }
        public class CampoLayoutSaida
        {
            public int Id { get; set; }
            public string NomeCampo { get; set; }
            public int Tamanho { get; set; }
        }
    }
}