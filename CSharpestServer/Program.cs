using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CSharpestServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<BundleService, BundleService>();
builder.Services.AddScoped<CartItemService, CartItemService>();
builder.Services.AddScoped<ItemService, ItemService>();
builder.Services.AddScoped<OrderItemService, OrderItemService>();
builder.Services.AddScoped<OrderService, OrderService>();
builder.Services.AddScoped<UsersService, UsersService>();
//builder.Services.AddScoped<CheckoutService, CheckoutService>();

//builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StoreContext")));
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=candyDb;Integrated Security=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true));

app.UseAuthorization();

app.MapControllers();

app.Run();
