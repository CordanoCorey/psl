﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace psl.Entity.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountRole",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Label = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PrimaryAccountId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Account",
                        column: x => x.PrimaryAccountId,
                        principalSchema: "Auth",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser_xref",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AccountRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser_xref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUser_xref_Account",
                        column: x => x.AccountId,
                        principalSchema: "Auth",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountUser_xref_AccountRole_AccountRoleId",
                        column: x => x.AccountRoleId,
                        principalSchema: "Lookup",
                        principalTable: "AccountRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUser_xref_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Auth",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.ProviderKey, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Auth",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Auth",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.Value, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrier",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Abbrevation = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrier_CreatedByUser",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carrier_LastModifiedByUser",
                        column: x => x.LastModifiedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealer_CreatedByUser",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dealer_LastModifiedByUser",
                        column: x => x.LastModifiedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_CreatedByUser",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_LastModifiedByUser",
                        column: x => x.LastModifiedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_State",
                        column: x => x.StateId,
                        principalSchema: "Lookup",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_CreatedByUser",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_LastModifiedByUser",
                        column: x => x.LastModifiedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CreatedByUser",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_LastModifiedByUser",
                        column: x => x.LastModifiedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    JustifyX = table.Column<string>(maxLength: 20, nullable: true),
                    JustifyY = table.Column<string>(maxLength: 20, nullable: true),
                    OffsetX = table.Column<double>(nullable: true),
                    OffsetY = table.Column<double>(nullable: true),
                    Height = table.Column<double>(nullable: true),
                    Width = table.Column<double>(nullable: true),
                    ZIndex = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealerLocation_xref",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerLocation_xref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerLocation_xref_Dealer",
                        column: x => x.DealerId,
                        principalSchema: "Common",
                        principalTable: "Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealerLocation_xref_Location",
                        column: x => x.LocationId,
                        principalSchema: "Common",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routing",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<int>(nullable: false),
                    OriginId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routing_Carrier",
                        column: x => x.CarrierId,
                        principalSchema: "Common",
                        principalTable: "Carrier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routing_CreatedByUser",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routing_DestinationLocation",
                        column: x => x.DestinationId,
                        principalSchema: "Common",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routing_LastModifiedByUser",
                        column: x => x.LastModifiedById,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routing_OriginLocation",
                        column: x => x.OriginId,
                        principalSchema: "Common",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct_xref",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderProductXrefId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct_xref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_xref_Order",
                        column: x => x.OrderId,
                        principalSchema: "Common",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_xref_OrderProduct_xref_OrderProductXrefId",
                        column: x => x.OrderProductXrefId,
                        principalSchema: "Common",
                        principalTable: "OrderProduct_xref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProduct_xref_Product",
                        column: x => x.ProductId,
                        principalSchema: "Common",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Account",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CSS" },
                    { 2, "PSL" }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "AccountRole",
                columns: new[] { "Id", "IsActive", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, true, "Admin", 1 },
                    { 2, true, "Member", 2 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "State",
                columns: new[] { "Id", "IsActive", "Label", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, true, "Pennsylvania", "PA", 1 },
                    { 2, true, "California", "CA", 2 },
                    { 3, true, "Maryland", "MD", 3 },
                    { 4, true, "North Carolina", "NC", 4 },
                    { 5, true, "Illinois", "IL", 5 },
                    { 6, true, "Iowa", "IA", 6 }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "PrimaryAccountId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "f605120f-716d-40c3-9dbd-8ff473410823", "corey@capitalsoftwaresolutions.io", false, "System", "Administrator", false, null, "corey@capitalsoftwaresolutions.io", "corey@capitalsoftwaresolutions.io", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, 1, "dfafd561-8cef-40ad-8c7a-339dc67529d0", false, "corey@capitalsoftwaresolutions.io" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "PrimaryAccountId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "ben@capitalsoftwaresolutions.io", false, "Test", "User", false, null, "ben@capitalsoftwaresolutions.io", "ben@capitalsoftwaresolutions.io", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, 2, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "ben@capitalsoftwaresolutions.io" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "PrimaryAccountId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "tara_long@plantsitelogistics.com", false, "Tara", "Long", false, null, "tara_long@plantsitelogistics.com", "tara_long@plantsitelogistics.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, 2, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "tara_long@plantsitelogistics.com" });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Carrier",
                columns: new[] { "Id", "Abbrevation", "CreatedById", "CreatedDate", "LastModifiedById", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Diamond", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diamond" },
                    { 2, "Warren", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warren" },
                    { 3, "ATS", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATS" }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Dealer",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "LastModifiedById", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deer Country Farm and Lawn, Inc." },
                    { 2, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shoppa's Farm Supply, Inc." },
                    { 3, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Campbell Tractor & Implement" }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Location",
                columns: new[] { "Id", "City", "CreatedById", "CreatedDate", "LastModifiedById", "LastModifiedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 14, "Allentown", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deer Country Farm and Lawn, Inc. Allentown Location", 1 },
                    { 13, "Lebanon", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deer Country Farm and Lawn, Inc. Lebanon Location", 1 },
                    { 12, "Adamstown", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deer Country Farm and Lawn, Inc. Adamstown Location", 1 },
                    { 11, "Lancaster", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deer Country Farm and Lawn, Inc. Lancaster Location", 1 },
                    { 10, "Moline", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deere & Company World Headquarters", 5 },
                    { 8, "Bettendorf", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bettendorf, IA", 6 },
                    { 9, "Davenport", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davenport, IA", 6 },
                    { 6, "Ottumwa", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ottumwa, IA", 6 },
                    { 5, "Waterloo", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waterloo, IA", 6 },
                    { 4, "Dubuque", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubuque, IA", 6 },
                    { 3, "Kernersville", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kernersville, NC", 4 },
                    { 2, "Dundalk", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baltimore, MD", 3 },
                    { 1, "Carlisle", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlisle, PA Main Office", 1 },
                    { 7, "E. Moline", 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harvester, IA", 5 }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Product",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "LastModifiedById", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 12, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "5090EL" },
                    { 19, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "4WD 80 Inch" },
                    { 18, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Row Crop 8 Series" },
                    { 17, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Row Crop 7 Series" },
                    { 16, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Row Crop 6 Series" },
                    { 15, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "5125ML" },
                    { 14, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "5115ML" },
                    { 13, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "5100ML" },
                    { 11, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "5075GL" },
                    { 1, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact 1 Series" },
                    { 9, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility 6M Series" },
                    { 8, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility 6E Series" },
                    { 7, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility 5R Series" },
                    { 6, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility 5M Series" },
                    { 5, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility 5E Series" },
                    { 4, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact 4 Series" },
                    { 3, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact 3 Series" },
                    { 2, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact 2 Series" },
                    { 20, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "4WD 88 Inch" },
                    { 10, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility 6R Series" },
                    { 21, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "4WD 120 Inch" }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "DealerLocation_xref",
                columns: new[] { "Id", "DealerId", "LocationId" },
                values: new object[,]
                {
                    { 1, 1, 11 },
                    { 2, 1, 12 },
                    { 3, 1, 13 },
                    { 4, 1, 14 }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Routing",
                columns: new[] { "Id", "CarrierId", "CreatedById", "CreatedDate", "DestinationId", "EndTime", "LastModifiedById", "LastModifiedDate", "OriginId", "StartTime" },
                values: new object[,]
                {
                    { 2, 2, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 6, 13, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 6, 13, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 1, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 6, 13, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_xref_AccountId",
                schema: "Auth",
                table: "AccountUser_xref",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_xref_AccountRoleId",
                schema: "Auth",
                table: "AccountUser_xref",
                column: "AccountRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_xref_UserId",
                schema: "Auth",
                table: "AccountUser_xref",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Auth",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "Auth",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Auth",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Auth",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_PrimaryAccountId",
                schema: "Auth",
                table: "User",
                column: "PrimaryAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "Auth",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "Auth",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "Auth",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrier_CreatedById",
                schema: "Common",
                table: "Carrier",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Carrier_LastModifiedById",
                schema: "Common",
                table: "Carrier",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dealer_CreatedById",
                schema: "Common",
                table: "Dealer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dealer_LastModifiedById",
                schema: "Common",
                table: "Dealer",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DealerLocation_xref_DealerId",
                schema: "Common",
                table: "DealerLocation_xref",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerLocation_xref_LocationId",
                schema: "Common",
                table: "DealerLocation_xref",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreatedById",
                schema: "Common",
                table: "Location",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LastModifiedById",
                schema: "Common",
                table: "Location",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Location_StateId",
                schema: "Common",
                table: "Location",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedById",
                schema: "Common",
                table: "Order",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LastModifiedById",
                schema: "Common",
                table: "Order",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_xref_OrderId",
                schema: "Common",
                table: "OrderProduct_xref",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_xref_OrderProductXrefId",
                schema: "Common",
                table: "OrderProduct_xref",
                column: "OrderProductXrefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_xref_ProductId",
                schema: "Common",
                table: "OrderProduct_xref",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedById",
                schema: "Common",
                table: "Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LastModifiedById",
                schema: "Common",
                table: "Product",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routing_CarrierId",
                schema: "Common",
                table: "Routing",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Routing_CreatedById",
                schema: "Common",
                table: "Routing",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routing_DestinationId",
                schema: "Common",
                table: "Routing",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routing_LastModifiedById",
                schema: "Common",
                table: "Routing",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routing_OriginId",
                schema: "Common",
                table: "Routing",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_UserId",
                schema: "Common",
                table: "Widget",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUser_xref",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "DealerLocation_xref",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "OrderProduct_xref",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Routing",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Widget",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "AccountRole",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Dealer",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Carrier",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "Auth");
        }
    }
}
