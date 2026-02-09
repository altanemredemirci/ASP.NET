using _10_Fluent_Validation.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_Fluent_Validation.DataContext
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLDERS; Database=FluentDb; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<Ogrenci> Ogrencis { get; set; }
    }
}
