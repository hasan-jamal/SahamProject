using System;
using System.Collections.Generic;

namespace SahamProject.Web.Model
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentsProducts = new HashSet<ShipmentsProduct>();
        }

        public int Id { get; set; }
        public double? Price { get; set; }
        public int? MerchanId { get; set; }
        public int OrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? StatusId { get; set; }
        public string? ShipmentTypeId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Merchant? Merchan { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<ShipmentsProduct> ShipmentsProducts { get; set; }
    }
}
