using Ltc.API.Domain.Orders.TaxCalculators;

namespace Ltc.API.Domain.Orders;

public class Order
{
    private readonly ITaxCalculator _taxCalculator;

    public int Id { get; private set; }

    /// <summary>
    /// Total amount for items plus taxes. 
    /// </summary>
    public decimal TotalAmount { get; private set; }

    public decimal TotalAmountBeforeTax { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public Customer Customer { get; private set; }
    public decimal TotalTax { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }

    public Order(Customer customer, ITaxCalculator taxCalculator)
    {
        Customer = customer;
        _taxCalculator = taxCalculator;
        OrderDate = DateTime.Now;
        Status = OrderStatus.Created;
        OrderItems = new List<OrderItem>();
    }

    /// <summary>
    /// Updates the <seealso cref="OrderItems"/> list with the new <paramref name="product"/>.
    /// Calculates Taxes and Total Amounts.
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    public void AddItem(Product product, int quantity)
    {
        var orderItem = new OrderItem(product, quantity);
        OrderItems.Add(orderItem);

        TotalAmountBeforeTax = OrderItems.Sum(p => p.TotalAmount);

        TotalTax = _taxCalculator.CalculateTax(TotalAmountBeforeTax);

        TotalAmount = TotalAmountBeforeTax + TotalTax;
    }

    public void SetStatus(OrderStatus status)
    {
        if (status == OrderStatus.Paid && Status != OrderStatus.Created)
        {
            throw new OrderAlreadyPaidException("Cannot set status to Paid. Order is not in Created state.");
        }

        Status = status;
    }
}