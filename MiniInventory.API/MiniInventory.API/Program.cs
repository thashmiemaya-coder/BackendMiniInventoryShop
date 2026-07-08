using Microsoft.EntityFrameworkCore;
using MiniInventory.Infrastructure.Data;
using MiniInventory.Application.Interfaces;
using MiniInventory.Infrastructure.Repositories;
using MiniInventory.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// ===== PORT CONFIGURATION (Elastic Beanstalk) =====
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");

// Add services
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== REGISTER REPOSITORIES =====
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IStockInRepository, StockInRepository>();
builder.Services.AddScoped<IStockOutRepository, StockOutRepository>();

// Register User Repository and Service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// ===== REGISTER SERVICES =====
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IStockService, StockService>();

// ===== CORS =====
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// ===== MIDDLEWARE =====
app.UseCors("AllowAll");

// ⚠️ HTTPS Redirection - Comment out for Elastic Beanstalk
// EB එකේ HTTPS handle කරන්නේ Load Balancer එකයි
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();