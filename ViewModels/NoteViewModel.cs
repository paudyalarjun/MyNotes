using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class NoteViewModel
    {
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Color { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? UserId { get; set; }
    }
}
