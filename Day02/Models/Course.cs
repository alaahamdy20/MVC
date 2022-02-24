using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Day02.Models
{
    public partial class Course 
    {
        public Course()
        {
            CourseResults = new HashSet<CourseResult>();
            Instractors = new HashSet<Instractor>();
        }
        [Key]
        public int Id { get; set; }
        [Required, StringLength(10, MinimumLength = 2)]
        [Remote("IsNameAvailble", "Course", ErrorMessage = "Course Is Alreday  Exist.")]
        public string Name { get; set; }
        [Range(50, 100)]
        public int Degree { get; set; }
        [Remote("IsGrater", "Course", ErrorMessage = "Mindegree Is Grater  Degree.", AdditionalFields = "Degree")]
        public int Mindegree { get; set; }
        [ForeignKey("Dept")]
        public int DeptId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual ICollection<CourseResult> CourseResults { get; set; }
        public virtual ICollection<Instractor> Instractors { get; set; }
    }
}
