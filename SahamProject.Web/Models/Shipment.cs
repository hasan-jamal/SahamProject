using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentsProducts = new HashSet<ShipmentsProduct>();
        }

        public string Id { get; set; } = null!;
        public double? Price { get; set; }
        public string? MerchanId { get; set; }
        public string? OrderNumber { get; set; }
        public string? CustomerId { get; set; }
        public string? StatusId { get; set; }
        public string? ShipmentTypeId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Merchant? Merchan { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<ShipmentsProduct> ShipmentsProducts { get; set; }
    }
}
