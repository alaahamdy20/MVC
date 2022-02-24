using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Day02.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Instractors = new HashSet<Instractor>();
            Trainees = new HashSet<Trainee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manger { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instractor> Instractors { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
