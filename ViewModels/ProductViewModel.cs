using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product Name:")]
        public string? ProductName { get; set; }
        [Required]
        [Display(Name = "Product Code:")]
        public int ProductCode { get; set; }
        [Required]
        [Display(Name = "Unit of Products:")]
        public int Unit { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
    }
}
