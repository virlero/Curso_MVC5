using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APLI_INTRO.Models
{
    public class APLI_INTROContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public APLI_INTROContext() : base("name=APLI_INTROContext")
        {
        }

        //L27c1b este contexto maneja as tablas que vai a ter o sql, esto necesitao Entity framework para comunicarse ca BBDD
        public System.Data.Entity.DbSet<APLI_INTRO.Models.Pelicula> Peliculas { get; set; }
    }
}
