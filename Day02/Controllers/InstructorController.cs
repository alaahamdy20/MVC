using Microsoft.AspNetCore.Mvc;
using Day02.Models;
using Day02.ViewModel;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
using Day02.Service;

namespace Day02.Controllers
{
    public class InstructorController : Controller
    {
        //MVCDBContext db = new MVCDBContext();
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEntityService<Department> entityDepartmentService;
        private readonly IEntityService<Instractor> entityInstractorService;
        private readonly IEntityService<Course> entityCourseService;

        public InstructorController(IWebHostEnvironment hostEnvironment,IEntityService<Department> entityDepartmentService, IEntityService<Instractor> entityInstractorService, IEntityService<Course> entityCourseService)
        {
            webHostEnvironment = hostEnvironment;
            this.entityDepartmentService = entityDepartmentService;
            this.entityInstractorService = entityInstractorService;
            this.entityCourseService = entityCourseService;
        }
        public IActionResult Index()
        {
            return View(entityInstractorService.GetAll());
        }
        /*public ActionResult Details(int id)
        {
            return View(db.Instractors.Include(m=>m.CIdNavigation).Include(m => m.DIdNavigation).SingleOrDefault(i => i.Id == id));
        }*/
        public ActionResult Edit(int id)
        {
            //IEnumerable<Department> depts = db.Departments.ToList();
            //IEnumerable<Course> courses = db.Courses.ToList();
            ViewBag.depts = entityDepartmentService.GetAll();
            ViewBag.courses = entityCourseService.GetAll();
            return View(entityInstractorService.GetAll().SingleOrDefault(i => i.Id == id));
        }


        private string UploadedFile(Instractor model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpPost]
        public ActionResult SaveEdit(Instractor newInstractor)
        {

            /*Instractor oldInstractor = db.Instractors.SingleOrDefault(i => i.Id == newInstractor.Id);
            oldInstractor.Salary = newInstractor.Salary;
            oldInstractor.CId = newInstractor.CId;
            oldInstractor.Name = newInstractor.Name;
            oldInstractor.DId = newInstractor.DId;
            oldInstractor.Address = newInstractor.Address;*/
            entityInstractorService.Update(newInstractor.Id,newInstractor);
            string uniqueFileName = UploadedFile(newInstractor);

            if (uniqueFileName != null)
            {
                entityInstractorService.GetById(newInstractor.Id).Image = uniqueFileName;
                entityInstractorService.Update(newInstractor.Id, newInstractor);

            }
            return RedirectToAction(nameof(Index));
        }



        public ActionResult Create()
        {
            //List<Department> depts = db.Departments.ToList();
            //List<Course> courses = db.Courses.ToList();
            ViewBag.depts = entityDepartmentService.GetAll();
            ViewBag.courses = entityCourseService.GetAll();
            return View(new Instractor());
        }
        [HttpPost]
        public ActionResult SaveCreate(Instractor newInstractor)
        {
            string uniqueFileName = UploadedFile(newInstractor);

            //newInstractor.Imag = "https://images.unsplash.com/photo-1539571696357-5a69c17a67c6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8N3x8bWFufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60";
            newInstractor.Image = uniqueFileName;
            //db.Instractors.Add(newInstractor);
            //db.SaveChanges();
            entityInstractorService.Update(newInstractor.Id,newInstractor);
            return RedirectToAction(nameof(Index));
        }
    }
}
