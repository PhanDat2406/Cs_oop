namespace oop.baiTap3;

public static class DiscountCalculator
{
    // Overload 1: Giảm mặc định 5%
    public static decimal ApplyDiscount(decimal totalAmount)
    {
        return totalAmount * 0.95m;
    }

    // Overload 2: Giảm theo phần trăm tùy biến (0 - 100)
    public static decimal ApplyDiscount(decimal totalAmount, double percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentOutOfRangeException(nameof(percentage), "Phần trăm giảm phải từ 0 đến 100.");

        return totalAmount * (1 - (decimal)(percentage / 100.0));
    }

    // Overload 3: Giảm voucher tiền mặt nếu đạt giá trị đơn tối thiểu
    public static decimal ApplyDiscount(decimal totalAmount, decimal fixedVoucher, decimal minimumOrder)
    {
        if (totalAmount >= minimumOrder)
            return Math.Max(0, totalAmount - fixedVoucher);

        return totalAmount;
    }
}
