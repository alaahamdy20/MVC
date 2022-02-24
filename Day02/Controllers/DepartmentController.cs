using Day02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Day02.Service;
namespace Day02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IEntityService<Department> entityDepartmentService;
        private readonly IEntityService<Instractor> entityInstractorService;

        //private readonly MVCDBContext db = new MVCDBContext();
        public DepartmentController(IEntityService<Department> entityDepartmentService, IEntityService<Instractor> entityInstractorService)
        {
            this.entityDepartmentService = entityDepartmentService;
            this.entityInstractorService = entityInstractorService;
        }
        public IActionResult Index(int id)
        {
            ViewBag.depts = new SelectList(entityDepartmentService.GetAll(), "Id", "Name", id);
            ViewBag.deptName = entityDepartmentService.GetAll().FirstOrDefault(d => d.Id == id).Name;
            return View(entityInstractorService.GetAll().Where(s=>s.DId == id).ToList());
        }


        public IActionResult AjaxMethod(int deptid)
        {
            /*ViewBag.depts = new SelectList(db.Departments, "Id", "Name", id);
            string txt = db.Departments.FirstOrDefault(d => d.Id == id).Name;*/
            ViewBag.deptName = entityDepartmentService.GetAll().FirstOrDefault(d => d.Id == deptid).Name;
            return PartialView("_DisplayAllStudent", entityInstractorService.GetAll().Where(s => s.DId == deptid).ToList());
        }
    }
}
