using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DGBar.Domain.Entities;

namespace DGBar.Infrastructure.Data.Context
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(p => new { p.OrderID, p.ProductID });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(p => p.OrderID);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(p => p.ProductID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
