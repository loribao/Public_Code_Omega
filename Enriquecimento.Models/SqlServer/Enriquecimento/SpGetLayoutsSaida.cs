namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class SpGetLayoutsSaida
    {
        public long Id { get; set; }
        public long IdProcedimento { get; set; }
        public long IdLayoutSaida { get; set; }
        public string NomeLayoutSaida { get; set; }
    }
}