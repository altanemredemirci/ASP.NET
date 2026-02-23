using _13_State_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {
        //Session,Cookie
        //Session state, kullanýcýnýn oturum süresince verilerini saklanmasýný saðlar. Oturum sona erdiðinde bu veriler silinir.
        //Session state özellikle kullanýcýnýn bilgilerini saklanmasý gerektiðinde kullanýlýr.Fakat þifre, kredi kartý gibi bilgiler saklanmamalýdýr.

        public IActionResult Index()
        {
            //HttpContext.Session.SetString("Username", "Altan Emre");

            ////Session veri okuma
            //var sessionUserName = HttpContext.Session.GetString("Username");

            ////Cookie state sunucu tarafýnda deðil, kullanýcý(client,tarayýcý) tarafýnda saklanýr. kullanýcý tarayýcýsýný kapatýp açsa bile cookiler geçerlilik süresi boyunca saklanýr. Kesinlikle özel bilgiler saklanmaz.

            ////Cookie oluþturma
            //var cookieOptions = new CookieOptions
            //{
            //    Expires = DateTime.Now.AddMinutes(30),
            //    HttpOnly = true,
            //    IsEssential = true
            //};

            ////Set Cookie
            //Response.Cookies.Append("UserName", "Altan Emre", cookieOptions);


            ////GetCookie
            //var cookieUserName = Request.Cookies["UserName"];

            //// View'e yollayalým
            //ViewBag.SessionUserName = sessionUserName;
            //ViewBag.CookieUserName = cookieUserName;


            if (HttpContext.Session.GetString("Username") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }


            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            if (username == "altanemre")
            {
                HttpContext.Session.SetString("Username", "Altan Emre");

                //Session veri okuma
                var sessionUserName = HttpContext.Session.GetString("Username");

                //Cookie state sunucu tarafýnda deðil, kullanýcý(client,tarayýcý) tarafýnda saklanýr. kullanýcý tarayýcýsýný kapatýp açsa bile cookiler geçerlilik süresi boyunca saklanýr. Kesinlikle özel bilgiler saklanmaz.

                //Cookie oluþturma
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(30),
                    HttpOnly = true,
                    IsEssential = true
                };

                //Set Cookie
                Response.Cookies.Append("UserName", "Altan Emre", cookieOptions);


                //GetCookie
                var cookieUserName = Request.Cookies["UserName"];
            }
           

            return RedirectToAction("Index");
        }


        //[Authorize]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
