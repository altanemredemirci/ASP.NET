using _12_Dependency_Injection.Models;
using _12_Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {

        //Injection: Program.cs tarafýnda yazýlan Service 'ý içeride tanýmlý service ile baðlanamak.
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        public IActionResult Index()
        {
            var models = _studentService.GetStudents();
            return View(models);
        }

        [HttpPost]
        public IActionResult Search(int numara)
        {
            var model = _studentService.Find(numara);

            ViewBag.Aranan = model;

            //return View("Search", model);

            return View("Index");
        }

        public IActionResult Register()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            _studentService.Create(student);
            return RedirectToAction("Index");
        }

    }
}
