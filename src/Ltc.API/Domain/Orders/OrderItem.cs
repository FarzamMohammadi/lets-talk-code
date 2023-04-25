namespace Ltc.API.Domain.Orders;

public class OrderItem
{
    public int Id { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public decimal TotalAmount
    {
        get { return Quantity * Product.Price; }
    }

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    protected bool Equals(OrderItem other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OrderItem)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}