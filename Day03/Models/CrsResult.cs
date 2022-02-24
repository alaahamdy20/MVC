using System;
using System.Collections.Generic;

#nullable disable

namespace Day03.Models
{
    public partial class CrsResult
    {
        public int CrsId { get; set; }
        public int TraineeId { get; set; }
        public int Degree { get; set; }

        public virtual Course Crs { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
