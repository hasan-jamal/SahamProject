using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class Status
    {
        public Status()
        {
            Shipments = new HashSet<Shipment>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
