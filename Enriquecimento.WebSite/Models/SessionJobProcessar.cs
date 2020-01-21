namespace Enriquecimento.WebSite.Models
{
    public class SessionJobProcessar
    {
        ////Nome da Session = JobProcessar
        public long IdCliente { get; set; }
        public long IdProcedimento { get; set; }
        public long IdLayoutEntrada { get; set; }
        public long IdLayoutSaida { get; set; }
    }
}