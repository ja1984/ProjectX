using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                "ProjectDetails",
                "project/{id}/{projectName}", // URL
                new { controller = "project", action = "details", projectName = UrlParameter.Optional }, // URL Defaults
                new { id = @"\d+" } // URL Constraints
            );


            routes.MapRoute(
                "UserDetails",
                "user/{id}/{userName}", // URL
                new { controller = "user", action = "details", userName = UrlParameter.Optional }, // URL Defaults
                new { id = @"\d+" } // URL Constraints
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}