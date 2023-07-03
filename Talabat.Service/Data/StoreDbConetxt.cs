using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository.Entites;

namespace Talabat.Service.Data
{
    public class StoreDbConetxt : DbContext
    {
        public StoreDbConetxt(DbContextOptions<StoreDbConetxt> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; } 
        public DbSet<ProductType> ProductType { get; set; }

        

        /*       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
               {
                   base.OnConfiguring(optionsBuilder);
               }*/
    }
}
