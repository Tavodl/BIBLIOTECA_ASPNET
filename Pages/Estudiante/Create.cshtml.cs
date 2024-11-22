using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Estudiante
{
    public class CreateEstudiante : PageModel
    {
        private readonly AppDbContext context;

        public CreateEstudiante(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Estudiantes Estudiantes { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            context.Estudiantes.Add(Estudiantes);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
