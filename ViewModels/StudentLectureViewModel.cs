using MyNotes.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNotes.ViewModels
{
    public class StudentLectureViewModel : StudentLecture
    {
        [Required(ErrorMessage = "Please select a Student")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Please select a Lecture")]
        public int LectureID { get; set; }
    }
}
