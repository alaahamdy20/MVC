using System;
using System.Collections.Generic;

#nullable disable

namespace Day03.Models
{
    public partial class Trainee
    {
        public Trainee()
        {
            CrsResults = new HashSet<CrsResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int? Greade { get; set; }
        public int? DeptId { get; set; }

        public virtual ICollection<CrsResult> CrsResults { get; set; }
    }
}
