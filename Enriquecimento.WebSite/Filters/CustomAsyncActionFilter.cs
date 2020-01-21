using Enriquecimento.WebSite.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Enriquecimento.WebSite.Filters
{
    public class CustomAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            #region Código :  antes que a action executa
            //Verificar se o usuário esta logado
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                if ((string.IsNullOrEmpty(controllerActionDescriptor.ControllerName) == false) &&
                    (controllerActionDescriptor.ControllerName.Contains("Login") == false) &&
                    (controllerActionDescriptor.ControllerName.Contains("Erro") == false))
                {
                    var usuarioLogado = context.HttpContext.Session.Get<Models.SessionUsuarioLogado>("UsuarioLogado");
                    if (usuarioLogado == null)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                    }
                    else if (usuarioLogado.IdUsuario == 0)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                    }
                }
            }
            #endregion
            await next();
            #region Código  : depois que a action executa
            #endregion
        }
    }
}