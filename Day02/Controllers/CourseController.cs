using Day02.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Day02.Service;

namespace Day02.Controllers
{
    public class CourseController : Controller
    {
        //MVCDBContext db = new MVCDBContext();
        private readonly IEntityService<Course> entityCourseService;
        private readonly IEntityService<Department> entityDepartmentService;

        public CourseController(IEntityService<Course> entityCourseService, IEntityService<Department> entityDepartmentService)
        {
            this.entityCourseService = entityCourseService;
            this.entityDepartmentService = entityDepartmentService;
        }

        //home 
        public IActionResult Index()
        {
            return View(entityCourseService.GetAll());
        }


        // add couurse
        public ActionResult New()
        {
   
            //List<Department> depts = db.Departments.ToList();
            ViewBag.depts = entityDepartmentService.GetAll();
            return View();
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public ActionResult New(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                /*db.Courses.Add(newCourse);
                db.SaveChanges();*/
                entityCourseService.Add(newCourse);
                return RedirectToAction(nameof(Index));
            }
            //List<Department> depts = db.Departments.ToList();
            //List<Department> depts = entityDepartmentService.GetAll();
            ViewBag.depts = entityDepartmentService.GetAll();

            return View(newCourse);


        }

        public IActionResult IsNameAvailble(string Name)
        {
            Course course = entityCourseService.GetAll().FirstOrDefault(c => c.Name == Name);
            if (course != null)
            {
                return Json(false);

            }
            return Json(true);
        }
        
       
        //IsGrater
        public IActionResult IsGrater(int Mindegree, int Degree)
        {
            
            return Json(Mindegree<Degree);
        }

        //about
        public IActionResult About()
        {
            return View();
        }


    }
}
