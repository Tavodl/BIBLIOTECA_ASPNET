using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Libro
{
    public class IndexLibro : PageModel
    {
        private readonly AppDbContext context;

        public IndexLibro(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Libros> Libros { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Libros = await context.Libros.ToListAsync();
        }
    }
}
