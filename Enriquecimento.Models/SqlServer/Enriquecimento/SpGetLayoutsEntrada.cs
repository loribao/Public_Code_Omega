namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class SpGetLayoutsEntrada
    {
        public long Id { get; set; }
        public long IdProcedimento { get; set; }
        public long IdLayoutEntrada { get; set; }
        public string NomeLayoutEntrada { get; set; }
    }
}