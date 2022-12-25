using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class ShipmentsProduct
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Width { get; set; }
        public string? Length { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public bool? IsBreakable { get; set; }
        public int ShipmentId { get; set; }

        public virtual Shipment? Shipment { get; set; }
    }
}
