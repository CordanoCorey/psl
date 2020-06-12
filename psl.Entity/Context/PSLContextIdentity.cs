using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using psl.Entity.DataClasses;
using System;

namespace psl.Entity.Context
{
    public partial class PSLContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public void OnModelCreating_Identity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("User", "Auth");

                e.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(e => e.LastName)
                    .HasMaxLength(100);

                e.Property(e => e.PasswordResetCode)
                    .HasMaxLength(100);

                e.HasOne(d => d.PrimaryAccount)
                    .WithMany(p => p.PrimaryAccountUsers)
                    .HasForeignKey(d => d.PrimaryAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ApplicationUser_Account");

                e.HasData(
                    new ApplicationUser
                    {
                        Id = 1,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "f605120f-716d-40c3-9dbd-8ff473410823",
                        Email = "corey@capitalsoftwaresolutions.io",
                        EmailConfirmed = false,
                        FirstName = "System",
                        LastName = "Administrator",
                        LockoutEnabled = false,
                        NormalizedEmail = "corey@capitalsoftwaresolutions.io",
                        NormalizedUserName = "corey@capitalsoftwaresolutions.io",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "dfafd561-8cef-40ad-8c7a-339dc67529d0",
                        UserName = "corey@capitalsoftwaresolutions.io",
                        PrimaryAccountId = 1
                    },
                    new ApplicationUser
                    {
                        Id = 2,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "ben@capitalsoftwaresolutions.io",
                        EmailConfirmed = false,
                        FirstName = "Test",
                        LastName = "User",
                        LockoutEnabled = false,
                        NormalizedEmail = "ben@capitalsoftwaresolutions.io",
                        NormalizedUserName = "ben@capitalsoftwaresolutions.io",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "ben@capitalsoftwaresolutions.io",
                        PrimaryAccountId = 2
                    },
                    new ApplicationUser
                    {
                        Id = 3,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "tara_long@plantsitelogistics.com",
                        EmailConfirmed = false,
                        FirstName = "Tara",
                        LastName = "Long",
                        LockoutEnabled = false,
                        NormalizedEmail = "tara_long@plantsitelogistics.com",
                        NormalizedUserName = "tara_long@plantsitelogistics.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "tara_long@plantsitelogistics.com",
                        PrimaryAccountId = 2
                    }
                  );
            });

            modelBuilder.Entity<ApplicationRole>(e =>
            {
                e.ToTable("Role", "Auth");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(e =>
            {
                e.ToTable("UserClaim", "Auth");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(e =>
            {
                e.ToTable("UserLogin", "Auth");
                e.HasKey(x => new { x.ProviderKey, x.LoginProvider });
            });
            modelBuilder.Entity<IdentityUserToken<int>>(e =>
            {
                e.ToTable("UserToken", "Auth");
                e.HasKey(x => new { x.UserId, x.Value, x.LoginProvider });
            });
            modelBuilder.Entity<IdentityUserRole<int>>(e =>
            {
                e.ToTable("UserRole", "Auth");
                e.HasKey(x => new { x.RoleId, x.UserId });
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(e =>
            {
                e.ToTable("RoleClaim", "Auth");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "Auth");

                entity.HasData(
                  new DataClasses.Account
                  {
                      Id = 1,
                      Name = "CSS"
                  },
                  new DataClasses.Account
                  {
                      Id = 2,
                      Name = "PSL"
                  }
                );
            });

            modelBuilder.Entity<AccountUserXref>(entity =>
            {
                entity.ToTable("AccountUser_xref", "Auth");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AccountUser_xref_Account");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AccountUser_xref_User");
            });
        }
    }
}
