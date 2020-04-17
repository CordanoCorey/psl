using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace psl.Entity.Context
{
    public partial class PSLContext
    {
        public PSLContext(DbContextOptions<PSLContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.OnModelCreating_Identity(modelBuilder);
            this.OnModelCreating_Lookup(modelBuilder);
            this.OnModelCreating_Common(modelBuilder);
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PSLContext>
        {
            public PSLContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<PSLContext>();
                var connectionString = configuration.GetConnectionString("db");
                builder.UseSqlServer(connectionString);
                return new PSLContext(builder.Options);
            }
        }
    }
}
