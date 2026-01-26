using _04_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _04_ViewToController.Controllers
{
    public class HomeController : Controller
    {
        //Action üzerine herhangi bir HTTP tipi verilmez ise default HTTPGET olarak alýr.
        //HTTPGET: Bir View açýlmasýný saðlar.
        //HTTPPOST: Bir viewden gelen post edilmiþ datayý yakalar.

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string kisiler,string ad,bool onay=true)
        {

            //parametre dýþýnda Request.Form komutu ile 
            var k1 = Request.Form["kisiler"];
            var a1 = Request.Form["ad"];
            var c1 = Request.Form["onay"];


            return View();
        }

        [HttpPost]
        public IActionResult Kayit(string isim, string soyisim)
        {

            return View();
        }
    }
}
