using Microsoft.AspNetCore.Http;

namespace Enriquecimento.WebSite.Models.Class
{
    public class ArquivoTipo
    {
        public IFormFile Arquivo { get; set; }
        public string ExtensaoArquivo { get; set; }
    }
}