using _05_HtmlHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _05_HtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Models.User
            {
                CountryList = GetCountries()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(User model)
        {
            if (ModelState.IsValid) //gelen model yazýlan attribute lere uygun olarak gönderilmiþ mi? 
            {
                //Form verilerini iþleme(Veritabanýna kaydetme vb)
                //Örneðin model verilerini ekrana yazdýrmak için:
                ViewBag.Message = $"Name:{model.Name}, Age:{model.Age}, IsSubscribed:{model.IsSubscribed}, Gender:{model.Gender}, Country:{model.Country}";
                return View("Result", model);
            }

            model.CountryList = GetCountries();
            return View("Index", model);
        }

        private IEnumerable<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value="US", Text="United States"},
                new SelectListItem{Value="CA", Text="Canada"},
                new SelectListItem{Value="MX", Text="Mexico"}
            };
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
