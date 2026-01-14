namespace _01_ASP.NET_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Web uygulamasý için bir mimar oluþturur.
            var builder = WebApplication.CreateBuilder(args);

            // MVC design pattern mantýðýný entegre ediyor.
            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Http pipeline ý yapýlandýrma
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // HSTS (Http Strict Transport Security )
                app.UseHsts();
            }

            // HTTPS yönlendirme eklendi (HTTP isteklerini HTTPS'e yönlendirme )
            app.UseHttpsRedirection();

            // Statik dosyalarý (CSS,JavaScript,vb) sunmak için middleware eklendi
            app.UseStaticFiles();

            // Routing (yönlendirme) için middleware eklendi
            app.UseRouting();

            // Yetkilendirme middleware'ini eklendi.(Kullanýcýlarýn belirli kaynaklara eriþimini kontrol eder.)
            app.UseAuthorization();

            // Varsayýlan rota yönlendirmesi
            // URL'ler de belirtilen kontrolör ve aksiyona göre yönlendirme yapar.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); //Home controller altýndaki Index aciton(metot) çalýþtýr. id parametresi(opsiyonel) gelebilir.

            app.Run();
        }
    }
}
