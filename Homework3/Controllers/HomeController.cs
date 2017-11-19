using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homework3.Models;

namespace Homework3.Controllers
{
    public class HomeController : Controller
    {
        readonly UniversityContext _db;
        public HomeController(UniversityContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Students.ToList());
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            return View(_db.Students.First(student => student.Id == id));
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (!ModelState.IsValid)
                return View("EditStudent", student);

            _db.Students.Update(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View("CreateStudent");
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View("CreateStudent", student);

            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var student = _db.Students.FirstOrDefault(p => p.Id == id);
                if (student != null)
                {
                    _db.Students.Remove(student);
                    _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
