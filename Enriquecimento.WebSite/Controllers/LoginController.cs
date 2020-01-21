using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Enriquecimento.WebSite.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            foreach (var cookieKey in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookieKey);
            }
            HttpContext.Session.Clear();
            //Session.Abandon()
            //Session.RemoveAll()
            ViewBag.Message = string.Empty;
            ViewBag.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return View();
        }

        public IActionResult Sair()
        {
            foreach (var cookieKey in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookieKey);
            }
            HttpContext.Session.Clear();
            //Session.Abandon()
            //Session.RemoveAll()
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logar(Enriquecimento.WebSite.Models.ViewLogin viewLogin)
        {
            string ip = string.Empty;
            Enriquecimento.Models.SqlServer.ControleGerencial.SpValidarClienteUsuarioProduto spValidarClienteUsuarioProduto = null;
            Enriquecimento.Models.SqlServer.ControleGerencial.SpGetInformacoesLogin spGetInformacoesLogin = null;
            Enriquecimento.Models.SqlServer.ControleGerencial.Acesso acesso = null;
            Models.SessionUsuarioLogado sessionUsuarioLogado = new Models.SessionUsuarioLogado();
            try
            {
                ViewBag.Message = string.Empty;
                //Autenticar o usuário
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                spValidarClienteUsuarioProduto = Enriquecimento.Service.Usuario.AutenticarUsuario((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                    viewLogin.Usuario, viewLogin.Senha, viewLogin.Cliente, ip, (long)Enriquecimento.Models.Enumeradores.Produto.Enriquecimento);
                if (spValidarClienteUsuarioProduto != null)
                {
                    if (spValidarClienteUsuarioProduto.IdUsuario.HasValue == true)
                    {
                        //Inserir no Acesso
                        acesso = new Enriquecimento.Models.SqlServer.ControleGerencial.Acesso();
                        acesso.Inclusao = DateTime.Now;
                        acesso.IdProduto = (long)Enriquecimento.Models.Enumeradores.Produto.Enriquecimento;
                        acesso.IdUsuario = spValidarClienteUsuarioProduto.IdUsuario.Value;
                        acesso.IP = ip;
                        acesso = Service.Usuario.InserirNoHistoricoDeAcesso((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp, acesso);
                        if ((acesso != null) && (acesso.IdAcesso > 0))
                        {
                            //Recuperar as informações da sessão
                            spGetInformacoesLogin = Service.Usuario.GetInformacoesLogin((int)Enriquecimento.Models.Enumeradores.OrigemAppsettingsJson.WebApp,
                                acesso.IdAcesso);
                            if ((spGetInformacoesLogin != null) && (spGetInformacoesLogin.IdProduto > 0))
                            {
                                sessionUsuarioLogado = new Models.SessionUsuarioLogado();
                                sessionUsuarioLogado.IdAcesso = acesso.IdAcesso;
                                sessionUsuarioLogado.IP = acesso.IP;
                                sessionUsuarioLogado.IdCliente = spGetInformacoesLogin.IdCliente;
                                sessionUsuarioLogado.LoginCliente = spGetInformacoesLogin.LoginCliente;
                                sessionUsuarioLogado.RazaoSocialCliente = spGetInformacoesLogin.RazaoSocialCliente;
                                sessionUsuarioLogado.InclusaoCliente = spGetInformacoesLogin.InclusaoCliente;
                                sessionUsuarioLogado.IdUsuario = spGetInformacoesLogin.IdUsuario;
                                sessionUsuarioLogado.LoginUsuario = spGetInformacoesLogin.LoginUsuario;
                                sessionUsuarioLogado.SenhaUsuario = spGetInformacoesLogin.SenhaUsuario;
                                sessionUsuarioLogado.NomeUsuario = spGetInformacoesLogin.NomeUsuario;
                                sessionUsuarioLogado.EmailUsuario = spGetInformacoesLogin.EmailUsuario;
                                sessionUsuarioLogado.InclusaoUsuario = spGetInformacoesLogin.InclusaoUsuario;
                                sessionUsuarioLogado.IdPerfil = 1;
                                sessionUsuarioLogado.Perfil = "Master";
                                sessionUsuarioLogado.IdProduto = spGetInformacoesLogin.IdProduto;
                                sessionUsuarioLogado.Produto = spGetInformacoesLogin.Produto;
                                HttpContext.Session.Set<Models.SessionUsuarioLogado>("UsuarioLogado", sessionUsuarioLogado);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Message = "Erro ao logar. Por favor, tente novamente.";
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Erro ao logar. Por favor, tente novamente.";
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(spValidarClienteUsuarioProduto.Erro) == false)
                        {
                            ViewBag.Message = spValidarClienteUsuarioProduto.Erro;
                        }
                        else
                        {
                            ViewBag.Message = "Erro ao logar. Por favor, tente novamente.";
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Erro ao logar. Por favor, tente novamente.";
                }
                return View("Index");
            }
            catch (Exception)
            {
                ViewBag.Message = "Erro ao logar. Por favor, tente novamente.";
                return View("Index");
            }
            finally
            { }
        }
    }
}