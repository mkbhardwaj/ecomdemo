using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        // for each entity add the db set
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductBrand> ProductBrands { set; get; }
        public DbSet<ProductType> ProductTypes { set; get; }

        // DbContextOptions from where we can pass the connection string
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        // override this to creat 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}