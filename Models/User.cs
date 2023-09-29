using Microsoft.AspNetCore.Identity;

namespace MyNotes.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<Note>? Notes { get; set; }
    }
}
