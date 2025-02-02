using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using paymentProcessingDemo.Models;

namespace paymentProcessingDemo.Manager
{
    public class CollectionContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString="server=localhost; user=root; password=root123; database=Ecommerce";
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Payment>(Options=>{
                Options.HasKey(p => p.Id);
                Options.Property(p=>p.OrderId);
                Options.Property(p=>p.Amount);
                Options.Property(p=>p.PaymentDate);
                Options.Property(p=>p.PaymentMode);
            });
        }
    }
}