﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cartegraph
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Issues", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(

            //    name: "Employee",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Employee",action = "GetAllEmployees"}
            //    );
        }
    }
}
