namespace Ltc.API.Domain.Orders.TaxCalculators;

public class OntarioTaxCalculator : ITaxCalculator
{
    public decimal Rate => 13;

    public decimal CalculateTax(decimal amount)
    {
        return amount * Rate / 100;
    }
}