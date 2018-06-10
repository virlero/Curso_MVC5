using PaginadorMVC5.Models;
using PaginadorMVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PaginadorMVC5.Controllers
{
    public class HomeController : Controller
    {
        //L65c5
        //L66c1 para que nn se perdan os filtros mentres navegamos, primeiro pasamos  int?edad
        public ActionResult Index(int? edad, int pagina = 1)//pagina=1 para que por defecto sempre caia na pag 1 en caso de que nn se suministre unha pag
        {
            var cantidadRegistrosPorPagina = 2; // deberia estar nun web.config ou configuracion plataforma
            using (var db = new ApplicationDbContext()) //instanciamos el dbcontext
            {
                //L66c2 definimos un predicado e pasamolo  consulta
                //Func<T> é un tipo de delegado predefinido para un método que retorna algún valor do tipo T
                Func<Persona, bool> predicado = x => !edad.HasValue || edad.Value == x.Edad;

                var personas = db.Personas.Where(predicado).OrderBy(x => x.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)//obligatorio order by para facer skip. Skip para saltar tantos registros como indiquemos.
                    .Take(cantidadRegistrosPorPagina).ToList();//con skip usamos Take(tomar registros), despois de saltar x registros tomamos 5.
                var totalDeRegistros = db.Personas.Where(predicado).Count();

                var modelo = new IndexViewModel();//instanciamos  a clase creada ViewModels/IndexViewModel.cs
                modelo.Personas = personas;//pasamos os datos a clase
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;
                //L66c3 esta propiedad e o que fai que se manteñan as variables o entre paginas 
                modelo.ValoresQueryString = new RouteValueDictionary();
                modelo.ValoresQueryString["edad"] = edad;
                //-------------------------------------------------L66c3
                return View(modelo);//retornamos o modelo a vista.
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}