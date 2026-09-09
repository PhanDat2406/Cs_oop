namespace oop.baiTap4;

public class MomoPayment : PaymentGateway, IPayable, IRefundable
{
    public string PhoneNumber { get; set; }

    public MomoPayment(string transactionId, string phoneNumber) : base(transactionId)
    {
        PhoneNumber = phoneNumber;
    }

    public override void ValidateConnection()
    {
        Console.WriteLine($"[MoMo API] Đang bắt tay và xác thực kết nối ví MoMo ({PhoneNumber})... Thành công!");
    }

    public bool ProcessPayment(decimal amount)
    {
        if (amount <= 0 || string.IsNullOrWhiteSpace(PhoneNumber))
            return false;

        Status = "Success";
        LogTransaction($"Thanh toán thành công số tiền {amount:C0} từ SĐT {PhoneNumber}.");
        return true;
    }

    public bool ProcessRefund(decimal amount, string reason)
    {
        if (amount <= 0)
            return false;

        Status = "Refunded";
        LogTransaction($"Hoàn trả {amount:C0}. Lý do: {reason}");
        return true;
    }
}