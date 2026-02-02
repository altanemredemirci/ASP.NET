using _09_Models_Binding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _09_Models_Binding.Controllers
{
    public class HomeController : Controller
    {
        //Binding: Bir Veri yapýsýný bir baþka veri yapýsýna veya bir nesneye baðlama iþlemidir.
        //Model Binding: Client'tan (istemci) gelen verileri uygulamanýn model nesnelerine otomatik olarak baðlama iþlemidir.
        //Genellikle web uygulamalarý ve API'lerde kullanýlýr ve uygulamanýn veri modelini güncellemek için verileri iþlemek için kullanýlýr.
        //Toplanan veriler, uygun türlere dönüþtürülür. Örneðin, bir formdan gelen bir string deðeri int'e dönüþtürebilir.

        public IActionResult Index()
        {
            Kisi kisi = new Kisi
            {
                Ad = "Altan Emre",
                Soyad = "Demirci",
                Yas = 36
            };


            return View(kisi);
        }

        public IActionResult Kayit()
        {
            return View(new Kisi());
        }

        [HttpPost]
        public IActionResult Kayit(Kisi kisi)
        {

            return View();
        }

        //Öðrenci: Numara, Ad, Soyad, Telefon, Adres
    }
}
