using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahamProject.Web.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentsProducts = new HashSet<ShipmentsProduct>();
        }
        public int Id { get; set; }
        public double? Price { get; set; }
        public string? MerchanId { get; set; }
        public string OrderNumber { get; set; }
        public string? CustomerId { get; set; }
        public int StatusId { get; set; }
        public string ShipmentTypeId { get; set; } = string.Empty;
        public ApplicationUser? Customer { get; set; }
        public ApplicationUser? Merchan { get; set; }
        public Status? Status { get; set; }
        public virtual ICollection<ShipmentsProduct> ShipmentsProducts { get; set; }
    }
}
