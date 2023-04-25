namespace Ltc.API.Domain.Orders.TaxCalculators;

public interface ITaxCalculator
{
    public decimal Rate { get; }

    decimal CalculateTax(decimal amount);
}