using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class SessionLayoutsEntrada
    {
        ////Nome da Session = LayoutsEntrada
        public List<LayoutEntrada> LayoutsEntrada { get; set; }
        public class LayoutEntrada
        {
            public long Id { get; set; }
            public long IdProcedimento { get; set; }
            public long IdLayoutEntrada { get; set; }
            public string NomeLayoutEntrada { get; set; }
        }
    }
}