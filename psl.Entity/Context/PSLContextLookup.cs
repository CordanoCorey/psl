using Microsoft.EntityFrameworkCore;
using psl.Entity.DataClasses;

namespace psl.Entity.Context
{
    public partial class PSLContext
    {
        public virtual DbSet<AccountRole> AccountRole { get; set; }
        public void OnModelCreating_Lookup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.ToTable("AccountRole", "Lookup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                  new DataClasses.AccountRole { Id = 1, Name = "Admin", Sort = 1, IsActive = true },
                  new DataClasses.AccountRole { Id = 2, Name = "Member", Sort = 2, IsActive = true }
                );
            });
            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State", "Lookup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                  new DataClasses.State { Id = 1, Name = "PA", Label = "Pennsylvania", Sort = 1, IsActive = true },
                  new DataClasses.State { Id = 2, Name = "CA", Label = "California", Sort = 2, IsActive = true },
                  new DataClasses.State { Id = 3, Name = "MD", Label = "Maryland", Sort = 3, IsActive = true },
                  new DataClasses.State { Id = 4, Name = "NC", Label = "North Carolina", Sort = 4, IsActive = true },
                  new DataClasses.State { Id = 5, Name = "IL", Label = "Illinois", Sort = 5, IsActive = true },
                  new DataClasses.State { Id = 6, Name = "IA", Label = "Iowa", Sort = 6, IsActive = true }
                );
            });
        }
    }
}
