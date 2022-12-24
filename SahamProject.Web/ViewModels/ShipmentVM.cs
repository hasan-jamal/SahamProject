using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.Models;

namespace SahamProject.Web.ViewModels
{
    public class ShipmentVM
    {
        public Shipment Shipment { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public string? CustomersId { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public int StatusId { get; set; }
    }
}
