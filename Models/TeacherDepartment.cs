using System.ComponentModel.DataAnnotations.Schema;

namespace MyNotes.Models
{
    public class TeacherDepartment
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int DepartmentID { get; set; }
        [NotMapped]
        public string? TeacherName { get; set; }
        [NotMapped]
        public string? DepartmentName { get; set; }



    }
}
