using Ltc.API.Domain.Orders;

namespace Ltc.API.Application.Orders;

public class CreateOrderDto
{
    public Customer Customer { get; set; }
}