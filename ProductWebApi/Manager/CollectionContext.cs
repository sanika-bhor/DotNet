using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductWebApi.Model;

namespace ProductWebApi.Manager
{
    public class CollectionContext:DbContext
    {
        public DbSet<Product> Product{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn= "server=localhost;port=3306;user=root;password=root123;database=ecommerce";
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(Options=>{
                Options.HasKey(product=>product.ProductId);
                Options.Property(product=>product.ProductName).IsRequired();
                Options.Property(product=>product.Discription).IsRequired();
                Options.Property(product=>product.UnitPrice).IsRequired();
                Options.Property(product=>product.Quantity).IsRequired();
            });
        }
    }
}