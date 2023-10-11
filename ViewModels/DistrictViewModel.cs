using Microsoft.AspNetCore.Builder;
using MyNotes.Models;

namespace MyNotes.ViewModels
{
    public class DistrictViewModel
    {
        public int DistrictId { get; set; }
        public string? Name { get; set; }

        public int StateId { get; set; }

    }
}
