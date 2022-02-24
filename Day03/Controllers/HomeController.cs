using Day03.Models;
using Day03.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Day03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MVCContext db = new MVCContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /* List<StudentResultViewModel> students =
                 db.Courses.Join(
                     db.CrsResults,
                     c => c.Id,
                     Crs => Crs.CrsId, (c, crs) => new { Id = crs.CrsId, Name = c.Name, MinDegree = c.Mindegree })
                 .Join(

                     db.Trainees,
                     c => c.Id,
                     t => t.Id, (c, t) => new StudentResultViewModel { stdId = t.Id, CrsId = c.Id, cName = c.Name, Name = t.Name, MinDegree = c.MinDegree, Degree = t.Greade }
                     ).ToList();*/


            List<StudentResultViewModel> students =
                db.CrsResults.
                Include(c => c.Crs).
                Include(c => c.Trainee).
                Select(s => new StudentResultViewModel { stdId = s.TraineeId, CrsId = s.CrsId, cName =  s.Crs.Name ,Name = s.Trainee.Name,Degree = s.Degree ,MinDegree = s.Crs.Mindegree  }).
                ToList(); ;
             

            return View(students);
        }



        public IActionResult Show(int StdId, int CrsId)
        {
            /*StudentResultViewModel student =
             db.Courses.Join(
                    db.CrsResults,
                    c => c.Id,
                    Crs => Crs.CrsId,
                    (c, crs) => new { Id = crs.CrsId, Name = c.Name, MinDegree = c.Mindegree })
                .Join(

                    db.Trainees,
                    c => c.Id,
                    t => t.Id, (c, t) => new StudentResultViewModel { stdId = t.Id, CrsId = c.Id, cName = c.Name , Name = t.Name, MinDegree = c.MinDegree, Degree = t.Greade }
                    ).SingleOrDefault(s => s.stdId == StdId && s.CrsId == CrsId);         
                ;*/


            StudentResultViewModel student =
               db.CrsResults.
               Include(c => c.Crs).
               Include(c => c.Trainee).
               Select(s => new StudentResultViewModel { stdId = s.TraineeId,CrsId = s.CrsId, cName = s.Crs.Name, Name = s.Trainee.Name, Degree = s.Degree, MinDegree = s.Crs.Mindegree }).
               SingleOrDefault(s => s.stdId == StdId && s.CrsId == CrsId);

            return View(student);
        }


        // entity lazy loading

        public IActionResult Test()
        {
            var q1 = db.CrsResults;
            var q2 = q1.SingleOrDefault(c => c.CrsId == 1&&c.TraineeId == 1);
            
            return Json(q2);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



       




    }
}
