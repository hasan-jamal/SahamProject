using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class ShipmentsProduct
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public bool? IsBreakable { get; set; }
        public int ShipmentId { get; set; }

        public virtual Shipment? Shipment { get; set; }
    }
}
