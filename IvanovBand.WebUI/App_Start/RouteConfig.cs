using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LowercaseRoutesMVC;

namespace IvanovBand.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            MvcSiteMapProvider.Web.Mvc.XmlSiteMapController.RegisterRoutes(routes);

            routes.MapRoute(
                name: "",
                url: "robots.txt",
                defaults: new { controller = "Home", action = "Robots" }
            );

            routes.MapRoute(
                name: "",
                url: "news",
                defaults: new { controller = "Article", action = "List", page = 1 }
            );

            routes.MapRoute(
                name: "",
                url: "news/page-{page}",
                defaults: new { controller = "Article", action = "List" }
            );

            routes.MapRoute(
                name: "",
                url: "news/{id}/{seoName}",
                defaults: new { controller = "Article", action = "Details" }
            );

            routes.MapRoute(
                name: "",
                url: "music",
                defaults: new { controller = "Song", action = "Index" }
            );

            routes.MapRoute(
               name: "",
               url: "video",
               defaults: new { controller = "Video", action = "List", page = 1 }
           );

            routes.MapRoute(
               name: "",
               url: "video/page-{page}",
               defaults: new { controller = "Video", action = "List" }
           );

            routes.MapRoute(
                name: "",
                url: "video/{id}/{seoName}",
                defaults: new { controller = "Video", action = "Details" }
            );

            routes.MapRoute(
                 name: "",
                 url: "about",
                 defaults: new { controller = "About", action = "List", page = 1 }
             );

            routes.MapRoute(
                 name: "",
                 url: "about/page-{page}",
                 defaults: new { controller = "About", action = "List" }
             );

            routes.MapRoute(
                name: "",
                url: "about/{id}/{seoName}",
                defaults: new { controller = "About", action = "Details" }
            );

            routes.MapRoute(
                name: "",
                url: "contacts",
                defaults: new { controller = "Contact", action = "Index" }
            );

            routes.MapRoute(
                name: "",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{id}/{seoName}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, seoName = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    null,
            //    "", // соответсвует только пустому url (т.е /)
            //    new { controller = "Home", action = "Index" }
            //    );

            //routes.MapRoute(
            //    null,
            //    "Page{page}", // соответсвует /Page1, Page2, но не /PageXYZ
            //    new { controller = "Article", action = "List", category = (string)null },
            //    new { page = @"\d+" } // Ограничения: страница должна быть числовой
            //    );

            //routes.MapRoute(
            //    null,
            //    "{category}", // соответсвует /Football или /AnythingWithNoSlash
            //    new { controller = "Article", action = "List", page = 1 }
            //    );

            //routes.MapRoute(
            //    null,
            //    "{category}/Page{page}", // соответсвет /Football/Page76/
            //    new { controller = "Article", action = "List" }, //  по умолчанию
            //    new { page = @"\d+" } // Ограничения: страница должна быть числовой
            //    );

            //routes.MapRoute(
            //    null,
            //    "{controller}/{action}"
            //    );
        }
    }
}