namespace Ltc.API.Domain.Orders;

/// <summary>
/// Represents a customer who can place orders.
/// </summary>
public class Customer
{
    /// <summary>
    /// The unique identifier for the customer.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The email address of the customer.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The phone number of the customer.
    /// </summary>
    public string PhoneNumber { get; set; }
}