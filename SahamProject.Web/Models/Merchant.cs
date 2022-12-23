using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            Shipments = new HashSet<Shipment>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Location { get; set; }
        public string? StoreNo { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
