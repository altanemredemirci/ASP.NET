using _10_Fluent_Validation.Validators;
using _10_Fluent_Validation.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace _10_Fluent_Validation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            //Dependency Injection ile bir service yardýmýyla hazýrladýðýmýz validator tanýmý proje yayýnýna açýyoruz.
            //Eklenen service homecontroller altýnda constructor metot ile Inject edilerek kullanýlýyor.
            builder.Services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<HomeViewModelValidator>();
            });

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
                pattern: "{controller=Ogrenci}/{action=Register}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
