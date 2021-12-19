using frout_implementation.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Infrastructure.DAL
{
    public class FroutDbContext : DbContext
    {
        public FroutDbContext(DbContextOptions<FroutDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionDetail> SubscriptionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(table =>
            {
                // Similar to the table variable above, this allows us to get an address variable that we can use to map the complex
                // type's properties
                table.OwnsOne(
                    x => x.Location,
                    location =>
                    {
                        location.Property(x => x.Latitude).HasColumnName("Location_Latitude");
                        location.Property(x => x.Longitude).HasColumnName("Location_Longitude");
                    });
            });

            modelBuilder.Entity<Farmer>(table =>
            {
                // Similar to the table variable above, this allows us to get an address variable that we can use to map the complex
                // type's properties
                table.OwnsOne(
                    x => x.Location,
                    location =>
                    {
                        location.Property(x => x.Latitude).HasColumnName("Location_Latitude");
                        location.Property(x => x.Longitude).HasColumnName("Location_Longitude");
                    });
            });

            // n:m mappings     https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
            // subscription to offering
            modelBuilder.Entity<SubscriptionDetail>()
                .HasOne(u => u.Offering)
                .WithMany(u => u.SubscriptionDetails);
            //.OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubscriptionDetail>()
                .HasOne(a => a.Subscription)
                .WithMany(a => a.SubscriptionDetails);
                //.OnDelete(DeleteBehavior.Cascade);

        }

    }
}
