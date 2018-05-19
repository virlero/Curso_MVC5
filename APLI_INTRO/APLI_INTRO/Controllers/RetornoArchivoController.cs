using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APLI_INTRO.Controllers
{
    public class RetornoArchivoController : Controller
    {
        /*L4c1 AccionResult e generico e con el podemos retornar vistas,archivos, json
       Pero  podemos ser mais especifico e indicarlle que retorne un archivo
       por ejemplo con FileResult, para retornar vista ponemos ViewResult*/
        //https://msdn.microsoft.com/en-us/library/system.web.mvc.actionresult(v=vs.118).aspx
        //https://msdn.microsoft.com/es-es/library/system.web.mvc.actionresult(v=vs.118).aspx
        public ActionResult Index()
        {
            // return View();
            // return File(Server.MapPath("~/archivos/Entrenamiento.pdf"), "application/pdf");


            // L9c1 descargar archivo
            var ruta = Server.MapPath("~/archivos/Entrenamiento.pdf");
            return File(ruta, "application/pdf","Ejemlopdf1.pdf");
        }
        public FileResult Retornotxt()
        {
            return File(Server.MapPath("~/archivos/nota.txt"), "application/txt");
        }  
    }
}