using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{employeeID}",
                defaults: new { controller = "Employee", action = "Index", employeeID = UrlParameter.Optional }
            );

        }
    }
}