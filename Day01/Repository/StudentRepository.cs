using Day01.Models;
using System.Collections.Generic;
using System.Linq;

namespace Day01.Repository
{
    public class StudentRepository
    {
        static List<Student> Students = new List<Student>()
        {
            new Student(){
                Id = 101,
                Name = "Alaa Hamdy",
                Address = "Belibes",
                Image = "https://images.unsplash.com/photo-1644424236613-d7964a3c21ea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5N3x8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=60"
            },
            new Student(){
                Id = 102,
                Name = "Mona Ali",
                Address = "Cairo",
                Image = "https://images.unsplash.com/photo-1644440908814-c6d06260ee11?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyNTN8fHxlbnwwfHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60"
            },
            new Student(){
                Id = 103,
                Name = "Ahmed Abdo",
                Address = "Alex",
                Image = "https://images.unsplash.com/photo-1644520964117-b01a0f70adcd?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxNTd8fHxlbnwwfHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60"
            },
            new Student(){
                Id = 104,
                Name = "Moasta Fathy",
                Address = "Port Said",
                Image = "https://images.unsplash.com/photo-1553272725-086100aecf5e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwxMzR8fHxlbnwwfHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60"
            }
        };



        public static List<Student> GetAllStudents()
        {
            return Students;
        }
        public static Student GetStudentById( int id)
        {
            return Students.SingleOrDefault(s => s.Id == id);
        }
    }
}
