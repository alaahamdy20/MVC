using Microsoft.AspNetCore.Mvc;
using Day01.Repository;
namespace Day01.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(StudentRepository.GetAllStudents());
        }
        public ActionResult Details(int id = 101)
        {
            return View(StudentRepository.GetStudentById(id));
        }
    }
}
