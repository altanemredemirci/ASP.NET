using _03_Template_MVC_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_Template_MVC_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult BookTable()
        {
            return View();
        }
    }
}
