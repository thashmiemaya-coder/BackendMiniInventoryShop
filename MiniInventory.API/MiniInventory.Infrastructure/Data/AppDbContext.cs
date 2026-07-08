using Microsoft.EntityFrameworkCore;
using MiniInventory.Domain.Entities;

namespace MiniInventory.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<StockIn> StockIns { get; set; }
        public DbSet<StockOut> StockOuts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);
                entity.Property(e => e.SupplierName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ContactNumber).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemId);
                entity.Property(e => e.ItemCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Barcode).HasMaxLength(50);
                entity.Property(e => e.ItemName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CostPrice).HasPrecision(18, 2);
                entity.Property(e => e.SellingPrice).HasPrecision(18, 2);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Category)
                    .WithMany(e => e.Items)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Supplier)
                    .WithMany(e => e.Items)
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StockIn>(entity =>
            {
                entity.HasKey(e => e.StockInId);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.CostPrice).HasPrecision(18, 2);
                entity.Property(e => e.StockInDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Item)
                    .WithMany(e => e.StockIns)
                    .HasForeignKey(e => e.ItemId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Supplier)
                    .WithMany()
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StockOut>(entity =>
            {
                entity.HasKey(e => e.StockOutId);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Reason).IsRequired().HasMaxLength(50);
                entity.Property(e => e.StockOutDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Item)
                    .WithMany(e => e.StockOuts)
                    .HasForeignKey(e => e.ItemId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValue("Cashier");
                entity.Property(e => e.FullName)
                    .HasMaxLength(100);
                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}