using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Estudiante
{
    public class EditEstudiante : PageModel
    {
        private readonly AppDbContext context;

        public EditEstudiante(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Estudiantes Estudiantes { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return RedirectToPage("./Index");
            }

            var estudiantes = await context.Estudiantes.FirstOrDefaultAsync(e => e.IDLECTOR == id);

            if(estudiantes == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Estudiantes = estudiantes;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
        
            context.Estudiantes.Update(Estudiantes);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
