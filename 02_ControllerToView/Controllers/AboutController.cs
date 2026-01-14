using Microsoft.AspNetCore.Mvc;

namespace _02_ControllerToView.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ad = "Altan Emre";
            ViewBag.Soyad = "Demirci";
            ViewBag.Ders = "ASP.NET";

            ViewData["Mesaj"] = "Hoş Geldiniz";

            TempData["Şehir"] = "İstanbul";


            return View();
        }

        public IActionResult Index2()
        {
            ViewBag.Ad = "Uras";

            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }
    }
}
