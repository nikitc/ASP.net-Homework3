using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Homework3.Models;
using Homework3.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Homework3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataManager _dataManager;
        public HomeController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dataManager.StudentRepository.GetAllStudents().ToList());
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var service = (IDataManager)HttpContext
                .RequestServices
                .GetService(typeof(IDataManager));
            var student = service.StudentRepository.GetById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var student = _dataManager.StudentRepository.GetById((int)id);
                if (student != null)
                {
                    return View(student);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent([FromServices]IDataManager service, Student student)
        {
            if (!ModelState.IsValid)
                return View("EditStudent", student);

            _dataManager.StudentRepository.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var student = new Student();
            return View("EditStudent", student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            var dataManager = ActivatorUtilities
                .GetServiceOrCreateInstance<IDataManager>(HttpContext.RequestServices);

            if (!ModelState.IsValid)
                return View("EditStudent", student);


            dataManager.StudentRepository.Create(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = _dataManager.StudentRepository.GetById(id);
            if (student == null)
                return NotFound();

            _dataManager.StudentRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
