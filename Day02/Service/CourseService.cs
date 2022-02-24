using Day02.Models;
using System.Collections.Generic;
using System.Linq;

namespace Day02.Service
{


    public class CourseService : IEntityService<Course>
    {
        private readonly MVCDBContext db;

        public CourseService(MVCDBContext db)
        {
            this.db = db;
        }
        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }
        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }
        public int Add(Course newCourse)
        {
            db.Courses.Add(newCourse);
            return db.SaveChanges();
        }
        public int Update(int id, Course newCourse)
        {
            Course oldCourse = GetById(id);
            oldCourse.Degree = newCourse.Degree;
            oldCourse.Name = newCourse.Name;
            oldCourse.Mindegree = newCourse.Mindegree;
            oldCourse.DeptId = newCourse.DeptId;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            db.Courses.Remove(GetById(id));
            return db.SaveChanges();
        }
    }
}
