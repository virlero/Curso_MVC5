using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APLI_INTRO.Controllers
{
    public class RetornoStringController : Controller
    {
        // GET: DevolverString
        public ActionResult Index()
        {
            /*L5c1a Devolver desde un action un string libre
                 return Content("asdad","aplication/json"); poñemos o texto 
                 logo o tipo, se  non poñemos nada colleo por defecto.

                podemos devolver contenido html */
            //return Content("Texto libre proba string desde un action");
            return Content("<h1>Contenido en html</h1>");

        }
    }
}