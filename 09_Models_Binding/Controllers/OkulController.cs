using _09_Models_Binding.Data;
using _09_Models_Binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace _09_Models_Binding.Controllers
{
    public class OkulController : Controller
    {
        public IActionResult Register()
        {
            return View(new Ogrenci());
        }

        [HttpPost]
        public IActionResult Register(Ogrenci ogrenci)
        {
            DataContext db = new DataContext();
            db.Ogrencis.Add(ogrenci);
            db.SaveChanges();
            return View();
        }
    }
}
