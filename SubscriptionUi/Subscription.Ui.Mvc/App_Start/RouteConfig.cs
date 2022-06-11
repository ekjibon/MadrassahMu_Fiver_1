using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Subscription.Ui.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add("Default", new WildcardRoute(
            //    "*",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Security", action = "Auth", id = UrlParameter.Optional, area = "Subscription" }, //routeData becomes null when controller not included
            //    new { }
            //));

            routes.MapRoute(
                name: "NullArea",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
