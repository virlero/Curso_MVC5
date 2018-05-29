using EfCodeFirst.Models;
using EfCodeFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


/* L33c5a Creamos o controlador:btn der sobre home -agregar contolador,
 * escollemos "MVC5 controller con lectura e escritura".
 
 Si escolleramos usando Entity framework scafoldin faria todo o engranaje pero queremolo facer desde 0
     */
namespace EfCodeFirst.Controllers
{
    public class BlogPostController : Controller
    {

       /*la conexión al contecto de la BBDD no debería estar aqui.
        O controlador solo se debería de encargar de coordinar a comunicación entre os distintos
        elementos da aplicación.
        No deberiamos guardar,ni editar. Debemos crear unha clase ou sercio aparte que debe ter este tipo
        de responsabilidades. O controlador simplemente debe chamar a esa clase*/
        private BlogContext db = new BlogContext();




        //L33c5f facemos un constructor
        private BlogPostRepository _repo;
        public BlogPostController()
        {
            _repo = new BlogPostRepository();
        }
        //-------------------------------------L33c5f
        // GET: BlogPost
        public ActionResult Index()
        {
            //L33c5b creamos vista: btn dereito-agregar vista|Template/pantilla:list|clase de modelo:BlogPost

            //L33c5g 
            var model = _repo.ObtenerTodos();
            //L33c7e por probar lo que mete en la variable 
           // var comentario = model[0].Comentarios[0];//se necesita que tenga al menos un comentario si no falla

            return View(model);
            /*mandamos o modelo a vista, esto e unha MALA PRACTICA
                Por ejemplo: se temos unha Query de  1.000.000 de registros seria lento porque son moitos,
                ademais mandamolo todo.Como é un ejemplo simple deixamolo asi.
             */
            //----------------------------------L33c5g
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
 
            return View();
        }
        //L39c1b
        public JsonResult DivisibleEntre2(int NumeroDivisibleEntre2)
        {
            var esValido = NumeroDivisibleEntre2 % 2 == 0;
            return Json(esValido, JsonRequestBehavior.AllowGet);

        }
        //----------------------------------------L39c1b

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            //L33c6a creamos vista: btn dereito-agregar vista|Template/pantilla:create|clase de modelo:BlogPost
            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        //L33c6c añadimos Create(BlogPost model)
        public ActionResult Create(BlogPost model)//FormCollection collection)
        {
            try
            {
                /*L34c1c se comentamos na vista  @Scripts.Render("~/bundles/jqueryval"), a validacion de datos faise 
                 solo desde aqui*/
                if (ModelState.IsValid)//indicamos se as reglas de validacion son cumplidas
                {
                    _repo.Crear(model);//error:btn dereito -crear internal void Crear(BlogPost model) en Services/Blogrepository

                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
              //log gardariamos a excepcion nun log ou BBDD
            }
            return View(model);//se ocurre unha exception ou o modelo nn é valido retornamos o modelo o usuario
        }
        //-----------------------------------------L33c6c

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int? id)
        {
            //nota: se queremos crear edit temos que instanciar a clase que vai devolver e crear codigo
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost BlogPost =db.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return HttpNotFound();
            }
            return View(BlogPost);
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
