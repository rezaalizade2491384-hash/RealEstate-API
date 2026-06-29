using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Api.Data.Entities;

namespace RealEstate.Api.Data
{
    public class RealEstateDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(p => p.Price)
                    .HasPrecision(18, 2);

                entity.Property(p => p.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}