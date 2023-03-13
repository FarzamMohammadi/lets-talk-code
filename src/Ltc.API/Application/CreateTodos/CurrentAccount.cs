namespace Ltc.API.Application.CreateTodos;

// Aggregate Root
public class CurrentAccount
{
    // our rule is that he amount is never negative
    // we only update an amount after we commit a transaction

    public decimal Amount { get; set; }
    public List<Transaction> Transactions { get; set; }


    public void CommitTransction(Transaction t)
    {
        Transactions.Add(t);

        // calculate the amount for the CC
    }
}

// Entity
public record Transaction
{
    public decimal Amount { get; set; }
    public string Type1 { get; set; }
}