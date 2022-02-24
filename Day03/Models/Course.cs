using System;
using System.Collections.Generic;

#nullable disable

namespace Day03.Models
{
    public partial class Course
    {
        public Course()
        {
            CrsResults = new HashSet<CrsResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int Mindegree { get; set; }
        public int? DeptId { get; set; }

        public virtual ICollection<CrsResult> CrsResults { get; set; }
    }
}
