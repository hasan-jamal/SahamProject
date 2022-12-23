using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Country { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? StreetName1 { get; set; }
        public string? StreetName2 { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ShortAddress { get; set; }
        public string? LocationMap { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
