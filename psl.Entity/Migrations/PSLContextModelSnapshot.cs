﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using psl.Entity.Context;

namespace psl.Entity.Migrations
{
    [DbContext(typeof(PSLContext))]
    partial class PSLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","Auth");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim","Auth");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProviderKey", "LoginProvider");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin","Auth");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole","Auth");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "Value", "LoginProvider");

                    b.ToTable("UserToken","Auth");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Account","Auth");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CSS"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PSL"
                        });
                });

            modelBuilder.Entity("psl.Entity.DataClasses.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccountRole","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Admin",
                            Sort = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Member",
                            Sort = 2
                        });
                });

            modelBuilder.Entity("psl.Entity.DataClasses.AccountUserXref", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("AccountRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AccountUser_xref","Auth");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role","Auth");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("PrimaryAccountId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PrimaryAccountId");

                    b.ToTable("User","Auth");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f605120f-716d-40c3-9dbd-8ff473410823",
                            Email = "gelbaughcm@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "System",
                            LastName = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "gelbaughcm@gmail.com",
                            NormalizedUserName = "gelbaughcm@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                            PhoneNumberConfirmed = false,
                            PrimaryAccountId = 1,
                            SecurityStamp = "dfafd561-8cef-40ad-8c7a-339dc67529d0",
                            TwoFactorEnabled = false,
                            UserName = "gelbaughcm@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                            Email = "corey@capitalsoftwaresolutions.io",
                            EmailConfirmed = false,
                            FirstName = "Tara",
                            LastName = "Long",
                            LockoutEnabled = false,
                            NormalizedEmail = "corey@capitalsoftwaresolutions.io",
                            NormalizedUserName = "corey@capitalsoftwaresolutions.io",
                            PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                            PhoneNumberConfirmed = false,
                            PrimaryAccountId = 2,
                            SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                            TwoFactorEnabled = false,
                            UserName = "corey@capitalsoftwaresolutions.io"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                            Email = "ben@capitalsoftwaresolutions.io",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Deere",
                            LockoutEnabled = false,
                            NormalizedEmail = "ben@capitalsoftwaresolutions.io",
                            NormalizedUserName = "ben@capitalsoftwaresolutions.io",
                            PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                            PhoneNumberConfirmed = false,
                            PrimaryAccountId = 2,
                            SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                            TwoFactorEnabled = false,
                            UserName = "ben@capitalsoftwaresolutions.io"
                        });
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbrevation")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Carrier","Common");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Dealer","Common");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.DealerLocationXref", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("LocationId");

                    b.ToTable("DealerLocation_xref","Common");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("StateId");

                    b.ToTable("Location","Common");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Carlisle",
                            CreatedById = 1,
                            CreatedDate = new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedById = 1,
                            LastModifiedDate = new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Carlisle PA",
                            StateId = 1
                        });
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Product","Common");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Routing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DestinationId");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("OriginId");

                    b.ToTable("Routing","Common");
                });

            modelBuilder.Entity("psl.Entity.DataClasses.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("State","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Label = "Pennsylvania",
                            Name = "PA",
                            Sort = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Label = "California",
                            Name = "CA",
                            Sort = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.AccountUserXref", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_AccountUser_xref_Account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.AccountRole", null)
                        .WithMany("AccountUsers")
                        .HasForeignKey("AccountRoleId");

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AccountUser_xref_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.ApplicationUser", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.Account", "PrimaryAccount")
                        .WithMany("PrimaryAccountUsers")
                        .HasForeignKey("PrimaryAccountId")
                        .HasConstraintName("FK_ApplicationUser_Account")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Carrier", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "CreatedBy")
                        .WithMany("CarrierCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Carrier_CreatedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "LastModifiedBy")
                        .WithMany("CarrierLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Carrier_LastModifiedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Dealer", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "CreatedBy")
                        .WithMany("DealerCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Dealer_CreatedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "LastModifiedBy")
                        .WithMany("DealerLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Dealer_LastModifiedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.DealerLocationXref", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.Dealer", "Dealer")
                        .WithMany("Locations")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("FK_DealerLocation_xref_Dealer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.Location", "Location")
                        .WithMany("Dealers")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_DealerLocation_xref_Location")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Location", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "CreatedBy")
                        .WithMany("LocationCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Location_CreatedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "LastModifiedBy")
                        .WithMany("LocationLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Location_LastModifiedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.State", "State")
                        .WithMany("Locations")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK_Location_State")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Product", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "CreatedBy")
                        .WithMany("ProductCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Product_CreatedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "LastModifiedBy")
                        .WithMany("ProductLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Product_LastModifiedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("psl.Entity.DataClasses.Routing", b =>
                {
                    b.HasOne("psl.Entity.DataClasses.Carrier", "Carrier")
                        .WithMany("Routings")
                        .HasForeignKey("CarrierId")
                        .HasConstraintName("FK_Routing_Carrier")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "CreatedBy")
                        .WithMany("RoutingCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Routing_CreatedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.Location", "Destination")
                        .WithMany("DestinationRoutings")
                        .HasForeignKey("DestinationId")
                        .HasConstraintName("FK_Routing_DestinationLocation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.ApplicationUser", "LastModifiedBy")
                        .WithMany("RoutingLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Routing_LastModifiedByUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("psl.Entity.DataClasses.Location", "Origin")
                        .WithMany("OriginRoutings")
                        .HasForeignKey("OriginId")
                        .HasConstraintName("FK_Routing_OriginLocation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}