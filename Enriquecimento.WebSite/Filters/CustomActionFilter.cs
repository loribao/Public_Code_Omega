using Enriquecimento.WebSite.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Enriquecimento.WebSite.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
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
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            #region Código  : depois que a action 
            #endregion
        }
    }
}