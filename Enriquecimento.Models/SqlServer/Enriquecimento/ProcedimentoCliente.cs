namespace Enriquecimento.Models.SqlServer.Enriquecimento
{
    public class ProcedimentoCliente
    {
        public long IdCliente { get; set; }
        public long IdLayoutEntrada { get; set; }
        public long IdLayoutSaida { get; set; }
        public long IdProcedimento { get; set; }
        public long IdProcedimentoCliente { get; set; }
    }
}