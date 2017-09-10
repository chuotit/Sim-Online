using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimOnline.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "RegisterAgent",
                url: "dai-ly-ban-sim",
                defaults: new { controller = "Account", action = "RegisterAgent", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "tai-khoan/dang-ky",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ConfirmEmail",
                url: "tai-khoan/kich-hoat-tai-khoan",
                defaults: new { controller = "Account", action = "ConfirmEmail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ForgotPassword",
                url: "tai-khoan/quen-mat-khau",
                defaults: new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "Admin",
            //    url: "admin",
            //    defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
