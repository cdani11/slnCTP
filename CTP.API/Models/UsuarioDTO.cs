using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTP.API.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(60)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Nombre de usuario excede capacidad de almacenamiento, longitud máxima 15")]
        public string NombreUsuario { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Correo inválido.")]
        public string Correo { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Contraseña excede capacidad de almacenamiento, longitud máxima 15")]
        public string Contrasena { get; set; }
    }
}
