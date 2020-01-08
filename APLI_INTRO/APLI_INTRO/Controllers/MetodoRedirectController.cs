using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APLI_INTRO.Controllers
{
    public class MetodoRedirectController : Controller
    {
        // GET: MetodoRedirect
        //L7c1a 
        //public ActionResult Index()
        //1* -public RedirectResult Index()

        /*2*nn sempre nos conven poñer unha accion a retorna fija(RedirectToRouteResult),
        as veces é mellor poñer un ActionResult porque o retorno pode variar.
        Ejemplo: Video: 7-.Redirect,RedirectToAction y RedirectToRouute.mp4: min3:30*/
        //2*public RedirectToRouteResult Index()
        public RedirectToRouteResult Index()
        {
            //1*- return Redirect("https://www.google.com/");

            //                       accion controlador
            //2* return RedirectToAction("About","Home");

            //devolve ruta de RouteConfig: se escribe el name
            return RedirectToRoute("retorpdf");
        }
    }
}