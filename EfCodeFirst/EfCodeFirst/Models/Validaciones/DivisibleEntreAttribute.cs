using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


//L40c1a como remote solo valida na parte do cliente creamos unha clase para validacion na parte do servidor
namespace EfCodeFirst.Models.Validaciones
{
    //para crear un atributo e usalo para a validacion, este debe heredar de :ValidationAttribute
    public class DivisibleEntreAttribute: ValidationAttribute //añadimos :ValidationAttribute
    {
        private int _dividendo;
        public DivisibleEntreAttribute(int dividendo) //creamos un constructor
            : base("El campo 0} é invalido{")
        {
            _dividendo = dividendo;//o campo que recibimos igualamolo a _dividendo para usalo en IsValid
        }
                                                      //o valor recibido definimolo como objecto porque no sabemos que tipo de dato va a ser.
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                if((int)value % _dividendo!=0) //si nn é divisible error
                {
                    var mensajeDeError = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensajeDeError);//retornamos error
                }
            }
            return ValidationResult.Success;// se é nulo mandamos validacion correcta porque required se encarga de validar si acepta nulos ou nn
        }

    }
}
//----------------------------------------------------------------------------------------------L40c1b