using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EfCodeFirstUsers.Models
{
    public class BogPost
    {
        //L33c8a creamos clase
        public class BlogPost
        {
            public int Id { get; set; }
       
            [Required]//Titulo requerido
            [StringLength(200)] //200 caracteres para titulo
            public string Titulo { get; set; }

            [Required]//contenido requerido
            public string Contenido { get; set; }

            [StringLength(100)]//100 caracteres para autor
            public string Autor { get; set; }
            public DateTime Publicacion { get; set; }

        }
    }

    //L33c8b hablilitamos as migracions a BBDD PM>enable-migrations
}