namespace oop.baiTap4;

public abstract class PaymentGateway
{
    public string TransactionId { get; init; }
    public DateTime CreationDate { get; init; }
    public string Status { get; protected set; }

    protected PaymentGateway(string transactionId)
    {
        TransactionId = transactionId;
        CreationDate = DateTime.Now;
        Status = "Pending";
    }

    public abstract void ValidateConnection();

    public virtual void LogTransaction(string message)
    {
        Console.WriteLine($"[{CreationDate:yyyy-MM-dd HH:mm:ss}] [Giao dịch #{TransactionId}] [{Status}]: {message}");
    }
}