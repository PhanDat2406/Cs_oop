namespace oop.baiTap3;

public class ExpressDelivery : DeliveryService
{
    public ExpressDelivery(string orderId, double distanceKm) : base(orderId, distanceKm) { }

    public override decimal CalculateShippingFee()
    {
        return (base.CalculateShippingFee() * 1.5m) + 20_000m;
    }
}