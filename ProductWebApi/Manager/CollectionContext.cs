using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductWebApi.Model;

namespace ProductWebApi.Manager
{
    public class CollectionContext:DbContext
    {
        public DbSet<Product> Product{get;set;}
        public DbSet<Payment> Payments{get;set;}

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
                Options.Property(product=>product.Title).IsRequired();
                Options.Property(product=>product.Description).IsRequired();
                Options.Property(product=>product.UnitPrice).IsRequired();
                Options.Property(product=>product.Quantity).IsRequired();
            });


            modelBuilder.Entity<Payment>(Options=>{
                Options.HasKey(payment=>payment.Id);
                Options.Property(Payment=>Payment.OrderId).IsRequired();
                Options.Property(Payment=>Payment.Amount).IsRequired();
                Options.Property(Payment=>Payment.PaymentDate).IsRequired();
                Options.Property(Payment=>Payment.PaymentMode).IsRequired();
            });
        }
    }
}