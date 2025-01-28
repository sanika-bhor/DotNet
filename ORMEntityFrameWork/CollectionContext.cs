using Microsoft.EntityFrameworkCore;
namespace ORMEntityFramework
{
    public class CollectionContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public void onConfiguration(DbContextOptionsBuilder option)
        {
            string conn = "@server=localhost;user=root;password=root123;database=ecommerce";
            option.UseMySQL(conn);
        }

        public void onModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.Discription).IsRequired();
                entity.Property(p => p.Unitprice).IsRequired();
                entity.Property(p => p.Quantity);
            });
        }
    }
}