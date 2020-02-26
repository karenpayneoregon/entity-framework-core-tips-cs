using NorthWindCoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

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

                
                var serverName = Environment.UserName == "Karens" ? "KARENS-PC" : ".\\SQLEXPRESS";

                var connectionString = $"Data Source={serverName};Initial Catalog=NorthWindAzureForInserts;Integrated Security=True";

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


                /*
                 * Uncomment to filter out Discontinued products
                 */
                //entity.HasQueryFilter(prod => prod.Discontinued == false);

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
        #region SaveChanges overrides
        /// <summary>
        /// Override SaveChanges to demonstrate in this
        /// case having an event to review changes both
        /// original and current values
        /// 
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

        /// <summary>
        /// Raw example for accessing data prior to performing a save.
        /// </summary>
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            /*
             * Only interested in modified entities
             */
            var modifiedEntities = ChangeTracker
                .Entries().Where(_ =>  _.State == EntityState.Modified);

            /*
             * Iterate any modified entities
             */
            foreach (var change in modifiedEntities)
            {

                /*
                 * We are only concerned in this case with customer entities
                 */
                if (change.Entity is Customer customer)
                {
                    /*
                     * Show primary key
                     */
                    Console.WriteLine($"Primary key: {GetEntityPrimaryKeyValue(change.Entity)}");

                    foreach (var propInfo in change.Entity.GetType().GetTypeInfo().DeclaredProperties)
                    {
                        if (!propInfo.GetGetMethod().IsVirtual)
                        {
                            /*
                             * Show property name, original and current values
                             */
                            Console.WriteLine(
                                $"Name: {propInfo.Name} original " + 
                                $"'{change.Property(propInfo.Name).OriginalValue}' " + 
                                $"current '{change.Property(propInfo.Name).CurrentValue}'");
                        }
                        
                    }
                }
            }

        }
        /// <summary>
        /// Obtain a primary key value for an entity
        /// </summary>
        /// <typeparam name="T">Entity type in the current context</typeparam>
        /// <param name="entity">The actual entity</param>
        /// <returns></returns>
        protected virtual int GetEntityPrimaryKeyValue<T>(T entity)
        {
            var itemType = entity.GetType();

            var keyName = Model.FindEntityType(itemType)
                .FindPrimaryKey().Properties.Select(x => x.Name).Single();

            var primaryKeyValue = (int)entity.GetType()
                .GetProperty(keyName)?.GetValue(entity, null);

            if (primaryKeyValue < 0)
            {
                return -1;
            }

            return primaryKeyValue;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        /// <summary>
        /// For Entity Framework Core 3.x see
        /// https://docs.microsoft.com/en-us/aspnet/core/migration/logging-nonaspnetcore?view=aspnetcore-3.1
        /// </summary>
        public static readonly ILoggerFactory LoggerFactory = new LoggerFactory().AddConsole((_, ___) => true);

    }

}