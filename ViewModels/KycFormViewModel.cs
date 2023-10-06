using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class KycFormViewModel
    {
        
        public int ID { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set; }
        [Required]
        [Display(Name = "State")]
        public string? PermaState { get; set; }
        [Required]
        [Display(Name = "District")]
        public string? PermaDistrict { get; set; }
        [Required]
        [Display(Name = "Municipality")]
        public string? PermaMunicipality { get; set; }
        [Required]
        [Display(Name = "Ward No.")]
        public int PermaWard { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string? PermaStreet { get; set; }
        [Display(Name = "State")]
        public string? TempState { get; set; }
        [Display(Name = "District")]
        public string? TempDistrict { get; set; }
        [Display(Name = "Municipality")]
        public string? TempMunicipality { get; set; }
        [Display(Name = "Ward No.")]
        public int TempWard { get; set; }
        [Display(Name = "Street")]
        public string? TempStreet { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
