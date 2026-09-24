using Asal.OrderManagementSystem.Api.Interfaces;
using Asal.OrderManagementSystem.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();


app.Run();
