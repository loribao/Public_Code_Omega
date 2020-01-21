using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class SessionLayoutsSaida
    {
        ////Nome da Session = LayoutsSaida
        public List<LayoutSaida> LayoutsSaida { get; set; }
        public class LayoutSaida
        {
            public long Id { get; set; }
            public long IdProcedimento { get; set; }
            public long IdLayoutSaida { get; set; }
            public string NomeLayoutSaida { get; set; }
        }
    }
}