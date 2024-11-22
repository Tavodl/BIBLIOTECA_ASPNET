using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Models
{   
    public class Estudiantes
    {
        [Key]
        public int IDLECTOR { get; set; }

        [Required]
        public string CI { get; set; } = string.Empty;

        [Required]
        public string NOMBRE { get; set; } = string.Empty;

        [Required]
        public string DIRECCION { get; set; } = string.Empty;
        
        [Required]
        public string CARRERA { get; set; } = string.Empty;
        
        public int EDAD { get; set; }
        public required ICollection<Prestamos> Prestamos { get; set; }  // Relación con préstamos

    }
}
