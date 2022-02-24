using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Day02.Models
{
    public partial class CourseResult
    {
        public int CrId { get; set; }
        public int CrDegree { get; set; }
        [ForeignKey("Crs")]
        public int CrsId { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }

        public virtual Course Crs { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
