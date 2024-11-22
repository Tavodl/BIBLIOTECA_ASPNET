using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Prestamo
{
    public class IndexPrestamo : PageModel
    {
        private readonly AppDbContext context;

        public IndexPrestamo(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Prestamos> Prestamos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            //Prestamos = await context.Prestamos.ToListAsync();
                        // Incluye las relaciones de Estudiante y Libro
            Prestamos = await context.Prestamos
                .Include(p => p.Estudiante)  // Incluye el Estudiante
                .Include(p => p.Libro)  // Incluye el Libro
                .ToListAsync();

        }
    }
}
