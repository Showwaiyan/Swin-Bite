using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Mappings;
using SwinBite.Reposiroties;
using SwinBite.Services;

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

// Repository Injection
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RestaurantRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<FoodRepository>();
builder.Services.AddScoped<BankRepository>();
builder.Services.AddScoped<OrderRepository>();

// Services Injection
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<RestaurantServices>();
builder.Services.AddScoped<CustomerServices>();
builder.Services.AddScoped<FoodServices>();
builder.Services.AddScoped<BankServices>();
builder.Services.AddScoped<BankValidatorServices>();
builder.Services.AddScoped<OrderServices>();
builder.Services.AddScoped<ValidationEventArgs>();
builder.Services.AddScoped<IValidatorServices<ValidationEventArgs>, BankValidatorServices>();
builder.Services.AddScoped<IValidateServices<ValidationEventArgs>, BankServices>();

var app = builder.Build();

// Middleware Configuration

app.UseHttpsRedirection();
app.MapControllers(); // To Map Controller End Point

app.Run();
