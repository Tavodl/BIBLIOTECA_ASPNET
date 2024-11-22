using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Prestamo
{
    public class CreatePrestamo : PageModel
    {
        private readonly AppDbContext context;

        public CreatePrestamo(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Prestamos Prestamos { get; set; } = default!;

        // Lista de SelectListItems para Lectores y Libros
        public List<SelectListItem> Lectores { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Libros { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtener los Lectores (Estudiantes) para el dropdown
            Lectores = await context.Estudiantes
                .Select(lector => new SelectListItem
                {
                    Value = lector.IDLECTOR.ToString(),
                    Text = lector.NOMBRE // Ajusta el campo según la propiedad que desees mostrar
                }).ToListAsync();

            // Obtener los Libros para el dropdown
            Libros = await context.Libros
                .Select(libro => new SelectListItem
                {
                    Value = libro.IDLIBRO.ToString(),
                    Text = libro.TITULO // Ajusta el campo según la propiedad que desees mostrar
                }).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Crear un nuevo préstamo
            context.Prestamos.Add(Prestamos);

            // Guardar los cambios en la base de datos
            await context.SaveChangesAsync();

            // Redirigir al índice de préstamos después de guardar
            return RedirectToPage("./Index");
        }
    }
}
