using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Prestamos
    {
        [Key]
        public int IDPRESTAMO { get; set; }

        [Required]
        public int IDLECTOR { get; set; }

        [ForeignKey("IDLECTOR")] // Asegura que esta propiedad está relacionada con la tabla "Estudiantes"
        public required Estudiantes Estudiante { get; set; }  // Relación con Estudiante

        [Required]
        public int IDLIBRO { get; set; }
        [ForeignKey("IDLIBRO")] // Asegura que esta propiedad está relacionada con la tabla "Libro"
        public required Libros Libro { get; set; }  // Relación con Libro

        
        [Required]
        public DateTime FECHAPRESTAMO { get; set; }
        public DateTime? FECHAENTREGA { get; set; }

        [Required] 
        public bool DEVUELTO { get; set; } // 1 para "Sí", 0 para "No"


    }
}
