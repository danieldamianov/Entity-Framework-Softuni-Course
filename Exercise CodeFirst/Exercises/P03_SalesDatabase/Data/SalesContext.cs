using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B3I8JPR\\SQLEXPRESS;Database=SalesDb;Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCustomer(modelBuilder);
            ConfigureProduct(modelBuilder);
            ConfigureSale(modelBuilder);
            ConfigureStore(modelBuilder);
        }

        private void ConfigureStore(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode();
        }

        private void ConfigureSale(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");/////////////////////////////////////////////////////////////////////////////////////////

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Store)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.StoreId);
        }

        private void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(s => s.ProductId);

            modelBuilder.Entity<Product>()
                .Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(s => s.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");
        }

        private void ConfigureCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(s => s.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Customer>()
                .Property(s => s.Email)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
