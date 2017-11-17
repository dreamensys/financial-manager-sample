using System.Web.Mvc;

namespace WebApp.Attributes
{
    public class AuthorizeManager : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Transaction/Index");
            }
        }
    }

}