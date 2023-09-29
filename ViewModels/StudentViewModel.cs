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
        public char Gender { get; set; }
        [Required]
        public string? Degree { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}


