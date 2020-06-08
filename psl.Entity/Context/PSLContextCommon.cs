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
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProductXref> OrderProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Routing> Routing { get; set; }
        public virtual DbSet<Widget> Widget { get; set; }

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

                entity.HasData(
                  new DataClasses.Carrier
                  {
                      Id = 1,
                      Name = "Diamond",
                      Abbrevation = "Diamond",
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Carrier
                  {
                      Id = 2,
                      Name = "Warren",
                      Abbrevation = "Warren",
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Carrier
                  {
                      Id = 3,
                      Name = "ATS",
                      Abbrevation = "ATS",
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  }
                );
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

                entity.HasData(
                  new DataClasses.Dealer
                  {
                      Id = 1,
                      Name = "Deer Country Farm and Lawn, Inc.",
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Dealer
                  {
                      Id = 2,
                      Name = "Shoppa's Farm Supply, Inc.",
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Dealer
                  {
                      Id = 3,
                      Name = "Campbell Tractor & Implement",
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  }
                );
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

                entity.HasData(
                  new DataClasses.DealerLocationXref
                  {
                      Id = 1,
                      DealerId = 1,
                      LocationId = 11
                  },
                  new DataClasses.DealerLocationXref
                  {
                      Id = 2,
                      DealerId = 1,
                      LocationId = 12
                  },
                  new DataClasses.DealerLocationXref
                  {
                      Id = 3,
                      DealerId = 1,
                      LocationId = 13
                  },
                  new DataClasses.DealerLocationXref
                  {
                      Id = 4,
                      DealerId = 1,
                      LocationId = 14
                  }
                );
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
                  new DataClasses.Location
                  {
                      Id = 1,
                      Name = "Carlisle, PA Main Office",
                      City = "Carlisle",
                      StateId = 1,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 2,
                      Name = "Baltimore, MD",
                      City = "Dundalk",
                      StateId = 3,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 3,
                      Name = "Kernersville, NC",
                      City = "Kernersville",
                      StateId = 4,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 4,
                      Name = "Dubuque, IA",
                      City = "Dubuque",
                      StateId = 6,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 5,
                      Name = "Waterloo, IA",
                      City = "Waterloo",
                      StateId = 6,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 6,
                      Name = "Ottumwa, IA",
                      City = "Ottumwa",
                      StateId = 6,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 7,
                      Name = "Harvester, IA",
                      City = "E. Moline",
                      StateId = 5,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 8,
                      Name = "Bettendorf, IA",
                      City = "Bettendorf",
                      StateId = 6,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 9,
                      Name = "Davenport, IA",
                      City = "Davenport",
                      StateId = 6,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 10,
                      Name = "Deere & Company World Headquarters",
                      City = "Moline",
                      StateId = 5,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 11,
                      Name = "Deer Country Farm and Lawn, Inc. Lancaster Location",
                      City = "Lancaster",
                      StateId = 1,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 12,
                      Name = "Deer Country Farm and Lawn, Inc. Adamstown Location",
                      City = "Adamstown",
                      StateId = 1,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 13,
                      Name = "Deer Country Farm and Lawn, Inc. Lebanon Location",
                      City = "Lebanon",
                      StateId = 1,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  },
                  new DataClasses.Location
                  {
                      Id = 14,
                      Name = "Deer Country Farm and Lawn, Inc. Allentown Location",
                      City = "Allentown",
                      StateId = 1,
                      CreatedById = 1,
                      CreatedDate = new DateTime(2020, 4, 16),
                      LastModifiedById = 1,
                      LastModifiedDate = new DateTime(2020, 4, 16)
                  }
                );
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "Common");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.OrderCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_CreatedByUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.OrderLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_LastModifiedByUser");
            });

            modelBuilder.Entity<OrderProductXref>(entity =>
            {
                entity.ToTable("OrderProduct_xref", "Common");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderProduct_xref_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderProduct_xref_Product");
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

                entity.HasData(
                   new DataClasses.Product
                   {
                       Id = 1,
                       Name = "Compact 1 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 2,
                       Name = "Compact 2 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 3,
                       Name = "Compact 3 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 4,
                       Name = "Compact 4 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 5,
                       Name = "Utility 5E Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 6,
                       Name = "Utility 5M Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 7,
                       Name = "Utility 5R Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 8,
                       Name = "Utility 6E Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 9,
                       Name = "Utility 6M Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 10,
                       Name = "Utility 6R Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 11,
                       Name = "5075GL",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 12,
                       Name = "5090EL",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 13,
                       Name = "5100ML",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 14,
                       Name = "5115ML",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 15,
                       Name = "5125ML",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 16,
                       Name = "Row Crop 6 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 17,
                       Name = "Row Crop 7 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 18,
                       Name = "Row Crop 8 Series",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 19,
                       Name = "4WD 80 Inch",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 20,
                       Name = "4WD 88 Inch",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   },
                   new DataClasses.Product
                   {
                       Id = 21,
                       Name = "4WD 120 Inch",
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   }
                );
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

                entity.HasData(
                   new DataClasses.Routing
                   {
                       Id = 1,
                       CarrierId = 1,
                       OriginId = 1,
                       DestinationId = 2,
                       CreatedById = 1,
                       CreatedDate = new DateTime(2020, 4, 16),
                       LastModifiedById = 1,
                       LastModifiedDate = new DateTime(2020, 4, 16)
                   }
                );
            });

            modelBuilder.Entity<Widget>(entity =>
            {
                entity.ToTable("Widget", "Common");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.JustifyX)
                    .HasMaxLength(20);

                entity.Property(e => e.JustifyY)
                    .HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Widgets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Widget_User");
            });
        }
    }
}
