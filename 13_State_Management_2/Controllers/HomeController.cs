using _13_State_Management_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Mevcut Session ve Cookie verilerini oku
            ViewBag.SessionUserName = HttpContext.Session.GetString("UserName");
            ViewBag.CookieTheme = Request.Cookies["Theme"] ?? "Light";
            ViewBag.CookieLanguage = Request.Cookies["Language"] ?? "TR";
            return View();
        }

        public IActionResult SetSession(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                // Session'a kullanýcý adýný kaydet
                HttpContext.Session.SetString("UserName", userName);

                // Ziyaret sayýsýný artýr
                int visitCount = HttpContext.Session.GetInt32("VisitCount") ?? 0;
                HttpContext.Session.SetInt32("VisitCount", visitCount + 1);

                // Son ziyaret zamanýný kaydet
                HttpContext.Session.SetString("LastVisit", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));

                TempData["Message"] = $"Session ayarlandý: {userName}";
            }
            else
            {
                TempData["Error"] = " Kullanýcý adý boþ olamaz!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult GetSession()
        {
            string username = HttpContext.Session.GetString("UserName") ?? "Bulunamadý";
            int visitCount = HttpContext.Session.GetInt32("VisitCount") ?? 0; 
            return RedirectToAction("Index");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Tüm session verileri silindi";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetCookie(string theme, string language)
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                IsEssential = true
            };

            if (!string.IsNullOrEmpty(theme))
            {
                Response.Cookies.Append("theme", theme, cookieOptions);
            }

            if (!string.IsNullOrEmpty(language))
            {
                Response.Cookies.Append("language", language, cookieOptions);
            }

            TempData["Message"] = $"Cookie ayarlandý - Tema:{theme}, Dil:{language}";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCookies()
        {
            Response.Cookies.Delete("theme");
            Response.Cookies.Delete("language");

            TempData["Message"] = "Tüm cookie'ler silindi.";
            return RedirectToAction("Index");

        }


    }
}
