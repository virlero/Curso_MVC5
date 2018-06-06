namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /*L33c3a Para crear a BBDD debemos poñer en "package manager console" (herramientas-administrador paquetes nugets)
            PM> enable-migrations 
            
         -Se creará configuations dentro da carpeta migrations, para poder realizar configuracions dentro e Entity Framework*/
    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirst.Models.BlogContext>
    {
        public Configuration()
        {
            //L33c3b AutomaticMigrationsEnabled = false;
            /*poñemolo a true porque é un ejemlo rapido. Esto fai que Entity framework faga  os cambios pertinentes por nos.
             Por ejemplo, se agregamos una nova propiedad nunha clase e temos AutomaticMigrationsEnabled = True;
             Entity framework altera a BBDD por nos . Eu no recomendo poñelo a true.
             Las  migraciones se realicen de forma automática, así nos ahorraríamos el tener que ir a la Consola
             del Administrador de paquetes y escribir estos 2 comandos:
                    Add-Migration
                    Update-Database (con este seria suficiente)3a
           */

                      AutomaticMigrationsEnabled = true;



            /*L33c4b AutomaticMigrationDataLossAllowed = true; moi perigoso porque este comando a true significa que si 
             facemos PM> update-database  , e por ejemplo pasamos de varchar(5) a (2) fariao sen problemas podendo
                perder caracteres nos datos da BD*/
           // AutomaticMigrationDataLossAllowed = true;
        }

        /*L33c3c Para crear a BD temos que ejecutar en "package manager console". PM> update-database
          O cal analiza Dbcontext, os modelos e crea ou modifica a BD*/ 

        protected override void Seed(EfCodeFirst.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            /*L33c7d Para este ejemplo nn queremos facer un create para comentarios polo que usamos o metodo seed
                    Metodo Seed: sirve para dar de alta automaticamente registros en BBDD
             
             */
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 1,
                Autor = "Ele",
                BlogPostId = 1,
                Contenido = "Ejemplo de contenido Seed"
            });
        }
    }
}
