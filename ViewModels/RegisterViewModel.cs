using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name= "First Name")]
        public string? Firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? Lastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string? Confirmpassword { get; set; }
        
    }
}
