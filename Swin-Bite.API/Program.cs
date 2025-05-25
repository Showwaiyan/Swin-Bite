using Microsoft.EntityFrameworkCore;
using SwinBite.Context;

var builder = WebApplication.CreateBuilder(args);

// Getting Connection String for DbContext to connect the DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
    throw new InvalidOperationException("Connection String: 'DefaultConnection' not found");

// Adding DbContext and connect DbContext and DB
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
