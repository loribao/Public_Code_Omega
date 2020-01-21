using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class SessionProcedimentos
    {
        ////Nome da Session = Procedimentos
        public List<Procedimento> Procedimentos { get; set; }
        public class Procedimento
        {
            public long Id { get; set; }
            public long IdProcedimento { get; set; }
            public string NomeProcedimento { get; set; }
        }
    }
}