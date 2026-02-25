using _14_Middleware.Middlewares;
using _14_Middleware.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Middleware.Controllers
{
    public class HomeController : Controller
    {
        //Middleware, farklý uygulamalar,sistemler ve veritabanlarý arasýnda etkileþim ve veri akýþý saðlayan hizmetlerdir.
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Visitor Count'u ViewBag'e ekle
            ViewBag.VisitorCount = VisitorCounterMiddleware.GetVisitorCount();

            //HttpContext'ten de alabilirsin
            if (HttpContext.Items.ContainsKey("VisitorCount"))
            {
                ViewBag.CurrentVisitorCount = HttpContext.Items["VisitorCount"];
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(username=="admin" && password == "123")
            {
                //Session'a kaydet
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Kullanýcý Adý ve Þifre Hatalý!";
            return View();
        }

        public IActionResult Dashboard()
        {
            //Middleware'den gelen verileri ViewBag'e aktar.
            ViewBag.TotalVisitors = HttpContext.Items["VisitorCount"] ?? 0;
            ViewBag.CurrentPageVisits = HttpContext.Items["CurrentPageVisits"] ?? 0;

            return View();
        }
    
        public IActionResult Admin()
        {
            //Middleware'den gelen verileri ViewBag'e aktar.
            ViewBag.TotalVisitors = HttpContext.Items["TotalVisitors"] ?? 0;
            ViewBag.CurrentPageVisits = HttpContext.Items["CurrentPageVisits"] ?? 0;

            return View();
        }

        public IActionResult AuthMiddlewareInfo()
        {
            ViewBag.TotalVisitors = HttpContext.Items["TotalVisitors"] ?? 0;
            ViewBag.CurrentPageVisits = HttpContext.Items["CurrentPageVisits"] ?? 0;
            return View();
        }

        public IActionResult Settings()
        {
            //Middleware'den gelen verileri ViewBag'e aktar.
            ViewBag.TotalVisitors = HttpContext.Items["VisitorCount"] ?? 0;
            ViewBag.CurrentPageVisits = HttpContext.Items["CurrentPageVisits"] ?? 0;

            return View();
        }


        public IActionResult VisitorMiddlewareInfo()
        {
            ViewBag.VisitorCount = VisitorCounterMiddleware.GetVisitorCount();
            return View();
        }

        public IActionResult ErrorMiddlewareInfo()
        {
            ViewBag.TotalVisitors = HttpContext.Items["VisitorCount"] ?? 0;
            ViewBag.CurrentPageVisits = HttpContext.Items["CurrentPageVisits"] ?? 0;

            return View();
        }

        public IActionResult TimeMiddlewareInfo()
        {
            ViewBag.TotalVisitors = HttpContext.Items["VisitorCount"] ?? 0;
            ViewBag.CurrentPageVisits = HttpContext.Items["CurrentPageVisits"] ?? 0;

            return View();
        }



        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
