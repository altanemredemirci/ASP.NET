using _03_Template_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_Template_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
