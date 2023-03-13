using Ltc.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ltc.API.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}