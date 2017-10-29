using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homework3.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Homework3.Controllers
{
    public class HomeController : Controller
    {
        UniversityContext db;
        public HomeController(UniversityContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            return View(db.Students.First(student => student.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            db.Students.Update(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View("CreateStudent");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var student = db.Students.FirstOrDefault(p => p.Id == id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
