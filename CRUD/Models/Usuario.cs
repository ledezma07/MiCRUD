using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario {  get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Rol {  get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public string? Direccion { get; set; }        
    }
}
