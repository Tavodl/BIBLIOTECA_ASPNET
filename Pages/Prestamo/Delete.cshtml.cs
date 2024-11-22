using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Prestamo
{
    public class DeletePrestamo : PageModel
    {
        private readonly AppDbContext context;

        public DeletePrestamo(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id==null)
            {
                return Page();
            }

            var prestamos = await context.Prestamos.FindAsync(id);

            if(prestamos == null)
            {
                return Page();
            }
            else
            {
                Prestamos = prestamos;
                context.Prestamos.Remove(Prestamos);
                await context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
