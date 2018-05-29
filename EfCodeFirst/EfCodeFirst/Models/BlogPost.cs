using EfCodeFirst.Models.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfCodeFirst.Models
{
    /*L33c1 creamos unha clase 
     
     Para Usar Code First temos que ver que en referencias temos instalado Entity Framework. Si no temos instalamolo pulsando 
     btn dereito sobre referencias "Administrar paquetes nugets" - Examinar.
     
     O primeiro que temos que facer é crear un 
     DbContext: clase na que indicamos cales son os modelos que queremos que Entity Framework tome en conta para crear a BBDD,
                cales son os modelos cos que podemos facer querys

    Crear DbContext igual que crear unha clase o que a fai especial é que hereda dunha clase DbContext
                    */
    public class BlogPost: IValidatableObject //L41c1a Validaciones complejas añadimos :IValidatableObject, esto o que fai he heredar da clase indicada
    {
        public int Id { get; set; }
 
        //Titulo requerido
        [Required(ErrorMessage ="O campo {0} é obligatorio")] // L34c1a {0} escribe o nome do campo
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]//contenido requerido
        public string Contenido { get; set; }

        [StringLength(100, MinimumLength = 3,
                ErrorMessage = "O campo {0} debe ter unha " +
            "Lonxitude minima de {2} e maxima de {1}")] //L35c1 debemos facer un PM> update-database porque cambiamos o modelo da tabla
        public string Autor { get; set; }

        //L36c1 rango: se queremos establecer o maximo posible abria que poñer int.MaxValue,double.maxValue. 
        [Range(18,100,ErrorMessage ="O rango de {0} ten que ser entre {1} e {2}")]
        public int Edad { get; set; }

        //L37c1a Compare sive para comparar valores de propiedades do noso modelo
        [StringLength(200)]
        public string Email { get; set; }

        [NotMapped] //Sirve para nn incluir o campo en BBDD
        [System.ComponentModel.DataAnnotations.Compare("Email",ErrorMessage ="Os Emails nn concordan")]
        public string ConfirmarEmail { get; set; }

        //---------------------------------------------------------------L37c1a
        //L38c1a validar  Tarjetas credito
        [CreditCard] //para asegurarnos de que e un numero de tarjeta valido
        //L42c1 Display sirve tamen para mostrar o nombre da clase na view da foma que queiramos.
        [Display(Name ="Tarjeta de Credito")]
        public string TarjetaDeCredito { get; set; }
        //---------------------------------------------------------------L38c1a
        /*L39c1a Remote:sive para crear unha validacion personalizada
            a desventaja é que solo funciona no lado do cliente(solo no navegador)
            Se o usuario nn esta usuarndo javascript no navegador esta validacion nn funciona e se non temos
            activado o jqueryvalidation tampouco*/
                                    //controlador blogpost
        [Remote("DivisibleEntre2","Blogpost",ErrorMessage ="Debe ser un número divisible entre 2 validacion desde cliente")]
        [DivisibleEntre(2,ErrorMessage = "Debe ser un número divisible entre 2 validacion desde servidor")] //L40c1b agregamos a validacion dende o servidor
        public int NumeroDivisibleEntre2 { get; set; }
        //---------------------------------------------------------------L39c1a
       
        public decimal Salario { get; set; }
        public decimal MontoSolicitudPrestamo { get; set; }
        public DateTime Publicacion { get; set; }

        public List<Comentario> Comentarios { get; set; }//L33c7b para un blogpost podremos traer todolos comentarios que lle corresponden

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)//L40c1b o añadir : IValidatableObject se crea automaticamente este metodo
        {
            //L41c1c añadimos validaciones
            var errores = new List<ValidationResult>();
            
            if (Salario * 4 < MontoSolicitudPrestamo)
            {
                errores.Add(new ValidationResult("El monto solicitud préstamo no debe exceder 4 veces el salario",
                    new string[] {"MontoSolicitudPrestamo" }));
            }
            return errores;
            
            //throw new NotImplementedException();
        }
    }

    /*L33c4a se facemos cambios en BD ejecutamos en  "package manager console". PM> update-database e da un error porque
    pasamos de varchar (max) a varchar (100) podendo perder datos.
        -podemos configurar para que sempre o permita (comentario c4b) NN RECOMENDADO
        -podemos forzalo con PM> update-database -force  */
}