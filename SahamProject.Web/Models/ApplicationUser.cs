using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahamProject.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            MerchanShipments = new HashSet<Shipment>();
            CustomerShipments = new HashSet<Shipment>();
        }
        public bool IsActive { get; set; } = true;
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? Location { get; set; }
        public string? StoreNo { get; set; }
        public string? StreetName1 { get; set; }
        public string? StreetName2 { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ShortAddress { get; set; }
        public string? LocationMap { get; set; }
        [NotMapped]
        public virtual ICollection<Shipment> MerchanShipments { get; set; }
        public virtual ICollection<Shipment> CustomerShipments { get; set; }

    }
}
