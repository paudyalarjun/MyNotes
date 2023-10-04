namespace MyNotes.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime CreatedDate { get; set; }



        public int LectureID { get; set; }
    }
}
