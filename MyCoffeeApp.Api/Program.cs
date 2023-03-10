using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.Application.Interfaces;
using MyCoffeeApp.Application.Services;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Repository;
using MyCoffeeApp.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DataBase Context //
builder.Services.AddDbContextFactory<CoffeeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeIsGood"));
});

// Dependency Injection
builder.Services.AddTransient<ICoffeeService, CoffeeService>();
builder.Services.AddTransient(typeof(IGenericDataRepository<Coffee>), typeof(GenericDataRepository<Coffee>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
