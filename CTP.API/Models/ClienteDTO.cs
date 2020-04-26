using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTP.API.Models
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Correo inválido.")]
        public string Correo { get; set; }
        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string Especialidad { get; set; }
        public DateTimeOffset FechaCreacion { get => DateTimeOffset.Now; }
    }
}
