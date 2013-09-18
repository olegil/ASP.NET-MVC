using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mail;
using System.Web.Mvc;
using System.Web.Routing;
using UI.Helpers;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string cultureName = CultureHelper.GetCultureFromCookies(Request);           
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}