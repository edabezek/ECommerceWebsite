using ECommerceEntities;
using ECommerceEntities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDataAccess
{
    public class EComerceDBAccess :IdentityDbContext<User,UserRole,int>
    {
        public EComerceDBAccess(DbContextOptions<EComerceDBAccess> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //public DbSet<User> Users { get; set; }//Identity user'ı barındıracak sil
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }        
        public DbSet<CargoInformation> CargoInformations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<District> Districts { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }//Identity role u barındıracak
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        
    }
}
