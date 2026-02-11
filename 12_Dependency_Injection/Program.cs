using _12_Dependency_Injection.Services;

namespace _12_Dependency_Injection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region LifeTime
            /*
             IStudentService ve StudentService'i Container'a ekliyoruz.
             Net Core Dependency Injedction'da servislerin ömrünü(lifecycle) belirlemek için üç ana yöntem vardýr.
             AddSingleton, AddScoped, AddTransient. Her birinin avantajlarý ve dezavaantajlar vardýr.

            1) AddTransient:Bu yöntemde her istek için yeni bir nesne oluþturulur. Bu servis her kullanýldýðýnda yeni bir örneðin oluþturulacaðý anlamýna gelir.Performans açýsýndan maliyetli olabilir çünkü her istek için yeni bir nesne oluþturulur.

            2) AddScoped:Her http isteði(request) baþýna yeni bir nesne oluþturulur.Ayný istek içinde ayný servis nesnesi kullanýlýr. Ancak farklý isteklerde farklý nesneler oluþturulur. Ýstekler arasýnda veri paylaþýmý yapýlmaz. Bu sebeple bazý durumlarda verimsiz olurlar.

            3) AddSingleton:Uygulama baþladýðýnda bir kez oluþturulan ve uygulama yaþam döngüsüm boyunca ayný kalan tek bir nesne oluþturulur. Performans açýsýndan en verimlisidir. Çünkü tek bir nesne oluþturulur.
            // https://medium.com/@cihanacay/addtransient-addscoped-addsingleton-nedir-nas%C4%B1l-%C3%A7al%C4%B1%C5%9F%C4%B1r-aralar%C4%B1ndaki-fark-ne-3b738166bcdc
            // https://youtu.be/Bhj2XdcoT2Q?t=1827
             
             */
            #endregion

            builder.Services.AddSingleton<IStudentService, StudentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
