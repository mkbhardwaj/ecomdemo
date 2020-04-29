using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        // for each entity add the db set
        public DbSet<Product> Products { set; get; }

        // DbContextOptions from where we can pass the connection string
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}