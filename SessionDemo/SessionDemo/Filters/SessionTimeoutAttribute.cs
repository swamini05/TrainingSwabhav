using System.Web;
using System.Web.Mvc;

namespace SessionDemo.Filters
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Session",
                        action = "Login"
                    }));
            }
            base.OnActionExecuting(filterContext);
        }
    }

}