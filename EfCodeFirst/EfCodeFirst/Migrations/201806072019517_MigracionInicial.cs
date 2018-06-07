namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /*L59c2a PM> Add-migration dinos os cambios que vai haber na nosa BBDD antes de realizalos.
          se todo crea automaticamente ejecutando  PM> Add-migration -Name MigracionInicial
     En este caso creao vacío porque nn tiñamos cambios no modelo. O código generao en C#.
     */
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            //L59c2b Aqui indicase o que vai a pasar na BBDD cando se ejecuta o comando PM>update-database
        }

        public override void Down()
        {
            //L59c2c aqui  revierto todo lo indicado en Up()
        }
    }
}

/*L59c2d Podemos modificar o código a mano. Cando ejecuemos Update-database ejecutarase os cambios.
 -Se ainda nn ejecutamos PM> update-database podemos modificala automaticamento co comando:
     PM> Add-migration Name MigracionInicial -Force

  -Todos as migracion que fagamos se van a gardar e nun momneto dado podemos volver a versión que queramos con:
     PM> update-database -TargetMigration: Nombre migracion a que queremos voltar


     */
