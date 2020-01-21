using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class ViewResumoLayoutEntrada
    {
        public long IdLayoutEntrada { get; set; }
        public string NomeLayoutEntrada { get; set; }
        public string NomesColunasPrimeiraLinha { get; set; }
        public long IdLayoutDelimitador { get; set; }
        public string CaracterDelimitador { get; set; }
        public List<Campo> Campos { get; set; }
        public class Campo
        {
            public int Id { get; set; }
            public string NomeCampo { get; set; }
            public int Tamanho { get; set; }
        }
    }
}