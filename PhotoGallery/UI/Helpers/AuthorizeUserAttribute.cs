using BLLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI.Helpers
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string AccessLevel { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            string privilegeLevels = string.Join("", UserBLLService.GetUserRights(httpContext.User.Identity.Name.ToString()));

            if (privilegeLevels.Contains(this.AccessLevel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}