using Ltc.API.Application;
using Ltc.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("ltcDb")));
builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using var serviceScope = app.Services.CreateScope();

var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();

context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace Ltc.API
{
    public partial class Program
    {
    }
}