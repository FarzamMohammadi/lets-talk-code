using Ltc.API.Domain.Orders;
using Ltc.API.Domain.Orders.TaxCalculators;

namespace Ltc.API.Application.Orders;

// CreateOrder class which uses unit of work and CreateOrderDto to save it to the database
public class CreateOrder
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrder(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateOrderDto dto)
    {
        var order = new Order(dto.Customer, new OntarioTaxCalculator());

        _unitOfWork.Orders.Add(order);
        _unitOfWork.Complete();
    }
}