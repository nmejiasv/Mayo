using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:50, ErrorMessage = "EL {0} No puede ser mayor de 50" ) ]
        public string  Nombre { get; set; }

        [Display(Name ="Tipo de operacion")]
        public TipoOperacion TipoOperacionId  { get; set; }
        public int UsuarioId { get; set; }
    }
}
