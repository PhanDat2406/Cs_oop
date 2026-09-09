namespace oop.baiTap1;

public class BankAccount
{
    private static long _nextAccountNumber = 1000000001;
    private const decimal MinBalanceThreshold = 50_000m;

    private decimal _balance;
    private string _accountHolder = string.Empty;

    public long AccountNumber { get; init; }

    public string AccountHolder
    {
        get => _accountHolder;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên chủ tài khoản không được để trống.", nameof(AccountHolder));
            _accountHolder = value.Trim();
        }
    }

    public decimal Balance
    {
        get => _balance;
        private set => _balance = value;
    }

    public BankAccount(string accountHolder, decimal initialBalance)
    {
        if (initialBalance < MinBalanceThreshold)
            throw new ArgumentException($"Số dư ban đầu phải đạt tối thiểu {MinBalanceThreshold:N0} VNĐ.");

        AccountNumber = _nextAccountNumber++;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Số tiền nạp phải lớn hơn 0.", nameof(amount));

        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            return false;

        if (Balance - amount < MinBalanceThreshold)
            return false;

        Balance -= amount;
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"[STK: {AccountNumber}] Chủ TK: {AccountHolder,-18} | Số dư: {Balance,12:C0}");
    }
}
