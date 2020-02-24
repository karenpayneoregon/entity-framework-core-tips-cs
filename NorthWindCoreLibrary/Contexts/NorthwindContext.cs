using NorthWindCoreLibrary.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace NorthWindCoreLibrary.Contexts
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Determine if logging to the IDE console should be done,
        /// </summary>
        public bool Diagnostics { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWindAzureForInserts;Integrated Security=True";
                if (Diagnostics)
                {
                    optionsBuilder.UseSqlServer(connectionString)
                        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)).EnableSensitiveDataLogging();

                    optionsBuilder.UseLoggerFactory(LoggerFactory);
                }
                else
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerIdentifier)
                    .HasName("PK_Customers_1");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customers_Contacts");

                entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactTypeIdentifier)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customers_ContactType");

                entity.HasOne(d => d.CountryIdentifierNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryIdentifier)
                    .HasConstraintName("FK_Customers_Countries");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.CustomerIdentifierNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerIdentifier)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Customers2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.ShipperId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasOne(d => d.CountryIdentifierNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CountryIdentifier)
                    .HasConstraintName("FK_Suppliers_Countries");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        /// <summary>
        /// For Entity Framework Core 3.x see
        /// https://docs.microsoft.com/en-us/aspnet/core/migration/logging-nonaspnetcore?view=aspnetcore-3.1
        /// </summary>
        public static readonly ILoggerFactory LoggerFactory = new LoggerFactory().AddConsole((_, ___) => true);
    }

}