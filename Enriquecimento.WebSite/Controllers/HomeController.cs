using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Enriquecimento.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            long idProcedimento = 0;
            Models.ViewHome viewHome = new Models.ViewHome();
            Models.SessionClienteSelecionado sessionClienteSelecionado = new Models.SessionClienteSelecionado();
            List<Models.SessionProcedimentos.Procedimento> listProcedimentos = new List<Models.SessionProcedimentos.Procedimento>();
            //UsuarioLogado
            var sessionUsuarioLogado = HttpContext.Session.Get<Models.SessionUsuarioLogado>("UsuarioLogado");
            ViewData["UsuarioLogado"] = sessionUsuarioLogado;
            //IP
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            //Recuperar os clientes
            viewHome.IdCliente = sessionUsuarioLogado.IdCliente;
            RecuperarClientes();
            sessionClienteSelecionado = new Models.SessionClienteSelecionado();
            sessionClienteSelecionado.IdCliente = viewHome.IdCliente;
            HttpContext.Session.Set<Models.SessionClienteSelecionado>("ClienteSelecionado", sessionClienteSelecionado);
            //Recuperar os procedimentos
            RecuperarProcedimentos(sessionUsuarioLogado.IdCliente);
            listProcedimentos = HttpContext.Session.Get<List<Models.SessionProcedimentos.Procedimento>>("Procedimentos");
            if ((listProcedimentos != null) && (listProcedimentos.Count > 0))
            {
                idProcedimento = listProcedimentos.First().IdProcedimento;
            }
            //Recuperar os layouts de entrada
            RecuperarLayoutsEntrada(viewHome.IdCliente, idProcedimento);
            //Recuperar os layouts de saída
            RecuperarLayoutsSaida(viewHome.IdCliente, idProcedimento);
            ViewBag.MensagemProcessar = "";
            return View(viewHome);
        }

        private async void RecuperarClientes()
        {
            var sessionUsuarioLogado = HttpContext.Session.Get<Models.SessionUsuarioLogado>("UsuarioLogado");
            Models.SessionClientes.Cliente sessionClientes = new Models.SessionClientes.Cliente();
            List<Models.SessionClientes.Cliente> listSessionCliente = new List<Models.SessionClientes.Cliente>();
            //Recuperar os clientes
            ViewData["Clientes"] = listSessionCliente;
            var resultClientes = await Service.Cliente.GetClientesAtivos((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                sessionUsuarioLogado.IdCliente, sessionUsuarioLogado.IdUsuario);
            if (resultClientes == null)
            {
                resultClientes = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetClientes>();
            }
            foreach (var item001 in resultClientes)
            {
                sessionClientes = new Models.SessionClientes.Cliente();
                sessionClientes.Id = item001.Id;
                sessionClientes.IdCliente = item001.IdCliente;
                sessionClientes.NomeCliente = item001.LoginCliente;
                listSessionCliente.Add(sessionClientes);
            }
            HttpContext.Session.Set<List<Models.SessionClientes.Cliente>>("Clientes", listSessionCliente);
            ViewData["Clientes"] = listSessionCliente;
        }

        private void RecuperarProcedimentos(long idCliente)
        {
            Models.SessionProcedimentos.Procedimento sessionProcedimento = new Models.SessionProcedimentos.Procedimento();
            List<Models.SessionProcedimentos.Procedimento> listSessionProcedimentos = new List<Models.SessionProcedimentos.Procedimento>();
            //Recuperar os procedimentos
            ViewData["Procedimentos"] = listSessionProcedimentos;
            var resultProcedimentos = Service.Layout.GetProcedimentosAtivos((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, idCliente);
            if (resultProcedimentos == null)
            {
                resultProcedimentos = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetProcedimentos>();
            }
            foreach (var item001 in resultProcedimentos)
            {
                sessionProcedimento = new Models.SessionProcedimentos.Procedimento();
                sessionProcedimento.Id = item001.Id;
                sessionProcedimento.IdProcedimento = item001.IdProcedimento;
                sessionProcedimento.NomeProcedimento = item001.NomeProcedimento;
                listSessionProcedimentos.Add(sessionProcedimento);
            }
            HttpContext.Session.Set<List<Models.SessionProcedimentos.Procedimento>>("Procedimentos", listSessionProcedimentos);
            ViewData["Procedimentos"] = listSessionProcedimentos;
        }

        private void RecuperarLayoutsEntrada(long idCliente, long idProcedimento)
        {
            Models.SessionLayoutsEntrada.LayoutEntrada sessionLayoutEntrada = new Models.SessionLayoutsEntrada.LayoutEntrada();
            List<Models.SessionLayoutsEntrada.LayoutEntrada> listSessionLayoutEntrada = new List<Models.SessionLayoutsEntrada.LayoutEntrada>();
            //Recuperar os layouts de entrada
            ViewData["LayoutsEntrada"] = listSessionLayoutEntrada;
            var resultLayoutsEntrada = Service.Layout.GetLayoutsEntradaAtivos((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, idCliente,
                idProcedimento);
            if (resultLayoutsEntrada == null)
            {
                resultLayoutsEntrada = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetLayoutsEntrada>();
            }
            foreach (var item001 in resultLayoutsEntrada)
            {
                sessionLayoutEntrada = new Models.SessionLayoutsEntrada.LayoutEntrada();
                sessionLayoutEntrada.Id = item001.Id;
                sessionLayoutEntrada.IdProcedimento = item001.IdProcedimento;
                sessionLayoutEntrada.IdLayoutEntrada = item001.IdLayoutEntrada;
                sessionLayoutEntrada.NomeLayoutEntrada = item001.NomeLayoutEntrada;
                listSessionLayoutEntrada.Add(sessionLayoutEntrada);
            }
            HttpContext.Session.Set<List<Models.SessionLayoutsEntrada.LayoutEntrada>>("LayoutsEntrada", listSessionLayoutEntrada);
            ViewData["LayoutsEntrada"] = listSessionLayoutEntrada;
        }

        private void RecuperarLayoutsSaida(long idCliente, long idProcedimento)
        {
            Models.SessionLayoutsSaida.LayoutSaida sessionLayoutSaida = new Models.SessionLayoutsSaida.LayoutSaida();
            List<Models.SessionLayoutsSaida.LayoutSaida> listSessionLayoutSaida = new List<Models.SessionLayoutsSaida.LayoutSaida>();
            //Recuperar os layouts de entrada
            ViewData["LayoutsSaida"] = listSessionLayoutSaida;
            var resultLayoutsSaida = Service.Layout.GetLayoutsSaidaAtivos((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, idCliente,
                idProcedimento);
            if (resultLayoutsSaida == null)
            {
                resultLayoutsSaida = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetLayoutsSaida>();
            }
            foreach (var item001 in resultLayoutsSaida)
            {
                sessionLayoutSaida = new Models.SessionLayoutsSaida.LayoutSaida();
                sessionLayoutSaida.Id = item001.Id;
                sessionLayoutSaida.IdProcedimento = item001.IdProcedimento;
                sessionLayoutSaida.IdLayoutSaida = item001.IdLayoutSaida;
                sessionLayoutSaida.NomeLayoutSaida = item001.NomeLayoutSaida;
                listSessionLayoutSaida.Add(sessionLayoutSaida);
            }
            HttpContext.Session.Set<List<Models.SessionLayoutsSaida.LayoutSaida>>("LayoutsSaida", listSessionLayoutSaida);
            ViewData["LayoutsSaida"] = listSessionLayoutSaida;
        }

        private List<Models.Json.JsonTableJob> GetFilaJobsProcessarDadosForm(List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetFila> listSpGetFila,
            IFormCollection requestFormData)
        {
            int contador = 1;
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };
            Models.Json.JsonTableJob jsonTableJob = new Models.Json.JsonTableJob();
            List<Models.Json.JsonTableJob> listJsonTableJobs = new List<Models.Json.JsonTableJob>();
            if (listSpGetFila == null)
            {
                listSpGetFila = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetFila>();
            }
            foreach (var item001 in listSpGetFila)
            {
                jsonTableJob = new Models.Json.JsonTableJob();
                jsonTableJob.idordenacao = contador;
                jsonTableJob.idfila = (int)item001.IdFila;
                jsonTableJob.job = item001.Job;
                jsonTableJob.idcliente = (int)item001.IdCliente;
                jsonTableJob.cliente = item001.Cliente;
                jsonTableJob.idusuario = (int)item001.IdUsuario;
                jsonTableJob.usuario = item001.Usuario;
                jsonTableJob.dataentrada = item001.DataEntrada;
                jsonTableJob.datasaida = item001.DataSaida;
                jsonTableJob.idstatusjob = (int)item001.IdStatusJob;
                jsonTableJob.statusjob = item001.StatusJob;
                jsonTableJob.quantidadeentrada = item001.QuantidadeRegistrosEntradaFormatado;
                jsonTableJob.quantidadesaida = item001.QuantidadeRegistrosSaidaFormatado;
                listJsonTableJobs.Add(jsonTableJob);
                contador++;
            }
            if (listJsonTableJobs == null)
            {
                listJsonTableJobs = new List<Models.Json.JsonTableJob>();
            }
            var searchValue = requestFormData["search[value]"].FirstOrDefault();
            if (string.IsNullOrEmpty(searchValue) == false)
            {
                searchValue = Utils.Funcoes.RemoverEspacoDuplos(searchValue);
                searchValue = searchValue.Trim();
                searchValue = Utils.Funcoes.RemoverAcentos(searchValue);
                searchValue = Utils.Funcoes.RemoverCaractersInvalidos(searchValue);
                searchValue = Utils.Funcoes.RemoverEspacoDuplos(searchValue);
                searchValue = searchValue.ToUpper();
                searchValue = searchValue.Trim();
            }
            if (string.IsNullOrEmpty(searchValue) == false)
            {
                var listSearch = listJsonTableJobs.Where(m => m.job.ToUpper().Contains(searchValue) == true ||
                                                              m.cliente.ToUpper().Contains(searchValue) == true ||
                                                              m.usuario.ToUpper().Contains(searchValue) == true).ToList();
                if (listSearch == null)
                {
                    listSearch = new List<Models.Json.JsonTableJob>();
                }
                listJsonTableJobs = new List<Models.Json.JsonTableJob>();
                listJsonTableJobs = listSearch;
            }
            if (pageSize > 0)
            {
                var prop = JsonTableJobGetProperty("idordenacao");
                return listJsonTableJobs.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                return (listJsonTableJobs);
            }
        }

        private PropertyInfo JsonTableJobGetProperty(string name)
        {
            var properties = typeof(Models.Json.JsonTableJob).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        #region Solicitação HTTP
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarClienteSelecionado([FromBody] Models.Json.JsonAtualizarClienteSelecionado jsonAtualizarClienteSelecionado)
        {
            Models.SessionClienteSelecionado sessionClienteSelecionado = new Models.SessionClienteSelecionado();
            sessionClienteSelecionado.IdCliente = jsonAtualizarClienteSelecionado.idCliente;
            HttpContext.Session.Set<Models.SessionClienteSelecionado>("ClienteSelecionado", sessionClienteSelecionado);
            return (this.Ok());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarDdlProcedimento([FromBody] Models.Json.JsonAtualizarDdlProcedimento jsonAtualizarDdlProcedimento)
        {
            List<Models.SessionProcedimentos.Procedimento> listProcedimentos = new List<Models.SessionProcedimentos.Procedimento>();
            RecuperarProcedimentos(jsonAtualizarDdlProcedimento.idCliente);
            return PartialView("_Procedimento");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarDdlLayoutEntrada([FromBody] Models.Json.JsonAtualizarDdlLayoutEntrada jsonAtualizarDdlLayoutEntrada)
        {
            List<Models.SessionLayoutsEntrada.LayoutEntrada> listLayoutsEntrada = new List<Models.SessionLayoutsEntrada.LayoutEntrada>();
            RecuperarLayoutsEntrada(jsonAtualizarDdlLayoutEntrada.idCliente, jsonAtualizarDdlLayoutEntrada.idProcedimento);
            return PartialView("_LayoutEntrada");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarDdlLayoutSaida([FromBody] Models.Json.JsonAtualizarDdlLayoutSaida jsonAtualizarDdlLayoutSaida)
        {
            List<Models.SessionLayoutsSaida.LayoutSaida> listLayoutsSaida = new List<Models.SessionLayoutsSaida.LayoutSaida>();
            RecuperarLayoutsSaida(jsonAtualizarDdlLayoutSaida.idCliente, jsonAtualizarDdlLayoutSaida.idProcedimento);
            return PartialView("_LayoutSaida");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExibirResumoLayoutEntrada([FromBody] Models.Json.JsonResumoLayoutEntrada jsonResumoLayoutEntrada)
        {
            Models.ViewResumoLayoutEntrada viewResumoLayoutEntrada = new Models.ViewResumoLayoutEntrada();
            Models.ViewResumoLayoutEntrada.Campo campo = new Models.ViewResumoLayoutEntrada.Campo();
            Enriquecimento.Models.SqlServer.Enriquecimento.LayoutEntrada layoutEntrada = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutEntrada();
            Enriquecimento.Models.SqlServer.Enriquecimento.LayoutDelimitador layoutDelimitador = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutDelimitador();
            //Recuperar o Layout de Entrada
            layoutEntrada = await Service.Layout.GetLayoutEntrada((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                jsonResumoLayoutEntrada.idLayoutEntrada);
            if (layoutEntrada == null)
            {
                layoutEntrada = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutEntrada();
            }
            viewResumoLayoutEntrada.IdLayoutEntrada = layoutEntrada.IdLayoutEntrada;
            viewResumoLayoutEntrada.NomeLayoutEntrada = (string.IsNullOrEmpty(layoutEntrada.Nome) == false ? layoutEntrada.Nome : "");
            viewResumoLayoutEntrada.NomesColunasPrimeiraLinha = (layoutEntrada.NomesColunasPrimeiraLinha == true ? "Sim" : "Não");
            //Recuperar o Delimitador
            if ((layoutEntrada != null) && (layoutEntrada.IdLayoutDelimitador > 0))
            {
                layoutDelimitador = await Service.Layout.GetLayoutDelimitador((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                    layoutEntrada.IdLayoutDelimitador);
            }
            if (layoutDelimitador == null)
            {
                layoutDelimitador = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutDelimitador();
            }
            viewResumoLayoutEntrada.IdLayoutDelimitador = layoutDelimitador.IdLayoutDelimitador;
            viewResumoLayoutEntrada.CaracterDelimitador = (string.IsNullOrEmpty(layoutDelimitador.Caracter) == false ? layoutDelimitador.Caracter : "");
            //Campos
            var resultCampos = await Service.Layout.GetSchemaLayoutEntrada((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                layoutEntrada.IdLayoutEntrada);
            viewResumoLayoutEntrada.Campos = new List<Models.ViewResumoLayoutEntrada.Campo>();
            if (resultCampos != null)
            {
                foreach (var item001 in resultCampos)
                {
                    campo = new Models.ViewResumoLayoutEntrada.Campo();
                    campo.Id = item001.Id;
                    campo.NomeCampo = (string.IsNullOrEmpty(item001.Campo) == false ? item001.Campo : "");
                    campo.Tamanho = item001.Tamanho;
                    viewResumoLayoutEntrada.Campos.Add(campo);
                }
            }
            return PartialView("_ResumoLayoutEntrada", viewResumoLayoutEntrada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExibirResumoLayoutSaida([FromBody] Models.Json.JsonResumoLayoutSaida jsonResumoLayoutSaida)
        {
            Models.ViewResumoLayoutSaida viewResumoLayoutSaida = new Models.ViewResumoLayoutSaida();
            Models.ViewResumoLayoutSaida.Campo campo = new Models.ViewResumoLayoutSaida.Campo();
            Enriquecimento.Models.SqlServer.Enriquecimento.LayoutSaida layoutSaida = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutSaida();
            Enriquecimento.Models.SqlServer.Enriquecimento.LayoutDelimitador layoutDelimitador = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutDelimitador();
            //Recuperar o Layout de Saída
            layoutSaida = await Service.Layout.GetLayoutSaida((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                jsonResumoLayoutSaida.idLayoutSaida);
            if (layoutSaida == null)
            {
                layoutSaida = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutSaida();
            }
            viewResumoLayoutSaida.IdLayoutSaida = layoutSaida.IdLayoutSaida;
            viewResumoLayoutSaida.NomeLayoutSaida = (string.IsNullOrEmpty(layoutSaida.Nome) == false ? layoutSaida.Nome : "");
            viewResumoLayoutSaida.NomesColunasPrimeiraLinha = (layoutSaida.NomesColunasPrimeiraLinha == true ? "Sim" : "Não");
            //Recuperar o Delimitador
            if ((layoutSaida != null) && (layoutSaida.IdLayoutDelimitador > 0))
            {
                layoutDelimitador = await Service.Layout.GetLayoutDelimitador((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                    layoutSaida.IdLayoutDelimitador);
            }
            if (layoutDelimitador == null)
            {
                layoutDelimitador = new Enriquecimento.Models.SqlServer.Enriquecimento.LayoutDelimitador();
            }
            viewResumoLayoutSaida.IdLayoutDelimitador = layoutDelimitador.IdLayoutDelimitador;
            viewResumoLayoutSaida.CaracterDelimitador = (string.IsNullOrEmpty(layoutDelimitador.Caracter) == false ? layoutDelimitador.Caracter : "");
            //Campos
            var resultCampos = await Service.Layout.GetSchemaLayoutSaida((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                layoutSaida.IdLayoutSaida);
            viewResumoLayoutSaida.Campos = new List<Models.ViewResumoLayoutSaida.Campo>();
            if (resultCampos != null)
            {
                foreach (var item001 in resultCampos)
                {
                    campo = new Models.ViewResumoLayoutSaida.Campo();
                    campo.Id = item001.Id;
                    campo.NomeCampo = (string.IsNullOrEmpty(item001.Campo) == false ? item001.Campo : "");
                    campo.Tamanho = item001.Tamanho;
                    viewResumoLayoutSaida.Campos.Add(campo);
                }
            }
            return PartialView("_ResumoLayoutSaida", viewResumoLayoutSaida);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void InputarConfiguracoesJob([FromBody] Models.Json.JsonInputarConfiguracoesJob jsonInputarConfiguracoesJob)
        {
            ViewBag.MensagemProcessar = "";
            Models.SessionJobProcessar sessionJobProcessar = new Models.SessionJobProcessar();
            sessionJobProcessar.IdCliente = jsonInputarConfiguracoesJob.idCliente;
            sessionJobProcessar.IdProcedimento = jsonInputarConfiguracoesJob.idProcedimento;
            sessionJobProcessar.IdLayoutEntrada = jsonInputarConfiguracoesJob.idLayoutEntrada;
            sessionJobProcessar.IdLayoutSaida = jsonInputarConfiguracoesJob.idLayoutSaida;
            HttpContext.Session.Set<Models.SessionJobProcessar>("JobProcessar", sessionJobProcessar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            string extensaoArquivo = "";
            string loginCliente = "";
            string pathEntradaAplicacao = "";
            string pathEntradaBanco = "";
            string pathSaidaAplicacao = "";
            string pathSaidaBanco = "";
            Models.Class.ArquivoTipo arquivoTipo = new Models.Class.ArquivoTipo();
            Models.SessionJobProcessar sessionJobProcessar = null;
            Models.SessionUsuarioLogado sessionUsuarioLogado = null;
            Enriquecimento.Models.SqlServer.Enriquecimento.Fila fila = new Enriquecimento.Models.SqlServer.Enriquecimento.Fila();
            List<Models.Class.ArquivoTipo> listArquivoTipo = new List<Models.Class.ArquivoTipo>();
            List<Models.SessionClientes.Cliente> listSessionCliente = new List<Models.SessionClientes.Cliente>();
            try
            {
                ViewBag.MensagemProcessar = "";
                if ((files != null) && (files.Count > 0))
                {
                    foreach (var file in files)
                    {
                        arquivoTipo = new Models.Class.ArquivoTipo();
                        extensaoArquivo = "";
                        extensaoArquivo = file.FileName;
                        extensaoArquivo = (string.IsNullOrEmpty(extensaoArquivo) == false ? extensaoArquivo : "");
                        if (extensaoArquivo.Contains(".") == true)
                        {
                            extensaoArquivo = Utils.Funcoes.Reverse(extensaoArquivo);
                            extensaoArquivo = extensaoArquivo.Substring(0, extensaoArquivo.IndexOf('.'));
                            extensaoArquivo = Utils.Funcoes.Reverse(extensaoArquivo);
                        }
                        arquivoTipo.Arquivo = file;
                        arquivoTipo.ExtensaoArquivo = extensaoArquivo;
                        listArquivoTipo.Add(arquivoTipo);
                    }
                    sessionJobProcessar = HttpContext.Session.Get<Models.SessionJobProcessar>("JobProcessar");
                    sessionUsuarioLogado = HttpContext.Session.Get<Models.SessionUsuarioLogado>("UsuarioLogado");
                    listSessionCliente = HttpContext.Session.Get<List<Models.SessionClientes.Cliente>>("Clientes");
                    foreach (var item001 in listArquivoTipo)
                    {
                        pathEntradaAplicacao = $"{this._hostingEnvironment.WebRootPath}/";
                        pathEntradaAplicacao = Utils.AppConfiguration.GetAppConfiguration((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp).GetSection("AppConfiguration")["CaminhoEntradaAplicacao"];
                        pathEntradaBanco = Utils.AppConfiguration.GetAppConfiguration((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp).GetSection("AppConfiguration")["CaminhoEntradaBanco"];
                        pathSaidaAplicacao = $"{this._hostingEnvironment.WebRootPath}/";
                        pathSaidaAplicacao = Utils.AppConfiguration.GetAppConfiguration((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp).GetSection("AppConfiguration")["CaminhoSaidaAplicacao"];
                        pathSaidaBanco = Utils.AppConfiguration.GetAppConfiguration((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp).GetSection("AppConfiguration")["CaminhoSaidaBanco"];
                        if ((item001.ExtensaoArquivo.ToLower().Equals("txt")) || (item001.ExtensaoArquivo.ToUpper().Equals("csv")))
                        {
                            fila = new Enriquecimento.Models.SqlServer.Enriquecimento.Fila();
                            fila.Inclusao = DateTime.Now;
                            fila.IdCliente = sessionJobProcessar.IdCliente;
                            loginCliente = "";
                            var resultCliente = (from t1 in listSessionCliente
                                                 where t1.IdCliente == fila.IdCliente
                                                 select t1).ToList();
                            if ((resultCliente != null) && (resultCliente.Count > 0))
                            {
                                loginCliente = resultCliente.First().NomeCliente;
                            }
                            fila.LoginCliente = loginCliente;
                            fila.IdUsuario = sessionUsuarioLogado.IdUsuario;
                            fila.LoginUsuario = sessionUsuarioLogado.LoginUsuario;
                            fila.IdAcesso = sessionUsuarioLogado.IdAcesso;
                            fila.NomeJob = Enriquecimento.Service.Fila.GerarNomeJob(item001.Arquivo.FileName);
                            fila.NomeTabela = Enriquecimento.Service.Fila.GerarNomeTabela(item001.Arquivo.FileName, fila.Inclusao);
                            fila.NomeArquivo = fila.NomeTabela;
                            fila.CaminhoEntradaAplicacao = pathEntradaAplicacao;
                            fila.CaminhoEntradaBanco = pathEntradaBanco;
                            fila.ArquivoEntrada = fila.NomeTabela + "_ORIGINAL" + "." + item001.ExtensaoArquivo.ToLower();
                            fila.ArquivoEntradaOriginal = item001.Arquivo.FileName;
                            fila.CaminhoSaidaAplicacao = pathSaidaAplicacao;
                            fila.CaminhoSaidaBanco = pathSaidaBanco;
                            fila.ArquivoSaida = fila.NomeTabela + "_PROCESSADO" + "." + "zip";
                            //Fazer o upload do arquivo
                            using (var stream = new FileStream(fila.CaminhoEntradaAplicacao + fila.ArquivoEntrada, FileMode.Create))
                            {
                                await item001.Arquivo.CopyToAsync(stream);
                            }
                            fila.IdStatusJob = (long)Enriquecimento.Models.Enumeradores.StatusJob.EmFila;
                            fila.IdProcedimento = sessionJobProcessar.IdProcedimento;
                            fila.IdLayoutEntrada = sessionJobProcessar.IdLayoutEntrada;
                            fila.IdLayoutSaida = sessionJobProcessar.IdLayoutSaida;
                            fila.QuantidadeRegistrosEntrada = 0;
                            fila.QuantidadeRegistrosSaida = 0;
                            fila.Finalizacao = null;
                            //Inserir o Job na Fila
                            fila = await Enriquecimento.Service.Fila.InserirJob((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, fila);
                        }
                        else
                        {
                            ViewBag.MensagemProcessar = "Só é aceito arquivo com extesão txt ou csv.";
                        }
                    }
                }
                else
                {
                    ViewBag.MensagemProcessar = "Selecione um arquivo para ser processado.";
                }
            }
            catch (System.Exception ex)
            {
                ViewBag.MensagemProcessar = ex.Message.ToString();
            }
            finally
            { }
            return this.Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetFilaJobs()
        {
            var requestFormData = Request.Form;
            Models.SessionClienteSelecionado sessionClienteSelecionado = new Models.SessionClienteSelecionado();
            List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetFila> listSpGetFila = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetFila>();
            List<Models.Json.JsonTableJob> listJsonTableJob = new List<Models.Json.JsonTableJob>();
            sessionClienteSelecionado = HttpContext.Session.Get<Models.SessionClienteSelecionado>("ClienteSelecionado");
            listSpGetFila = await Enriquecimento.Service.Fila.RetornarFilaDeJobs((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                sessionClienteSelecionado.IdCliente);
            if (listSpGetFila == null)
            {
                listSpGetFila = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetFila>();
            }
            listJsonTableJob = GetFilaJobsProcessarDadosForm(listSpGetFila, requestFormData);
            if (listJsonTableJob == null)
            {
                listJsonTableJob = new List<Models.Json.JsonTableJob>();
            }
            dynamic response = new
            {
                Data = listJsonTableJob,
                Draw = requestFormData["draw"],
                RecordsFiltered = listSpGetFila.Count,
                RecordsTotal = listSpGetFila.Count
            };
            return Ok(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VisualizarInformacoesJob([FromBody] Models.Json.JsonVisualizarInformacoesJob jsonVisualizarInformacoesJob)
        {
            Models.ViewResumoInformacoesJob viewResumoInformacoesJob = new Models.ViewResumoInformacoesJob();
            Models.ViewResumoInformacoesJob.CampoLayoutEntrada viewCampoLayoutEntrada = new Models.ViewResumoInformacoesJob.CampoLayoutEntrada();
            Models.ViewResumoInformacoesJob.CampoLayoutSaida viewCampoLayoutSaida = new Models.ViewResumoInformacoesJob.CampoLayoutSaida();
            viewResumoInformacoesJob.CamposLayoutEntrada = new List<Models.ViewResumoInformacoesJob.CampoLayoutEntrada>();
            viewResumoInformacoesJob.CamposLayoutSaida = new List<Models.ViewResumoInformacoesJob.CampoLayoutSaida>();
            var resultJob = await Enriquecimento.Service.Fila.RetornarInformacoesJobAsync((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                jsonVisualizarInformacoesJob.idFila);
            if ((resultJob != null) && (resultJob.IdFila > 0))
            {
                viewResumoInformacoesJob.IdFila = resultJob.IdFila;
                viewResumoInformacoesJob.NomeJob = (string.IsNullOrEmpty(resultJob.NomeJob) == false ? resultJob.NomeJob : "");
                viewResumoInformacoesJob.DataHoraEntrada = (string.IsNullOrEmpty(resultJob.DataHoraEntrada) == false ? resultJob.DataHoraEntrada : "");
                viewResumoInformacoesJob.ArquivoEntrada = (string.IsNullOrEmpty(resultJob.ArquivoEntrada) == false ? resultJob.ArquivoEntrada : "");
                viewResumoInformacoesJob.CaminhoEntradaAplicacao = (string.IsNullOrEmpty(resultJob.CaminhoEntradaAplicacao) == false ? resultJob.CaminhoEntradaAplicacao : "");
                viewResumoInformacoesJob.IdLayoutEntrada = (resultJob.IdLayoutEntrada.HasValue == true ? resultJob.IdLayoutEntrada.Value : 0);
                viewResumoInformacoesJob.NomeLayoutEntrada = (string.IsNullOrEmpty(resultJob.NomeLayoutEntrada) == false ? resultJob.NomeLayoutEntrada : "");
                viewResumoInformacoesJob.DataHoraSaida = (string.IsNullOrEmpty(resultJob.DataHoraSaida) == false ? resultJob.DataHoraSaida : "");
                viewResumoInformacoesJob.ArquivoSaida = (string.IsNullOrEmpty(resultJob.ArquivoSaida) == false ? resultJob.ArquivoSaida : "");
                viewResumoInformacoesJob.CaminhoSaidaAplicacao = (string.IsNullOrEmpty(resultJob.CaminhoSaidaAplicacao) == false ? resultJob.CaminhoSaidaAplicacao : "");
                viewResumoInformacoesJob.IdLayoutSaida = (resultJob.IdLayoutSaida.HasValue == true ? resultJob.IdLayoutSaida.Value : 0);
                viewResumoInformacoesJob.NomeLayoutSaida = (string.IsNullOrEmpty(resultJob.NomeLayoutSaida) == false ? resultJob.NomeLayoutSaida : "");
                viewResumoInformacoesJob.IdProcedimento = (resultJob.IdProcedimento.HasValue == true ? resultJob.IdProcedimento.Value : 0);
                viewResumoInformacoesJob.NomeProcedimento = (string.IsNullOrEmpty(resultJob.NomeProcedimento) == false ? resultJob.NomeProcedimento : "");
                viewResumoInformacoesJob.DownloadsRealizados = (string.IsNullOrEmpty(resultJob.DownloadsRealizados) == false ? resultJob.DownloadsRealizados : "");
                viewResumoInformacoesJob.IdStatusJob = (resultJob.IdStatusJob.HasValue == true ? resultJob.IdStatusJob.Value : 0);
                viewResumoInformacoesJob.NomeStatusJob = (string.IsNullOrEmpty(resultJob.NomeStatusJob) == false ? resultJob.NomeStatusJob : "");
                viewResumoInformacoesJob.IdLogErro = (resultJob.IdLogErro.HasValue == true ? resultJob.IdLogErro.Value : 0);
                viewResumoInformacoesJob.InstrucaoErro = (string.IsNullOrEmpty(resultJob.InstrucaoErro) == false ? resultJob.InstrucaoErro : "");
                viewResumoInformacoesJob.Erro = (string.IsNullOrEmpty(resultJob.Erro) == false ? resultJob.Erro : "");
                //Campos do Layout de Entrada
                var resultCamposLayoutEntrada = await Enriquecimento.Service.Layout.GetSchemaLayoutEntrada((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                    viewResumoInformacoesJob.IdLayoutEntrada);
                if (resultCamposLayoutEntrada == null)
                {
                    resultCamposLayoutEntrada = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetResumoLayoutEntrada>();
                }
                foreach (var item001 in resultCamposLayoutEntrada)
                {
                    viewCampoLayoutEntrada = new Models.ViewResumoInformacoesJob.CampoLayoutEntrada();
                    viewCampoLayoutEntrada.Id = item001.Id;
                    viewCampoLayoutEntrada.NomeCampo = item001.Campo;
                    viewCampoLayoutEntrada.Tamanho = item001.Tamanho;
                    viewResumoInformacoesJob.CamposLayoutEntrada.Add(viewCampoLayoutEntrada);
                }
                //Campos do Layout de Saída
                var resultCamposLayoutSaida = await Enriquecimento.Service.Layout.GetSchemaLayoutSaida((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                    viewResumoInformacoesJob.IdLayoutSaida);
                if (resultCamposLayoutSaida == null)
                {
                    resultCamposLayoutSaida = new List<Enriquecimento.Models.SqlServer.Enriquecimento.SpGetResumoLayoutSaida>();
                }
                foreach (var item002 in resultCamposLayoutSaida)
                {
                    viewCampoLayoutSaida = new Models.ViewResumoInformacoesJob.CampoLayoutSaida();
                    viewCampoLayoutSaida.Id = item002.Id;
                    viewCampoLayoutSaida.NomeCampo = item002.Campo;
                    viewCampoLayoutSaida.Tamanho = item002.Tamanho;
                    viewResumoInformacoesJob.CamposLayoutSaida.Add(viewCampoLayoutSaida);
                }
            }
            else
            { }
            return PartialView("_ResumoInformacoesJob", viewResumoInformacoesJob);
        }

        [HttpGet]
        public IActionResult DownloadArquivoEntrada(int idFila)
        {
            string pathEntradaAplicacao = string.Empty;
            string arquivoEntrada = string.Empty;
            Models.SessionUsuarioLogado sessionUsuarioLogado = new Models.SessionUsuarioLogado();
            Enriquecimento.Models.SqlServer.Enriquecimento.HistoricoDownload historicoDownload = new Enriquecimento.Models.SqlServer.Enriquecimento.HistoricoDownload();

            Enriquecimento.Models.SqlServer.Enriquecimento.Fila fila = new Enriquecimento.Models.SqlServer.Enriquecimento.Fila();
            fila = Enriquecimento.Service.Fila.RetornarJob((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, idFila);
            //pathEntradaAplicacao = $"{this._hostingEnvironment.WebRootPath}/";
            pathEntradaAplicacao = fila.CaminhoEntradaAplicacao;
            arquivoEntrada = fila.ArquivoEntrada;

            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(pathEntradaAplicacao + arquivoEntrada, out contentType))
            {
                contentType = "application/octet-stream";
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathEntradaAplicacao + arquivoEntrada);

            //Inserir na tabela HistoricoDownload
            sessionUsuarioLogado = HttpContext.Session.Get<Models.SessionUsuarioLogado>("UsuarioLogado");
            historicoDownload = new Enriquecimento.Models.SqlServer.Enriquecimento.HistoricoDownload();
            historicoDownload.ArquivoEntrada = true;
            historicoDownload.ArquivoSaida = false;
            historicoDownload.Inclusao = DateTime.Now;
            historicoDownload.IdAcesso = sessionUsuarioLogado.IdAcesso;
            historicoDownload.IdCliente = sessionUsuarioLogado.IdCliente;
            historicoDownload.IdFila = idFila;
            historicoDownload.IdUsuario = sessionUsuarioLogado.IdUsuario;
            historicoDownload = Enriquecimento.Service.Fila.InserirDownloadArquivoEntrada((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                historicoDownload);

            return (File(fileBytes, contentType, arquivoEntrada));
        }

        [HttpGet]
        public IActionResult DownloadArquivoSaida(int idFila)
        {
            string pathSaidaAplicacao = string.Empty;
            string arquivoSaida = string.Empty;
            Models.SessionUsuarioLogado sessionUsuarioLogado = new Models.SessionUsuarioLogado();
            Enriquecimento.Models.SqlServer.Enriquecimento.HistoricoDownload historicoDownload = new Enriquecimento.Models.SqlServer.Enriquecimento.HistoricoDownload();

            Enriquecimento.Models.SqlServer.Enriquecimento.Fila fila = new Enriquecimento.Models.SqlServer.Enriquecimento.Fila();
            fila = Enriquecimento.Service.Fila.RetornarJob((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, idFila);
            //pathSaidaAplicacao = $"{this._hostingEnvironment.WebRootPath}/";
            pathSaidaAplicacao = fila.CaminhoSaidaAplicacao;
            arquivoSaida = fila.ArquivoSaida;

            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(pathSaidaAplicacao + arquivoSaida, out contentType))
            {
                contentType = "application/octet-stream";
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathSaidaAplicacao + arquivoSaida);

            //Inserir na tabela HistoricoDownload
            sessionUsuarioLogado = HttpContext.Session.Get<Models.SessionUsuarioLogado>("UsuarioLogado");
            historicoDownload = new Enriquecimento.Models.SqlServer.Enriquecimento.HistoricoDownload();
            historicoDownload.ArquivoEntrada = false;
            historicoDownload.ArquivoSaida = true;
            historicoDownload.Inclusao = DateTime.Now;
            historicoDownload.IdAcesso = sessionUsuarioLogado.IdAcesso;
            historicoDownload.IdCliente = sessionUsuarioLogado.IdCliente;
            historicoDownload.IdFila = idFila;
            historicoDownload.IdUsuario = sessionUsuarioLogado.IdUsuario;
            historicoDownload = Enriquecimento.Service.Fila.InserirDownloadArquivoEntrada((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                historicoDownload);

            return (File(fileBytes, contentType, arquivoSaida));
        }
        #endregion
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}