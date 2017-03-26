using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhoneDirectory
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "addDepartment",
               url: "departman-ekle",
               defaults: new { controller = "Admin", action = "addDepartments" }
             
               );
            routes.MapRoute(
               name: "addEmployee",
               url: "calisan-ekle",
               defaults: new { controller = "Admin", action = "addEmployee" }
              
               );
            routes.MapRoute(
               name: "changePass",
               url: "admin-güncelle-{id}",
               defaults: new { controller = "Admin", action = "changePass", id = "" }
               );
            routes.MapRoute(
               name: "Departments",
               url: "departman-listesi",
               defaults: new { controller = "Admin", action = "Departments" }
            
               );
            routes.MapRoute(
               name: "editDepartment",
               url: "departman-güncelle-{id}",
               defaults: new { controller = "Admin", action = "editDepartment",id="" }

               );
            routes.MapRoute(
               name: "editEmployee",
               url: "calisan-güncelle-{id}",
               defaults: new { controller = "Admin", action = "editEmployee", id = "" }

               );
            routes.MapRoute(
               name: "error",
               url: "hata",
               defaults: new { controller = "Admin", action = "error"}

               );
            routes.MapRoute(
              name: "Index",
              url: "calisan-listesi",
              defaults: new { controller = "Admin", action = "Index" }

              );
            routes.MapRoute(
             name: "Details",
             url: "calisan-detay-{id}",
             defaults: new { controller = "Home", action = "Details",id="" }

             );
            routes.MapRoute(
              name: "LogIn",
              url: "admin-girisi",
              defaults: new { controller = "Home", action = "LogIn" }

              );
            routes.MapRoute(
             name: "Rehber",
             url: "rehber",
             defaults: new { controller = "Home", action = "Rehber" }

             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Rehber", id = UrlParameter.Optional }
            );
        }
    }
}
