using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shipping.Models;
using Shipping.Repository;

namespace Shipping.Data
{
    public class ShippingContext:IdentityDbContext<ApplicationUser>
    {
        public ShippingContext(DbContextOptions<ShippingContext> options)
            :base(options)
        {
            
        }


        public DbSet<Representive> Representives { get; set; }
        public virtual DbSet<Governates> Governates { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                      .HasDiscriminator<string>("UserType")
                      .HasValue<Representive>("Representive");
        }

    }
}
