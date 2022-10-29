using JuniorTaskApi.Models;
using JuniorTaskApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDatabase>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("localcs")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
builder.Services.AddScoped<IMyOrderRepository, MyOrderRepository>();
builder.Services.AddCors(corsOption =>
{
    corsOption.AddPolicy("policy", corsPolicybuilder =>
     {
         corsPolicybuilder.AllowAnyOrigin().AllowAnyHeader();
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("policy");
app.UseAuthorization();

app.MapControllers();

app.Run();
