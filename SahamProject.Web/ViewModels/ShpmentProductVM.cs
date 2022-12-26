using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SahamProject.Web.ViewModels
{
    public class ShpmentProductVM
    {
        public int? Id { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }
        [Display(Name = "Width")]
        [Required(ErrorMessage = "Width Is Required")]
        public string Width { get; set; }
        [Display(Name = "Length")]
        [Required(ErrorMessage = "Length Is Required")]
        public string Length { get; set; }
        [Display(Name = "Height")]
        [Required(ErrorMessage = "Height Is Required")]
        public string Height { get; set; }
        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Weight Is Required")]
        public string Weight { get; set; }
        [Display(Name = "IsBreakable")]
        [Required(ErrorMessage = "IsBreakable Is Required")]
        public bool? IsBreakable { get; set; }
        public IEnumerable<SelectListItem>? Shipments { get; set; }
        [Display(Name = "Shipment")]
        [Required(ErrorMessage = "Shipment Is Required")]
        public int ShipmentId { get; set; }

    }
}
