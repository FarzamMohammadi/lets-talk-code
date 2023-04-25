namespace Ltc.API.Domain.Orders;

public class OrderAlreadyPaidException : Exception
{
    public OrderAlreadyPaidException(string message) : base(message)
    {
    }
}