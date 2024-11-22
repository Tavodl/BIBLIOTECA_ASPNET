using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapea la clase Estudiantes a la tabla ESTUDIANTE
            modelBuilder.Entity<Estudiantes>().ToTable("ESTUDIANTE");
            modelBuilder.Entity<Libros>().ToTable("LIBRO");
            modelBuilder.Entity<Prestamos>().ToTable("PRESTAMO");

        }

    }
}
