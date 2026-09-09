using oop.baiTap1;
using oop.baiTap2;
using oop.baiTap3;
using oop.baiTap4;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("vi-VN");

Console.WriteLine("========== BÀI TẬP 1: BANK ACCOUNT ==========");
try
{
    var acc1 = new BankAccount("Nguyễn Văn A", 100_000m);
    var acc2 = new BankAccount("Trần Thị B", 2_000_000m);
    acc1.DisplayInfo();
    acc2.DisplayInfo();

    Console.WriteLine("Nạp 50,000 VNĐ vào TK 1...");
    acc1.Deposit(50_000m);
    acc1.DisplayInfo();

    Console.WriteLine("Thử rút 120,000 VNĐ từ TK 1 (vi phạm hạn mức duy trì 50k):");
    bool result1 = acc1.Withdraw(120_000m);
    Console.WriteLine($"Kết quả rút: {(result1 ? "Thành công" : "Thất bại (Số dư không đủ hạn mức)")}");

    Console.WriteLine("Thử tạo tài khoản với số dư 20,000 VNĐ:");
    var accFail = new BankAccount("Lê Văn C", 20_000m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Bắt ngoại lệ] Lỗi kiểm tra dữ liệu: {ex.Message}");
}

Console.WriteLine("\n========== BÀI TẬP 2: EMPLOYEE HIERARCHY ==========");
int currentYear = DateTime.Now.Year;
var dev = new Employee("NV01", "Phan Công Thành Đạt", 2006, 15_000_000m);
var lead = new Manager("QL01", "Hoàng Anh Tuấn", 1995, 25_000_000m, 8_000_000m);

Console.WriteLine($"Nhân viên: {dev.FullName} | Tuổi: {dev.GetAge(currentYear)} | Lương cơ bản: {dev.BaseSalary:C0} | Thực lĩnh: {dev.CalculateIncome():C0}");
Console.WriteLine($"Quản lý  : {lead.FullName} | Tuổi: {lead.GetAge(currentYear)} | Lương cơ bản: {lead.BaseSalary:C0} | Thực lĩnh: {lead.CalculateIncome():C0}");

Console.WriteLine("\n========== BÀI TẬP 3: OVERLOADING & OVERRIDING ==========");
decimal cartValue = 500_000m;
Console.WriteLine($"Đơn hàng gốc: {cartValue:C0}");
Console.WriteLine($"1. Giảm mặc định (5%): {DiscountCalculator.ApplyDiscount(cartValue):C0}");
Console.WriteLine($"2. Giảm 15%:           {DiscountCalculator.ApplyDiscount(cartValue, 15):C0}");
Console.WriteLine($"3. Voucher 50k (đơn >400k): {DiscountCalculator.ApplyDiscount(cartValue, 50_000m, 400_000m):C0}");

var shipments = new List<DeliveryService>
{
    new DeliveryService("ORD-001", 12.0),
    new ExpressDelivery("ORD-002", 12.0),
    new EcoDelivery("ORD-003", 12.0)
};

Console.WriteLine("\nKiểm tra đa hình Runtime (cùng quãng đường 12 km):");
foreach (var ship in shipments)
{
    Console.WriteLine($"Mã: {ship.OrderId} | Loại dịch vụ: {ship.GetType().Name,-15} | Phí ship: {ship.CalculateShippingFee():C0}");
}

Console.WriteLine("\n========== BÀI TẬP 4: PAYMENT GATEWAY ==========");
var momo = new MomoPayment("MOMO_998234", "0987654321");
momo.ValidateConnection();

// Sử dụng qua Interface IPayable
IPayable payable = momo;
payable.ProcessPayment(350_000m);

// Sử dụng qua Interface IRefundable
IRefundable refundable = momo;
refundable.ProcessRefund(350_000m, "Khách hàng hủy đơn dịch vụ");