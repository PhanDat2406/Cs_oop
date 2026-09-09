namespace oop.baiTap4;

public interface IRefundable
{
    bool ProcessRefund(decimal amount, string reason);
}