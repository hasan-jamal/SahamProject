using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SahamProject.Web.Utlity;

namespace SahamProject.Web.Models
{
    public partial class SahamProjectContext : IdentityDbContext<ApplicationUser>
    {
        public SahamProjectContext()
        {
        }

        public SahamProjectContext(
            DbContextOptions<SahamProjectContext> options
                                  ) : base(options) { }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentsProduct> ShipmentsProducts { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().
                HasData(new IdentityRole 
                { Name= SD.Role_Admin, 
                    NormalizedName = SD.Role_Admin_NormalizedName});
            
            builder.Entity<IdentityRole>().
                HasData(new IdentityRole 
                { Name= SD.Role_Merchant,
                    NormalizedName = SD.Role_Merchant_NormalizedName });
            
            builder.Entity<IdentityRole>().
                HasData(new IdentityRole 
                { Name= SD.Role_Customer, 
                    NormalizedName = SD.Role_Customer_NormalizedName });

            builder.Entity<Shipment>().
                HasOne(x => x.Merchan)
                .WithMany(x=> x.MerchanShipments)
                .HasForeignKey(x=> x.MerchanId);

            builder.Entity<Shipment>().
                HasOne(x => x.Customer)
                .WithMany(x => x.CustomerShipments)
                .HasForeignKey(x => x.CustomerId);

            base.OnModelCreating(builder);
        }
    }
}
