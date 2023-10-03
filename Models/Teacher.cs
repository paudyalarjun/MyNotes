using System.Reflection;

namespace MyNotes.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }

        



        public int DepartmentId { get; set; }
        //public Department? Department { get; set; }

    }
}
