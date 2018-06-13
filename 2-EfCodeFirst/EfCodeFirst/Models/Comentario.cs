using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfCodeFirst.Models
{
    //L33c7a creamos nueva clase relacionada con BlogPost
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public string Autor { get; set; }
        public int BlogPostId { get; set; }//clave foranea
        [ForeignKey("BlogPostId")]
        public  BlogPost BlogPost { get; set; } //Agremamos unha propiedad navegacional, desde un comentario
                                                //podemos obter todas a propiedades do blogpost que lle corresponde
    }
}