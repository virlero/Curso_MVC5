using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace APLI_INTRO
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //L3c1 los routes.MapRoute los lee por orden y si ejecuta bien el primero no va al segundo

            routes.MapRoute(
                name:"Ejemplo",
                url:"Ejemplo",
                defaults: new
                {
                    //le decimos que si la Url es Ejemplo vaya al controlador home accion contact
                    //http://localhost:51169/Ejemplo
                    controller = "Home",
                    action="Contact"
                }
             );
        
            //L4c2 probamos la configuracion de rutas aunque podemos usar default
            routes.MapRoute(
               name: "retornartxt",
               url: "retornartxt",
               defaults: new
               {
                   controller = "RetornoArchivo",
                   action = "Retornotxt"
               }
            );

            routes.MapRoute(
                name: "retorpdf",
                url: "retornarpdf",
                defaults: new
                {
                    controller = "RetornoArchivo",
                    action = "Index"
                }
             );
            //------------------------------L4c2

            routes.MapRoute(
            /*L1c2
              url: "{controller}/{action}/{id}":como se compon a url.Os nombres que son variables van ente{}
               decimos que temos que indicar o controlador e a accion.*/
            name: "Default",
            url: "{controller}/{action}/{id}",
            /*L1c3 se nn indicamos nada por defecto utiliza o controlador home e accion index
              ASP .net  é o bastante inteligente para saber que si escribimos Home ten que ir o controlador HomeControler */
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );

        }
    }
}