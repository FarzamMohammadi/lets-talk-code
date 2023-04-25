using Ltc.API.Domain.Orders;
using Ltc.API.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ltc.API.Infrastructure.Repositories.Orders;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Order>> Cancelled()
    {
        return await Context.Orders
                            .Include(p => p.OrderItems)
                            .AsSplitQuery()
                            .Where(p => p.Status == OrderStatus.Cancelled)
                            .ToListAsync();
    }
}