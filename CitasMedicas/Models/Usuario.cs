using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicas.Models
{
    public class Usuario
    {
        [Required]
        [Display(Name = "Clave de usuario")]
        [DataType(DataType.Password)]
        public string Pws { get; set; }
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
