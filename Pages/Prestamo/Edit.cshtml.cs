using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Prestamo
{
public class EditPrestamo : PageModel
{
    private readonly AppDbContext context;

    public EditPrestamo(AppDbContext context)
    {
        this.context = context;
    }

    [BindProperty]
    public Prestamos Prestamos { get; set; } = default!;

    // Lista de SelectListItems para Lectores y Libros
    public List<SelectListItem> Lectores { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> Libros { get; set; } = new List<SelectListItem>();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return RedirectToPage("./Index");
        }

        // Cargar el préstamo
        var prestamo = await context.Prestamos
            .FirstOrDefaultAsync(e => e.IDPRESTAMO == id);
        
        if (prestamo == null)
        {
            return RedirectToPage("./Index");
        }

        Prestamos = prestamo;

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
/////////
public async Task<IActionResult> OnPostAsync()
{

    Console.WriteLine($"IDPRESTAMO: {Prestamos.IDPRESTAMO}");
    Console.WriteLine($"IDLECTOR: {Prestamos.IDLECTOR}");
    Console.WriteLine($"IDLIBRO: {Prestamos.IDLIBRO}");

    var prestamoExistente = await context.Prestamos
        .FirstOrDefaultAsync(p => p.IDPRESTAMO == Prestamos.IDPRESTAMO);

    if (prestamoExistente == null)
    {
        return RedirectToPage("./Index");
    }

    prestamoExistente.IDLECTOR = Prestamos.IDLECTOR;
    prestamoExistente.IDLIBRO = Prestamos.IDLIBRO;
    prestamoExistente.FECHAPRESTAMO = Prestamos.FECHAPRESTAMO;
    prestamoExistente.FECHAENTREGA = Prestamos.FECHAENTREGA;
    prestamoExistente.DEVUELTO = Prestamos.DEVUELTO;

    // Guardar los cambios en la base de datos
    await context.SaveChangesAsync();

    // Redirigir al índice de préstamos después de guardar
    return RedirectToPage("./Index");
}




}


}
