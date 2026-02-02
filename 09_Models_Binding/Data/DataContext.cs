using _09_Models_Binding.Models;
using Microsoft.EntityFrameworkCore;

namespace _09_Models_Binding.Data
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLDERS; Database=OkulDB; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<Ogrenci> Ogrencis{ get; set; }
    }
}
