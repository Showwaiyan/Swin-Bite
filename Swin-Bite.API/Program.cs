using Microsoft.EntityFrameworkCore;
using SwinBite.Context;

var builder = WebApplication.CreateBuilder(args);

// DI IOC Configurations

// Getting Connection String for DbContext to connect the DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
    throw new InvalidOperationException("Connection String: 'DefaultConnection' not found");

// Adding DbContext and connect DbContext and DB
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); // Dependency Injection
// Add Controller Service
builder.Services.AddControllers();


var app = builder.Build();

// Middleware Configuration

app.UseHttpsRedirection();
app.MapControllers(); // To Map Controller End Point

app.Run();
