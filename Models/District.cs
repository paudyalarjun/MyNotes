using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string? Name { get; set; }
        public int StateId { get; set; } 
    }
}
