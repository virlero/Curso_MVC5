using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//L1c5b agregamos a clase Pelicula:boton dereito sobre models e agragamos
namespace APLI_INTRO.Models
{
    public class Pelicula
    {
        //L1c5c  El descriptor de acceso set permite que los miembros de datos se asignen, y el descriptor de acceso get recupera los valores de los miembros de datos.
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public DateTime Publicacion { get; set; }
        public string Pais { get; set; }
        public bool EstaEnCartelera { get; set; }
    }
}