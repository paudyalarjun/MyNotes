namespace MyNotes.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public DateTime CreatedDate { get; set; } =DateTime.Now;

        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
