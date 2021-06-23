using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Core_CodeFirst.Models
{
    class DBContextClass : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=IMCABCP32-MSL1;Initial Catalog=CitusCFDb;Integrated Security=SSPI;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .HasOne(v => v.Vendor)
                 .WithMany(p => p.Products)
                 .HasForeignKey(p => p.VendorId);

            modelBuilder.Entity<Order>()
                .HasOne(c=>c.Customer)
                .WithMany(o=>o.Orders)
                .HasForeignKey(o => o.CustomerRowId);

            modelBuilder.Entity<Vendor>(entity => 
            {
                entity.HasIndex(c => c.VendorId).IsUnique();
                
             });
              

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(c => c.CustomerId).IsUnique();

            });

            /* modelBuilder.Entity<Vendor>()
                .Property(p => p.City)
                .HasComputedColumnSql("ALTER TABLE dbo.Vendors ADD City");

             modelBuilder.Entity<Vendor>()
                .Property(p => p.Email)
                .HasComputedColumnSql("ALTER TABLE dbo.Vendors ADD Email"); */

        }
    }
}
