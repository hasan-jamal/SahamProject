using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.Models;

namespace SahamProject.Web.ViewModels
{
    public class ShpmentProductVM
    {
        public ShipmentsProduct ShipmentsProducts { get; set; }
        public IEnumerable<SelectListItem> Shipments { get; set; }
        public int ShipmentId { get; set; }

    }
}
