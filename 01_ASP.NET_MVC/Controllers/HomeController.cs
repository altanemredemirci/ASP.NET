using Microsoft.AspNetCore.Mvc;

namespace _01_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {

        //IActionResult döndüren her metot aslında bir view sayfasını açar.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
