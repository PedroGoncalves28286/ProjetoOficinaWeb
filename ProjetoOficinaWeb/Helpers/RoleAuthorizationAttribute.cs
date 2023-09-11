using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoOficinaWeb.Helpers
{
    public class RoleAuthorizationAttribute : ActionFilterAttribute
    {
        private readonly string[] _allowedRoles;

        public RoleAuthorizationAttribute(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
            else
            {
                bool userHasRole = false;
                foreach (var role in _allowedRoles)
                {
                    if (context.HttpContext.User.IsInRole(role))
                    {
                        userHasRole = true;
                        break;
                    }
                }

                if (!userHasRole)
                {
                    context.Result = new RedirectToActionResult("Login", "Account", null);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
