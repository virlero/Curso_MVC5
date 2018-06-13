using EfCodeFirstUsers.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfCodeFirstUsers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //L71c6 vamos a ver como accederós valores dun usuario autenticado.
            if(User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var idUsuarioActual = User.Identity.GetUserId();

                    var userManager = new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(db));

                    var usuario = userManager.FindById(idUsuarioActual);//usuario:variable tipo applicationUser
                    var lugarDeNacimiento = usuario.LugarDeNacimiento;

                }
            }
            

            //--------------------------------------L71c6

            return View();
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