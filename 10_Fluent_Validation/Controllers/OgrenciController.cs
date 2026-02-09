using _10_Fluent_Validation.DataContext;
using _10_Fluent_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace _10_Fluent_Validation.Controllers
{
    public class OgrenciController : Controller
    {
        ProjectContext db = new ProjectContext();

        public IActionResult Register()
        {
            return View(new Ogrenci());
        }

        [HttpPost]
        public IActionResult Register(Ogrenci model)
        {            
            if (!ModelState.IsValid)
            {               
                return View(model);
            }

            var ogrenci = db.Ogrencis.FirstOrDefault(i => i.Telefon == model.Telefon);

            if (ogrenci != null)
            {
                ModelState.AddModelError("", "Telefon numarası kayıtlı");

                return View(model);
            }


            db.Ogrencis.Add(model);
            db.SaveChanges();

            return View("Success");
        }


    }
}
