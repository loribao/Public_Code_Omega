namespace Enriquecimento.WebSite.Models.Json
{
    public class JsonTableJob
    {
        public int idordenacao { get; set; }
        public int idfila { get; set; }
        public string job { get; set; }
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public string dataentrada { get; set; }
        public string datasaida { get; set; }
        public int idstatusjob { get; set; }
        public string statusjob { get; set; }
        public string quantidadeentrada { get; set; }
        public string quantidadesaida { get; set; }
    }
}