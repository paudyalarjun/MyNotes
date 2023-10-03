using MyNotes.Models;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class TeacherDepartmentViewModel : TeacherDepartment
    {
        [Required(ErrorMessage = "Please select a teacher")]
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        public int DepartmentID { get; set; }
    }
}
