using EfCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//L33c7g con esta libreria podemos usar funcions lambda para traer os comentarios

/*L33c5d creamos carpeta services e clase 
 
*/
namespace EfCodeFirst.Services
{
    public class BlogPostRepository
    {
        //L33c5e creamos un metodo que devolve unha lista de BlogPost
        public List<BlogPost> ObtenerTodos()
        {
            /*Instanciamos dbcontext
             Usamolo de esta maneira porque dbcontext utiliza
             recursos e metemolo en un using para que se liberen esos recursos
             */
            using (var db = new BlogContext())
            {
                //L33c7f por defecto  db.BlogPosts.ToList(); nn trae os datos da tabla comentarios
                // return db.BlogPosts.ToList();//podemos facer consultas poque o incluimos en Models/BlogContext

                //return db.BlogPosts.Include("Comentarios").ToList();//incluimos comentarios A)
                return db.BlogPosts.Include(x=>x.Comentarios).ToList();//L33c7h B) incluimos comentarios con funcion lambda
                                                                       //Mellor e con lambda porque se cambiamos o nome da tabla comentarios
                                                                       //se cambiaria automaticamente.Cun string non se cambia
                //---------------------------------------L33c7f

            }
        }
        //---------------------------------------------L33c5e

        //L33c6d
        internal void Crear(BlogPost model)
        {
            using (var db = new BlogContext())
            {
                db.BlogPosts.Add(model);
                db.SaveChanges();
            }
        }
        //---------------------------------------------L33c6d

    }
}