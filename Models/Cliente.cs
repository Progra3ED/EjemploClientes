using System.ComponentModel.DataAnnotations;

namespace EjemploClientes.Models
{
    public class Cliente
    {
        
        public string Nit { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad {  get; set; }
    }
}
