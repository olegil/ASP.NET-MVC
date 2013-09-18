using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("Home/About");

            routes.MapRoute(
                "Gallery",
                "UserAlbum/{albumId}/{albumName}",
                new { controller = "Home", action = "Album", albumId = UrlParameter.Optional, albumName = "" }
            );

            routes.MapRoute(
                "About",
                "About",
                new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "Album",
                "{controller}/{action}/{albumId}",
                new { controller = "Home", action = "Album", albumId = UrlParameter.Optional }
            );            

            routes.MapRoute(
                "Activate",
                "Account/Activate/{username}/{key}",
                new { controller = "Account", action = "Activate", username = UrlParameter.Optional, key = UrlParameter.Optional });
        }
    }
}