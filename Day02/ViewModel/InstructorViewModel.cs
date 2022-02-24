using Microsoft.AspNetCore.Http;

namespace Day02.ViewModel
{
    public class InstructorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Salary { get; set; }
        public string Imag { get; set; }
        public string Adress { get; set; }
        public int? DId { get; set; }
        public int? CId { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
