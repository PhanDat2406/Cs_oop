namespace oop.baiTap3;

public class EcoDelivery : DeliveryService
{
    public EcoDelivery(string orderId, double distanceKm) : base(orderId, distanceKm) { }

    public override decimal CalculateShippingFee()
    {
        decimal baseFee = base.CalculateShippingFee();
        return DistanceKm > 10 ? baseFee * 0.9m : baseFee;
    }
}
