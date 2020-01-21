using System.Collections.Generic;

namespace Enriquecimento.WebSite.Models
{
    public class ViewResumoLayoutSaida
    {
        public long IdLayoutSaida { get; set; }
        public string NomeLayoutSaida { get; set; }
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