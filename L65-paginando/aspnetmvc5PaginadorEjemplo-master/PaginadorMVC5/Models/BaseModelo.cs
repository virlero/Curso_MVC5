using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

//L65c3 creamos unha base modelo  
namespace PaginadorMVC5.Models
{
    public class BaseModelo
    {
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
        //L66c4 para conservar os variables entre paginas e asi nn perder os filtros cando paxinamos
        public RouteValueDictionary ValoresQueryString { get; set; }
    }
}