using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain.Model;

namespace TG_SE101.Domain
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Waybill> Waybill { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<User>()
                .HasMany(o=>o.Orders)
                .WithOne(u=>u.Customer)
                .HasForeignKey(o=>o.CustomerId);
            modelBuilder.Entity<Waybill>()
                .HasOne(w => w.Order)
                .WithOne(o => o.Waybill)
                .HasForeignKey<Waybill>(w => w.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
