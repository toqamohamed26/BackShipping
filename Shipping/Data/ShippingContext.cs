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
        
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Order> Employee_Orders { get; set; }
       
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
       
        public virtual DbSet<Setting_shipping> Setting_shippings { get; set; }
        public virtual DbSet<Setting_Weight> Setting_Weights { get; set; }
        public virtual DbSet<Special_Price_Trader> Special_Price_Traders { get; set; }
        public virtual DbSet<Trader> Traders { get; set; }

        public virtual DbSet<VillageShipping> VillageShippings { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                      .HasDiscriminator<string>("UserType")
                      .HasValue<Representive>("Representive")
                      .HasValue<Employee>("Employee");
                      
        }

    }
}
