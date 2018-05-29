using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EfCodeFirst.Models
{
    //L33c2a Añadirmo ":DbContext"- esto significa que hereda dunha clase DbContext
    public class BlogContext:DbContext
    {
        /*L33c2b indicamos cales son os modelos que vamos a usar como tablas
         * 
         public DbSet<BlogPost> BlogPost { get; set; }
             DbSet:propiedad para poder realizar consultas desde C#
                    <BlogPost> tipo do modelo o cal queremos facer querys
                    seguido do nombre que vai ter a tabla  

        Se quiseramos indicar un conectionString especifico porque temos definido varios, poderse crear un
        constructor ca clase e en base pasamos o contection string:
          public BlogContext()
                :base("cadenaconexion1") 
            {
            }
            */
        public BlogContext()
            :base("cadenaconexion1")
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }


        /*L33c7c añadimos Dbset comentarios y ejecutamos PM>update-database -verbose
        con vebose vemos la query*/
        public DbSet<Comentario> Comentarios { get; set; }


    }
}