using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace APLI_INTRO.Controllers
{
    //L6c1a creamos a clase persona, na creamos en clases porque o facemos en local que é mais rapido
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
    public class RetornoJsonController : Controller
    {
        // GET: retornoJson
        //public ActionResult Index() // con action result envia Json pero pordemos ser mais especificos
        public JsonResult Index()
        {
            //L6c1b instanciamos a clase
            var persona1 = new Persona() { Nombre = "Lucía", Edad = 30 };
            var persona2 = new Persona() { Nombre = "Ele", Edad = 33 };
            /*l6c1c retorno Json: return Json(persona1);
             NOTA:Da un error porque estamos facendo un get request e para 
                permitir poder devolver json desde un get request hay que 
                establecer que o vamos a permitir porque o normal é 
                devolver información Json desde un Post.
                de momento vamos a permitilo con  JsonRequestBehavior.AllowGet
             */

            // return Json(persona1,JsonRequestBehavior.AllowGet);

            //enviamos lista de personas
            return Json(new List<Persona>() { persona1, persona2}, JsonRequestBehavior.AllowGet);

        }
    }
}