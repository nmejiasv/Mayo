using ManejoPresupuesto.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta //: IValidatableObject
    {
        public int Id { get; set; }
    
    [Required(ErrorMessage ="El {0} es requeerido")]
        //[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud minima es de {2} y maxima {1}")]
        //[Display(Name ="Nombre del tipo cuenta")]
        [PrimeraLetraMayuscula]
        [Remote(action: "VerificarExisteTipoCuenta", controller: "TiposCuentas")]
    public string Nombre { get; set; }
    public int UsuarioId { get; set; }
    public int  Orden  { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length>0)
        //    {
        //        var primeraLetra = Nombre[0].ToString();
        //        if (primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("Primera Letra debe ser Mayuscula", 
        //                new[] {nameof(Nombre)} );
        //        }
        //    }
        //}


        //[Required(ErrorMessage = "El campo {0} es requerido")]
        //[EmailAddress(ErrorMessage = "Debe ingresar un email vaiido")]
        //public string Email { get; set; }

        //[Range(minimum: 18, maximum: 130, ErrorMessage = "La edad debe ser entre {1} y {2}")]
        //public int Edad { get; set; }

        //[Url(ErrorMessage = "Ingrese una URL valida")]
        //public string Url { get; set; }

        //[CreditCard(ErrorMessage = "La tarjeta de credito no es valida")]
        //[Display(Name = "Tarjeta de credito")]
        //public string TarjetaDeCredito { get; set; }
    }
}
