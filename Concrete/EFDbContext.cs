using System.Data.Entity;
using AoqibaoStore.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AoqibaoStore.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}