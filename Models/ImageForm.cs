using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNotes.Models
{
    public class ImageForm
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ImageFile { get; set; }
        [NotMapped]
        public IFormFile ImageIFile { get; set; }
    }
}
