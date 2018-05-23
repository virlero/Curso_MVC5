//L1c5h añadimos a libreria 
using APLI_INTRO.Models;
using APLI_INTRO.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace APLI_INTRO.Controllers
{

    /*L1c1 HomeControlet es una clase que hereda de la clase base controller
     y tiene distintos metodos (Index, About,Contact) los metodos retornan un
     ActionResult:como un link dentro da aplicación
     
     Cada controlador ten as sua carpeta de vistas:
        -Ejemplo: As vistas de Homecontroler estan en view ../view/home
     
      En routeconfig configuramos las rutas*/
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //L21c1b
            ViewBag.MiListado = ObtenerListado();
            //-----------------------------L21c1b
            //L22c2b

            ViewBag.MiListadoEnum = ToListSelectListItem<ResultOpeDropDownList>();
            //-----------------------------L21c2b

            /* return View() .net é o bastante inteligente en que debe retornar a vista Index
              que está na carpeta Home.
              Podemos indicar que vista manda escrindo return View("Nombre vista");*/
            return View();
        }

        public ActionResult ProbaView()
        {
            return View("PaginaPruebaVista");
          
        }

        public ActionResult EjemploBeginForm()
        {
            return View();
        }
        //L23c1a Facer un formulario utilizando o metodo BeginForm.Para usalo temos que facer Post.
        [HttpPost]
        public ActionResult EjemploBeginForm(Pelicula pelicula)//creamos un post para o action. Pode haber outra accion igual pero get.(por  defecto é  HttpGet a nn ser que se indique o metodo)
        {
            ViewBag.Message = "Exitoso";

            return View(pelicula);
        }
        //--------------------------------------------------------------L23c1a

        //L22c2a este metodo debería ir en services.Poñemolo aqui para acabar antes
        private List<SelectListItem> ToListSelectListItem<T>()//toma como argumento un tipo generico T
        {
            var t = typeof(T);//devuelve el tipo de dato de T

            if (!t.IsEnum) { throw new ApplicationException("Tipo debe ser enum"); }//comprueba que T es enum

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);// traemos los miembros del enum que recibe

            var result = new List<SelectListItem>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),
                   false );

                var description = member.Name;

                if (attributeDescription.Any())//si tiene el atributo de description mete la descripcion en lugar del name
                {
                    description = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }
           
                var valor = ((int)Enum.Parse(t, member.Name)); //parseamos o valor
                result.Add(new SelectListItem() // agregamolo  a variable result
                {
                    Text = description,
                    Value = valor.ToString()
                });

            }
            return result;
        }

        //------------------------------------------------------L22c2a


        public ActionResult About(int num)//L17c2c recibe variable
        {
            ViewBag.Message = "Your application description page."+num.ToString();
            //L19c1a DisplayTemplates
            ViewBag.Propiedad1 = "prueba Display";
            
            var peliculaServiceDisplay = new PeliculasService();
            ViewBag.Propiedad2 = peliculaServiceDisplay.ObtenerPelicula();

            //---------------------------------------------------L19c1

            /*L1c5d vamos a crear unha clase que nos sirva os modelos o controlador:
               -Creamos unha carpeta de servicios
               -dentro creamos unha clase que se encargará de coordinar todo o que teña que ver cas peliculas */
            /*L1c5g instanciamos a clase PeliculasService */

            //var peliculaService = new PeliculasService();
            //var model1 = peliculaService.ObtenerPelicula();
            //// ---------------------------------------------------------L1c5g
            ////L1c5i pasamos model a vista
            //return View(model);

            /*L1c6b instanciamos a clase PeliculasService */

            var peliculasService2 = new PeliculasService();
            var model2 = peliculasService2.ObtenerPeliculas();
            return View(model2);
            //--------------------------------------------------L1c6b
        }

        /*L10c1a vamos a pasar parametros a un action con un Query String
         Query Sting:localhost:port?nombre=1&apellido=1
         el signo ? indica que se va a utilizar un query string,a continuacion 
         pasanse as variables separadas por &.
         Si el action no usa los string simplemente los ignora.
         Ejemplo con Contact(string nombre)

        -Los valores tipo nn poden ter nulos (ejemplo int)
             */
        [HttpGet]//significa que este metodo se usará para un get
        public ActionResult Contact(string nombre,string apellido,int edad)//L10c1b
        {
            ViewBag.Message = "Your contact page. " + nombre +" "+apellido +" Edad: "+edad.ToString();//L10c1c

            return View();
        }

        //L11c1 Realizaremos un post
        [HttpPost] //la ventaja de indicar esto es que para una misma acción puedes ejecutar ordeneres distintas (get,post) 

        //Get se utiliza para recibir informacion desde una pagina y post para enviarla
                                        //podrias pasar clases tamen
        public ActionResult Contact(string nombre,  int edad)
        {
            ViewBag.Message = "Your contact page. " + nombre + " Edad: " + edad.ToString();

            return View();
        }
        //-----------------------------------------------------------------L11c1

        //L8c1 
        public HttpStatusCodeResult Statuscode()
        {
            //return new HttpStatusCodeResult(301, "Comunicación correcta");
            return new HttpStatusCodeResult(404, "Recurso no encontrado");
        }

        /*L12c1a ejemplo ViewBag e ViewData
         ViewBag:objeto que permite enviar información do action hacia a vista mediante variables ejemplo ViewBag.Message="dadssa"
         ViewData:igual que el ViewBag pero con distinta sintaxis
        El valor de la variable solo se mantiene en la vista, el tiempo de vida es muy corto. */
        public ActionResult EjemploViewBag_Data()
        {
            ViewBag.Message = "prueba comentario ViewBag";
            ViewBag.numero = 45;
            ViewBag.Fecha = new DateTime(1800, 4, 7);
            ViewData["MiMensaje"] = "Texto con ViewData";
            return View();
        }
        //-----------------------------------------------L12c1a
        //L14c1a
        public ActionResult L14_Layout_y_shared()
        {
            return View();
        }
        //-----------------------------------------------L14c1a


        //L18c1 RenderAction ejemplo
        public ActionResult PruebaRenderActionA()
        {
            return View();
        }
        /*L18c4 [ChildActionOnly]  significa que esta accion solo se ejecutará 
        dentro de unha vista, polo que non podemos acceder poñendo a direccion no
        navegador*/
        [ChildActionOnly]
        public ActionResult PruebaRenderActionB()
        {
            return View();
        }

        //L21c1a ejemplo DropDownList. Creamos un metodo que devolva una lista
        public List<SelectListItem> ObtenerListado()
        {
            //var listado = new List<SelectListItem>()
            return new List<SelectListItem>()
            {
                 new SelectListItem()
                {
                     Text ="Si",
                    Value="1"
                },
                new SelectListItem()
                {
                    Text ="No",
                    Value="2"
                },
                new SelectListItem()
                {
                    Text ="quizas",
                    Value="3",
                    Disabled=true //desactivar opcion
                }

            };
            //return listado;
        }
        //-------------------------------------------------------------L12c1a

       

    }
   
}