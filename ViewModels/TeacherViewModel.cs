using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class TeacherViewModel
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Gender { get; set; }

        public int TeacherID { get; set; }
        public int DepartmentID { get; set; }



        //public int DepartmentId {get; set; }
        //public SelectList Departments { get; set; }
    }
}
