using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SahamProject.Web.ViewModels
{
    public class RegisterCustomerVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "FullName is required")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "EmailAddress is required")]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not Match")]
        public string ConfirmPassword { get; set; } = null!;
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Area is required")]
        public string? Area { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        [Display(Name = "StoreNo")]
        [Required(ErrorMessage = "StoreNo is required")]
        public string? StoreNo { get; set; }
        [Display(Name = "StreetName1")]
        [Required(ErrorMessage = "StreetName1 is required")]
        public string? StreetName1 { get; set; }
        [Display(Name = "StreetName2")]
        [Required(ErrorMessage = "StreetName2 is required")]
        public string? StreetName2 { get; set; }
        [Display(Name = "BuildingNumber password")]
        [Required(ErrorMessage = "BuildingNumber is required")]
        public string? BuildingNumber { get; set; }
        [Display(Name = "ShortAddress")]
        [Required(ErrorMessage = "ShortAddress is required")]
        public string? ShortAddress { get; set; }
        [Display(Name = "LocationMap")]
        [Required(ErrorMessage = "LocationMap is required")]
        public string? LocationMap { get; set; }
    }
}
