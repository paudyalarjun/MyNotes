using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Full Name:")]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Gender { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;




        public int StudentID { get; set; }
        public int LectureID { get; set; }
    }
}


