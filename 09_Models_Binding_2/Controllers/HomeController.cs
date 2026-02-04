using _09_Models_Binding_2.Models; //Kisi ve Adres modellerini kullanmak için gerekli
using _09_Models_Binding_2.ViewModels;
using Microsoft.AspNetCore.Mvc; //Controller sýnýfý ve ilgili iþlevler için gerekli
using System.Diagnostics;

namespace _09_Models_Binding_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Kisi sýnýfýndan bir nesne oluþturuluyor ve örnek veriler atanýyor 
            Kisi kisi = new Kisi()
            {
                Ad = "Altan Emre",
                Soyad = "Demirci",
                Yas = 36
            };

            //Kisi nesnesini View'e taþýdýk.
            return View(kisi);
        }

        public IActionResult Index2()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Altan Emre",
                Soyad = "Demirci",
                Yas = 36
            };

            Adres adres = new Adres()
            {
                AdresTanim = "Kadýköy/Caferaða Mah.",
                Sehir = "Ýstanbul"
            };

            //View içerisine hem kisi nesnesini hem de adres nesnesini ayný anda taþýyamam.

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.KisiNesnesi = kisi;
            homeViewModel.AdresNesnesi = adres;

            return View(homeViewModel);
        }
    }
}
