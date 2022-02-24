using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Day02.Models
{
    public class UniqueAttribute: ValidationAttribute
    {
        MVCDBContext db = new MVCDBContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var newCourse = (Course)validationContext.ObjectInstance;

            Course course = db.Courses.FirstOrDefault(c => c.Id == newCourse.Id);
            if (course == null)
            {
                return ValidationResult.Success;

            }
            return new ValidationResult("Course Is Alerday Exisit");
        }
    }
}
