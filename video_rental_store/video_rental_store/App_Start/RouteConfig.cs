using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace video_rental_store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

/*            routes.MapRoute(
                name: "MovieByRealeseDate",
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate", year = UrlParameter.Optional, month = UrlParameter.Optional},
               constraints: new {year = @"\d{4}", month = @"\d{2}"}
            );

            routes.MapRoute(
                name: "Edit",
                url: "{controller}/{action}/{movieId}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );*/

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
