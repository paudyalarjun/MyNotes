using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool Rememberme { get; set; }
    }
}
