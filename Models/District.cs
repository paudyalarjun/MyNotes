using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Models
{
    public class District
    {
        public int ID { get; set; }
        public string? Dname { get; set; }
        public int StateId { get; set; } 
    }
}
