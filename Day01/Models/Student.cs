using System.ComponentModel.DataAnnotations.Schema;

namespace Day01.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        [ForeignKey("Department")]
        public string Depet_Id { get; set; }

        public virtual Department Department { get; set; }

        
    }
}
