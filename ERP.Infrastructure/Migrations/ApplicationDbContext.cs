using ERP.Domain.Entities;
using ERP.Domain.Entities.Employees;
using ERP.Domain.Entities.Inventory;
using ERP.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Migrations
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }

        public DbSet<Department>? Departments { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }
        public DbSet<SalesOrder>? SalesOrders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ERPPlatform.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
            
            modelBuilder.Entity<PurchaseOrder>().ToTable("PurchaseOrders");
            modelBuilder.Entity<PurchaseOrder>().HasOne(o => o.Supplier)
                .WithMany(s => s.PurchaseOrders).HasForeignKey(o => o.SupplierId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(o => o.Employee)
                .WithMany(e => e.PurchaseOrders)
                .HasForeignKey(o => o.EmployeeId);
            
            modelBuilder.Entity<SalesOrder>().ToTable("SalesOrders");
            modelBuilder.Entity<SalesOrder>().HasOne(o => o.Customer)
                .WithMany(c => c.SalesOrders)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<SalesOrder>().HasOne(o => o.Employee)
                .WithMany(e => e.SalesOrders)
                .HasForeignKey(o => o.EmployeeId);
            
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");

            base.OnModelCreating(modelBuilder);
        }
    }
}