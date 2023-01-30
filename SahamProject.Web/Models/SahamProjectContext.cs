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
            DbContextOptions<SahamProjectContext> options) : base(options) { }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentsProduct> ShipmentsProducts { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string ROLE_ID = "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59";
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string CUSTOMER_ID = "a18be9c0-aa65-4af8-bd17-00bd4354e575";
            const string ROLE_CUSTOMER_ID = "a5761da7-a17f-48fa-bcd3-aa25d7b75d15";
            builder.Entity<IdentityRole>().
               HasData(new IdentityRole
               {
                   Id = ROLE_ID,
                   Name = SD.Role_Admin,
                   NormalizedName = SD.Role_Admin_NormalizedName
               });

            builder.Entity<IdentityRole>().
                HasData(new IdentityRole
                {
                    Id = ROLE_CUSTOMER_ID,
                    Name = SD.Role_Customer,
                    NormalizedName = SD.Role_Customer_NormalizedName
                });
            builder.Entity<IdentityRole>().
                HasData(new IdentityRole
                {
                    Name = SD.Role_Merchant,
                    NormalizedName = SD.Role_Merchant_NormalizedName
                });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                Name = "Admin",
                UserName = "adminNew",
                NormalizedUserName = "adminNew",
                Email = "admin@saham.com",
                NormalizedEmail = "admin@saham.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123#"),
                SecurityStamp = string.Empty
            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = CUSTOMER_ID,
                Name = "Customer",
                UserName = "customer",
                NormalizedUserName = "customer",
                Email = "customer@saham.com",
                NormalizedEmail = "customer@saham.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Customer@123#"),
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_CUSTOMER_ID,
                    UserId = CUSTOMER_ID
                });

            builder.Entity<Shipment>().
                HasOne(x => x.Merchan)
                .WithMany(x => x.MerchanShipments)
                .HasForeignKey(x => x.MerchanId);

            builder.Entity<Shipment>().
                HasOne(x => x.Customer)
                .WithMany(x => x.CustomerShipments)
                .HasForeignKey(x => x.CustomerId);

            builder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<Status>().HasData(new Status { Id = 1, Name = "Begin" });
            builder.Entity<Status>().HasData(new Status { Id = 2, Name = "InPrgoress" });
            builder.Entity<Status>().HasData(new Status { Id = 3, Name = "Done" });

        }


    }
    }

