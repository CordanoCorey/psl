using Microsoft.EntityFrameworkCore;
using psl.Entity.DataClasses;
using System;

namespace psl.Entity.Context
{
    public partial class PSLContext
    {
        public virtual DbSet<Carrier> Carrier { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<DealerLocationXref> DealerLocation { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Routing> Routing { get; set; }

        public void OnModelCreating_Common(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.ToTable("Carrier", "Common");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Abbrevation)
                    .HasMaxLength(20);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CarrierCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Carrier_CreatedByUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.CarrierLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Carrier_LastModifiedByUser");
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.ToTable("Dealer", "Common");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.DealerCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Dealer_CreatedByUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.DealerLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Dealer_LastModifiedByUser");
            });

            modelBuilder.Entity<DealerLocationXref>(entity =>
            {
                entity.ToTable("DealerLocation_xref", "Common");

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.DealerId)
                    .HasConstraintName("FK_DealerLocation_xref_Dealer");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Dealers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_DealerLocation_xref_Location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Common");

                entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .HasMaxLength(100);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Location_State");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.LocationCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Location_CreatedByUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.LocationLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Location_LastModifiedByUser");

                entity.HasData(
                  new DataClasses.Location { 
                      Id = 1, 
                      Name = "Carlisle PA", 
                      City = "Carlisle", 
                      StateId = 1,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  }
                );
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Common");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProductCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_CreatedByUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProductLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_LastModifiedByUser");
            });

            modelBuilder.Entity<Routing>(entity =>
            {
                entity.ToTable("Routing", "Common");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Routings)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Routing_Carrier");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.DestinationRoutings)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Routing_DestinationLocation");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.OriginRoutings)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Routing_OriginLocation");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.RoutingCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Routing_CreatedByUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.RoutingLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Routing_LastModifiedByUser");
            });
        }
    }
}
