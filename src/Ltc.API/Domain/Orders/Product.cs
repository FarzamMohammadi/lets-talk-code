namespace Ltc.API.Domain.Orders;

/// <summary>
/// Represents a product that can be ordered.
/// </summary>
public class Product
{
    /// <summary>
    /// The unique identifier of the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description of the product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The quantity of the product in stock.
    /// </summary>
    public int QuantityInStock { get; set; }
}