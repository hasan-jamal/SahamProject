using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SahamProject.Web.Model
{
    public partial class SahamProjectContext : DbContext
    {
        public SahamProjectContext()
        {
        }

        public SahamProjectContext(DbContextOptions<SahamProjectContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Merchant> Merchants { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentsProduct> ShipmentsProducts { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=SahamProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Message).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.BuildingNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.LocationMap).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.ShortAddress).HasMaxLength(50);

                entity.Property(e => e.StreetName1).HasMaxLength(50);

                entity.Property(e => e.StreetName2).HasMaxLength(50);
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.StoreNo).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OrderNumber).ValueGeneratedOnAdd();

                entity.Property(e => e.ShipmentTypeId).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Shipment_Customers");

                entity.HasOne(d => d.Merchan)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.MerchanId)
                    .HasConstraintName("FK_Shipment_Merchants");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Shipment_Statuses");
            });

            modelBuilder.Entity<ShipmentsProduct>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Height).HasMaxLength(50);

                entity.Property(e => e.Length).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(50);

                entity.Property(e => e.Width).HasMaxLength(50);

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentsProducts)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK_ShipmentsProducts_Shipment");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
