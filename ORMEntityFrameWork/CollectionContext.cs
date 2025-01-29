using Microsoft.EntityFrameworkCore;
namespace ORMEntityFramework
{
    public class CollectionContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            string conn = "server=localhost;port=3306;user=root;password=root123;database=ecommerce";
            option.UseMySql(conn,ServerVersion.AutoDetect(conn));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.Unitprice).IsRequired();
                entity.Property(p => p.Quantity).IsRequired();
            });
        }
    }
}