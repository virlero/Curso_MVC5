using EfCodeFirst.Models;
using EfCodeFirst.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public object MessageBox { get; private set; }

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


            //L51c1a Ejemplos de como Seleccionar varias columnas (listar)

            // 1:  Selecciona todas as columnas, nn é o mais optimo traerse todo,pq gastamos recursos traendo cousas que nn usamos.
            var listadoPersonasTodasLasColumnas=db.BlogPosts.ToList();

            // 2: Selecciona una columna
            var listadoDeTitulos = db.BlogPosts.Select(x => x.Titulo).ToList();

            // 3: Seleccionar varias columnas e proyectalas en un tipo anonimo (por facelo rápido o ejemplo 2 e 3 facemolo aqui e nn en servicios)
            var listadoBlogPostVariasColumnasAnonimo = db.BlogPosts.Select(x => new {Titulo=x.Titulo,Contenido=x.Contenido,Autor=x.Autor,
                                                                                     Publicacion=x.Publicacion }).ToList();
            
            // 4: Seleccionar varias columnas e proyectalas hacia BlogPost
            var listadoPersonasVariasColumnas= db.BlogPosts.Select(x => new {Titulo = x.Titulo, Contenido = x.Contenido,
                                                                            Autor = x.Autor, Publicacion = x.Publicacion
            }).ToList().Select(x=>new BlogPost() {Titulo = x.Titulo, Contenido = x.Contenido,Autor = x.Autor,
                                                        Publicacion = x.Publicacion }).ToList();

            return View(db.BlogPosts.ToList());
            //---------------------------------------------------------L51c1a



           // return View(model);
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


        //L49c1a Edit  
        // POST: BlogPost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Titulo,,Contenido,Autor,Edad,ConfirmarEmail,Email,TarjetaDeCredito," +
                                    "NumeroDivisibleEntre2,Salario,MontoSolicitudPrestamo,Publicacion")] BlogPost blogpost)//int id, FormCollection collection)
        {
            try
            {
                //L49c1b Metodo 1: Trae el objeto y lo actualiza
                //var blogpostEditar = db.BlogPosts.FirstOrDefault(x => x.Id == blogpost.Id); //busca o primerio registro que id==

                //blogpostEditar.Titulo = blogpost.Titulo; blogpostEditar.Contenido = blogpost.Contenido;
                //blogpostEditar.Autor = blogpost.Autor; blogpostEditar.Edad = blogpost.Edad;
                //blogpostEditar.Email = blogpost.Email;
                //blogpostEditar.ConfirmarEmail = blogpost.ConfirmarEmail;
                //blogpostEditar.TarjetaDeCredito = blogpost.TarjetaDeCredito;
                //blogpostEditar.NumeroDivisibleEntre2 = blogpost.NumeroDivisibleEntre2;
                //blogpostEditar.Salario = blogpost.Salario;
                //blogpostEditar.MontoSolicitudPrestamo = blogpost.MontoSolicitudPrestamo;
                //blogpostEditar.Publicacion = blogpost.Publicacion;
                //db.SaveChanges();

                ////L49c1c Metodo 2: Actualizacion O metodo anterior se nn informas de aljun campo fai update con null este nn
                //var blogpostEditar2 = new BlogPost();
                //blogpostEditar2.Id = blogpost.Id;
                //blogpostEditar2.Titulo = blogpost.Titulo; blogpostEditar2.Contenido = blogpost.Contenido;
                //blogpostEditar2.Autor = blogpost.Autor; blogpostEditar2.Edad = blogpost.Edad;
                //blogpostEditar2.Email = blogpost.Email;
                //blogpostEditar2.ConfirmarEmail = blogpost.ConfirmarEmail;
                //blogpostEditar2.TarjetaDeCredito = blogpost.TarjetaDeCredito;
                //blogpostEditar2.NumeroDivisibleEntre2 = blogpost.NumeroDivisibleEntre2;
                //blogpostEditar2.Salario = blogpost.Salario;
                //blogpostEditar2.MontoSolicitudPrestamo = blogpost.MontoSolicitudPrestamo;
                //blogpostEditar2.Publicacion = blogpost.Publicacion;

                //db.BlogPosts.Attach(blogpostEditar2);/*El método Attach indica a nuestro context que “empiece a 
                //                                    preocuparse” por el destino del objeto que le hemos pasado como 
                //                                    parámetro. Por lo tanto, cualquier cambio realizado sobre este objeto
                //                                    será ahora repercutido sobre la fuente de datos al invocar el método SaveChanges().*/
                //db.Entry(blogpostEditar2).Property(x => x.Titulo).IsModified=true; //si a propiedade  Titulo e modificada, ejecutao na bbdd
                //db.Entry(blogpostEditar2).Property(x => x.Contenido).IsModified = true;
                //db.SaveChanges();

                //L49c1d Metodo 3: Objeto externo actualizado
                db.Entry(blogpost).State = EntityState.Modified;
                db.SaveChanges();

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //-------------------------------------L49c1a

       //L50c1a
        // GET: BlogPost/Delete/5
        public ActionResult Delete(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogpost = db.BlogPosts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }

            return View(blogpost);
        }

        // POST: BlogPost/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                BlogPost blogpost = db.BlogPosts.Find(id);
                db.BlogPosts.Remove(blogpost);//Borra un registros
               // db.BlogPosts.RemoveRange(list);//con RemoveRange borramos varios a vez
                
                db.SaveChanges();
                
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //----------------------------------------------L51c1a
    }
}
