using PaginadorMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*L5c4 creamos IndexViewModel donde hereda de BaseModelo e añadimos ademais 
 * unha lista de personas que seran o listado de registros resultados da busqueda
 */

namespace PaginadorMVC5.ViewModels
{
    public class IndexViewModel : BaseModelo
    {
        public List<Persona> Personas { get; set; }
    }
}