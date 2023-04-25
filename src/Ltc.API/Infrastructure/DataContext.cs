using Ltc.API.Domain;
using Ltc.API.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Ltc.API.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Order> Orders { get; set; }
}