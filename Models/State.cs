using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string? Name { get; set; }
        public int CountryId { get; set; }
    }
}
