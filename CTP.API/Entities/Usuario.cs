using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTP.API.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(60)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(15)]
        public string NombreUsuario { get; set; }
        [Required]
        [MaxLength(50)]
        public string Correo { get; set; }
        [Required]
        [MaxLength(15)]
        public string Contrasena { get; set; }
        public bool NuevaContrasena { get; set; }
    }
}
