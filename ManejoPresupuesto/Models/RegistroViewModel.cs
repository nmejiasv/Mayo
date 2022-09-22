using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo{0} es reqierido")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo{0} es reqierido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
