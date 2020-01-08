//L1c5e añadimos a libreria models
using APLI_INTRO.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APLI_INTRO.Services
{
    public class PeliculasService
    {
        //L1c5f creamos unha funcion que retorna unha clase pelicula ó controlador
        public Pelicula ObtenerPelicula()
        {
            return new Pelicula()
            {
                Titulo = "Memento",
                Duracion = 115,
                Pais = "USA",
                Publicacion = new DateTime(2001, 01, 19),
                EstaEnCartelera =true
            };
        }
        //L1c6a retornamos unha lista de peliculas
        public List<Pelicula> ObtenerPeliculas()
        {
            var pelicula1 = new Pelicula()
            {
                /*L16C1 Titulo = "<b>La naranja mecánica</b>" si poñemos lenguaje html nn funciona na vista
                 porque MVC nos protege de mostrar codigo html que ven de fora das vistas, para proteger
                 de posibles ataques.
                 
                 Poderiase usar se nas vistas escribimos @Hrml.Raw(pelicula.titulo)
                 pero nn é recomentable. Moi perigoso, porque poden ejecutar javascript
                 */
                Titulo = "La naranja mecánica",
                Duracion = 137,
                Pais = "Reino Unido",
                Publicacion = new DateTime(1975, 06, 16),
                EstaEnCartelera = false
            };
            var pelicula2 = new Pelicula()
            {
                Titulo = "Oldboy",
                Duracion = 120,
                Pais = "Corea del Sur",
                Publicacion = new DateTime(2005, 01, 28),
                EstaEnCartelera = true
            };

            return new List<Pelicula> { pelicula1, pelicula2 };
        }
        //--------------------------------------------L1c6a
    }
}