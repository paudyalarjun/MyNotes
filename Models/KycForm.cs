using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNotes.Models
{
    public class KycForm
    {
        public int ID { get; set; }
        [Display(Name = "Full Name:")]
        public string? FullName { get; set; }
        [Display(Name = "Phone Number:")]
        public long PhoneNumber { get; set; }
        [Display(Name = "State")]
        public string? PermaState { get; set; }
        [Display(Name = "District")]
        public string? PermaDistrict { get; set; }
        [Display(Name = "Municipality")]
        public string? PermaMunicipality { get; set; }
        [Display(Name = "Ward")]
        public int PermaWard { get; set; }
        [Display(Name = "Street")]
        public string? PermaStreet { get; set; }
        [Display(Name = "State")]
        public string? TempState { get; set; }
        [Display(Name = "District")]
        public string? TempDistrict { get; set; }
        [Display(Name = "Municipality")]
        public string? TempMunicipality { get; set; }
        [Display(Name = "Ward")]
        public int TempWard { get; set; }
        [Display(Name = "Street")]
        public string? TempStreet { get; set; }
        public string? ProfileImage { get; set;}
        [NotMapped]
        public IFormFile? ProfileImages { get; set; }


        public int StateId { get; set; }
        public int DistrictId { get; set; }

        [NotMapped]
        public string? PState { get; set; }
        [NotMapped]
        public string? PDistrict { get; set; }



    }
}

