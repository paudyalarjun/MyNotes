using System.ComponentModel.DataAnnotations.Schema;

namespace MyNotes.Models
{
    public class StudentLecture
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int LectureID { get; set; }
        [NotMapped]
        public string? StudentName { get; set; }
        [NotMapped]
        public string? LectureName { get; set; }

    }
}
