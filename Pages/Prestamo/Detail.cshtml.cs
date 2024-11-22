using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Prestamo
{
    public class DetailPrestamo : PageModel
    {
        private readonly AppDbContext context;

        public DetailPrestamo(AppDbContext context)
        {
            this.context = context;
        }

        public Prestamos Prestamos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return RedirectToPage("./Index");
            }

            var prestamos = await context.Prestamos.FirstOrDefaultAsync(e => e.IDPRESTAMO == id);

            if(prestamos == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Prestamos = prestamos;
                return Page();
            }
        }
    }
}
