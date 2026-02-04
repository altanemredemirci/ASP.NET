using _10_Fluent_Validation.Models;
using _10_Fluent_Validation.ViewModels;
using FluentValidation;//FluentValidaiton kütüphanesini kullanarak model doðrulama iþlemleri için gerekli.
using FluentValidation.Results;//Doðrulama sonuçlarýný tutmak için gerekli sýnýf.
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_Fluent_Validation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValidator<HomeViewModel> _validator; //FluentValidation doðrulama iþlemleri için kullanýlan validator nesnesi

        //Injection
        public HomeController(IValidator<HomeViewModel> validator)
        {
            _validator = validator; //Dependency Injection ile validator nesnesi alýnýr.
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(HomeViewModel model)
        {
            //post edilen model'in doðrulamalarýný yapmak için bir validator iþlemi gerçekleþtiriyoruz.
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    //Tespit edilen hatalarý ModelState ekleyerek sayfaya geri taþýmak.
                    //Taþýnan hatalar <span asp-validation-for="KisiNesnesi.Ad" class="text-danger"></span> kodu ile  ekrana getirilecek.
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); //Hata mesajlarýný ModelState'e ekle
                }

                return View("Index", model);
            }

            //if (!ModelState.IsValid)
            //{
            //    return View("Index", model);
            //}




            return View("Success");
        }

       
    }
}
