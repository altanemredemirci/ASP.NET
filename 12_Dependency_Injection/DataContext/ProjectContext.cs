using _12_Dependency_Injection.Models;
using Microsoft.EntityFrameworkCore;

namespace _12_Dependency_Injection.DataContext
{
    public class ProjectContext:DbContext
    {
        /*
         Kurulan Paketler:
            *Microsoft.EntityFrameworkCore.Tools
            *Microsoft.EntityFrameworkCore.SqlServer
            *Microsoft.EntityFrameworkCore
            *
         *DbContext sınıfını miras aldık.
         *override void OnConfiguring() metodu ile database bağlantısını tanımladık
         *DBSet<> ile tablo olmasını istediğimiz classları tanımladık
         

         Interface olarak oluşurulan IStudentService üzerinden ben controller tarafında isteklerde bulunacağım.
         Interface ise bir normal class a bağlanmış olacak. Bu bağlantı yönetimine DEPENDENCY INJECTION yani bağımlılık yönetimi denir.



         */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLDERS; Database=DependencyDB; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<Student> Students { get; set; }

    }
}
