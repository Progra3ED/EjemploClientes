using System.ComponentModel.DataAnnotations;

namespace EjemploClientes.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "El NIT es requerido")]
        [StringLength(13, ErrorMessage = "El NIT debe tener 13 caractéres")]
        public string Nit { get; set; } = string.Empty;


        [Required(ErrorMessage = "El Nombre es requerido")]
        [Display(Name = "Nombre del Cliente")]
        
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [Display(Name = "Apellido del Cliente")]        
        public string Apellido { get; set; } = string.Empty;
        public int Edad {  get; set; }
    }
}
