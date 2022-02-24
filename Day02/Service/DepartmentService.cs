using Day02.Models;
using System.Collections.Generic;
using System.Linq;

namespace Day02.Service
{


    public class DepartmentService : IEntityService<Department>
    {

        /*public CourseService(MVCDBContext db)
        {
            this.db = db;
        }*/
        private readonly MVCDBContext db;

        public DepartmentService(MVCDBContext db)
        {
            this.db = db;
        }
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(d => d.Id == id);
        }
        public int Add(Department newDepartment)
        {
            db.Departments.Add(newDepartment);
            return db.SaveChanges();
        }
        public int Update(int id, Department newDepartment)
        {
            Department oldnewDepartment = GetById(id);
            oldnewDepartment.Name = newDepartment.Name;
            oldnewDepartment.Manger = newDepartment.Manger;            
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            db.Departments.Remove(GetById(id));
            return db.SaveChanges();
        }
    }
}
