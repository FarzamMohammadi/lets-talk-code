using Ltc.API.Domain.Orders.TaxCalculators;

namespace Ltc.Tests.Domain.Orders;

public class OntarioTaxCalculatorTests
{
    [Fact]
    public void CalculateTax_WhenCalled_ReturnsTheCorrectTax()
    {
        var taxCalculator = new OntarioTaxCalculator();

        var result = taxCalculator.CalculateTax(100);

        Assert.Equal(13, result);
    }
}