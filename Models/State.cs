using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Models
{
    public class State
    {
        public int ID { get; set; }
        public string? Sname { get; set; }
    }
}
