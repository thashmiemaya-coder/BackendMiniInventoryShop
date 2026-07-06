using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MiniInventory.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Use the same connection string as your appsettings.json
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-EIBD1L0\\SQLEXPRESS;Database=GroceryInventoryDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}