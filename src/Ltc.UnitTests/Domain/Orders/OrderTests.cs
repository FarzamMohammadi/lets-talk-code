using Ltc.API.Domain.Orders;
using Ltc.API.Domain.Orders.TaxCalculators;
using Moq;

namespace Ltc.Tests.Domain.Orders;

public class OrderTests
{
    // MethodUnderTest_Scenario_ExpectedBehavior
    [Fact]
    public void AddItem_AddingAProduct_OrderItemsIsUpdatedWithProvidedProduct()
    {
        // Arrange
        // Preparing our objects
        // Moq
        var taxCalculator = new Mock<ITaxCalculator>();
        // A mock is an empty object
        var order = new Order(new Customer(), taxCalculator.Object);
        var product = new Product();

        // Act
        // Executing the method under test
        order.AddItem(product, 1);

        // Assert
        // Verifying the result
        var expected = new OrderItem(product, 1);

        Assert.Single(order.OrderItems, expected);
    }

    [Fact]
    public void Order_WhenCreated_HasCreateStatus()
    {
        var taxCalculator = new Mock<ITaxCalculator>();

        var order = new Order(new Customer(), taxCalculator.Object);

        Assert.Equal(OrderStatus.Created, order.Status);
    }

    [Fact]
    public void AddItem_WhenAddingAnItem_UpdateTotalAmountBeforeTaxWithTheSumOfTheProductPrices()
    {
        var taxCalculator = new Mock<ITaxCalculator>();

        var order = new Order(new Customer(), taxCalculator.Object);

        var product1 = new Product
        {
            Price = 10
        };

        var product2 = new Product
        {
            Price = 20
        };

        order.AddItem(product1, 1);
        order.AddItem(product2, 2);

        var expected = 50;

        Assert.Equal(expected, order.TotalAmountBeforeTax);
    }

    [Fact]
    public void AddItem_WhenAddingAnItem_UpdateTotalTax()
    {
        var price = 10;

        var taxCalculator = new Mock<ITaxCalculator>();

        taxCalculator.Setup(p => p.CalculateTax(price))
                     .Returns(5);

        var order = new Order(new Customer(), taxCalculator.Object);

        var product = new Product
        {
            Price = price
        };

        order.AddItem(product, 1);

        var expected = 5;

        Assert.Equal(expected, order.TotalTax);
        taxCalculator.Verify(p => p.CalculateTax(price), Times.Once);
    }

    [Fact]
    public void AddItem_WhenAddingAnItem_TotalAmount()
    {
        var price = 10;

        var taxCalculator = new Mock<ITaxCalculator>();

        taxCalculator.Setup(p => p.CalculateTax(price))
                     .Returns(5);

        var order = new Order(new Customer(), taxCalculator.Object);

        var product = new Product
        {
            Price = price
        };

        order.AddItem(product, 1);

        var expected = 15;

        Assert.Equal(expected, order.TotalAmount);
    }

    // This is a silly example of what not to test
    [Fact]
    public void AddItem_WhenAddingAnItem_DoesntThrowArgumentException()
    {
        var taxCalculator = new Mock<ITaxCalculator>();

        var order = new Order(new Customer(), taxCalculator.Object);

        var product = new Product
        {
            Price = 10
        };

        var expected = 10;

        try
        {
            order.AddItem(product, 1);
        }
        catch (Exception e)
        {
            Assert.True(false);
        }

        Assert.True(true);
    }

    [Fact]
    public void SetStatus_WithCreatedStatusAndSetToPaidStatus_AssignsPaidStatus()
    {
        var taxCalculator = new Mock<ITaxCalculator>();

        var order = new Order(new Customer(), taxCalculator.Object);
        order.SetStatus(OrderStatus.Paid);

        Assert.Equal(OrderStatus.Paid, order.Status);
    }

    [Fact]
    public void SetStatus_WithPaidStatusAndSetPaidStatus_OrderAlreadyPaidException()
    {
        var taxCalculator = new Mock<ITaxCalculator>();

        var order = new Order(new Customer(), taxCalculator.Object);
        order.SetStatus(OrderStatus.Paid);

        Assert.Throws<OrderAlreadyPaidException>(() => order.SetStatus(OrderStatus.Paid));
    }
}