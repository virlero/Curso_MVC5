using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
        /*L47c1a OnModelCreating:Metodo que sirve para facer configuraciones de como Entitty framework va a trabajar
                                   con nuestra BBDD.
                                   
             Ejecutar PM>update-database: los datetimes los pone en datetime2 y si una propiedad int donde el nombre 
                               empieza por "Codigo" se configurará como primary jey*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));

            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo"))
                    .Configure(p => p.IsKey());

            base.OnModelCreating(modelBuilder);
        }
        //------------------------------------------------------------------L47c1a
        /*L47c1b ShouldValidateEntity:Nos indica cando unha operación se debe validar  */
        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            if(entityEntry.State==EntityState.Added)
            {
                return true; //si State es added se realiza validacion (true)
            }
            return base.ShouldValidateEntity(entityEntry);
        }

        //la validacion la haremos en este metodo:
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
            IDictionary<object, object> items)
        {
            if(entityEntry.Entity is BlogPost && entityEntry.State==EntityState.Added)
            {
                var entidad = entityEntry.Entity as BlogPost;
                if(entidad.Edad>75)
                {
                    return new DbEntityValidationResult(entityEntry, new DbValidationError[] {
                        new DbValidationError("Edad","No se puede insertar un mayor de 75.")});
                }
            }
           
            return base.ValidateEntity(entityEntry, items);
        }

        /*SaveChanges garda os cambios que se fixeron se garden. Hasta que nn lle deas a sace changes calquera cambio e nulo
             */
        //public override int SaveChanges()
        //{
        //    var entidades = ChangeTracker.Entries();
            
        //    if( entidades !=null)
        //    {
        //        foreach(var entidad in entidades.Where(c=>c.State!=EntityState.Unchanged))
        //        {
        //            Auditar(entidad);
        //        }
        //    }

        //    return base.SaveChanges();
        //}

        //private void Auditar(DbEntityEntry entidad)

        //------------------------------------------------------------------L47c1b


        /*L33c7c añadimos Dbset comentarios y ejecutamos PM>update-database -verbose
        con vebose vemos la query*/
        public DbSet<Comentario> Comentarios { get; set; }


    }
}