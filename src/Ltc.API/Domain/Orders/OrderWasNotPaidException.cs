namespace Ltc.API.Domain.Orders;

public class OrderWasNotPaidException : Exception
{
    public OrderWasNotPaidException(string message) : base(message)
    {
    }
}