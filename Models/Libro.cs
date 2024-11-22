using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Models
{   
    public class Libros
    {
        [Key]
        public int IDLIBRO { get; set; }

        [Required]
        public string TITULO { get; set; } = string.Empty;

        [Required]
        public string EDITORIAL { get; set; } = string.Empty;

        [Required]
        public string AREA { get; set; } = string.Empty;
        
        public required ICollection<Prestamos> Prestamos { get; set; }  // Relación con préstamos

    }
}
