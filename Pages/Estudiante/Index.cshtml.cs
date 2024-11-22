using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Estudiante
{
    public class IndexEstudiante : PageModel
    {
        private readonly AppDbContext context;

        public IndexEstudiante(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Estudiantes> Estudiantes { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Estudiantes = await context.Estudiantes.ToListAsync();
        }
    }
}
