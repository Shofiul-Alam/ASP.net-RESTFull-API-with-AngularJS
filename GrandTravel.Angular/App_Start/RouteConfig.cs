using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GrandTravel.Angular
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "EditCustomer",
               url: "Account/Edit/{HashId}",
               defaults: new { controller = "Account", action = "Index", HashId = "" }
           );

            routes.MapRoute(
               name: "AccountPannel",
               url: "Account/{Pannel}",
               defaults: new { controller = "Account", action = "Index", Pannel = "" }
           );
            routes.MapRoute(
              name: "CreateCustomer",
              url: "Account/Create/{id}",
              defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
            name: "EditCustomerByAdmin",
            url: "Admin/customer/edit/{HashId}",
            defaults: new { controller = "Account", action = "Index", HashId = "" }
        );
        routes.MapRoute(
            name: "PackageDetails",
            url: "PackageDetails/{packageId}",
            defaults: new { controller = "PackageDetails", action = "Index", packageId = "" }
        );

        }
    }
}
