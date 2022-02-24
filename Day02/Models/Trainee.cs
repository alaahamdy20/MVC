using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Day02.Models
{
    public partial class Trainee
    {
        public Trainee()
        {
            CourseResults = new HashSet<CourseResult>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Img { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Grade { get; set; }
        [ForeignKey("Dept")]
        public int? DeptId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual ICollection<CourseResult> CourseResults { get; set; }
    }
}
