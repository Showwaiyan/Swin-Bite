using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using SwinBite.Context;
using SwinBite.Mappings;

var builder = WebApplication.CreateBuilder(args);

// DI IOC Configurations

// Get Connection String for DbContext to connect the DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
    throw new InvalidOperationException("Connection String: 'DefaultConnection' not found");

// Add DbContext and connect DbContext and DB
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); // Dependency Injection

// Add DTO Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Controller Service
builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Middleware Configuration

app.UseHttpsRedirection();
app.MapControllers(); // To Map Controller End Point

app.Run();
