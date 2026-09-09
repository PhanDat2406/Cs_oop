namespace oop.baiTap3;

public class DeliveryService
{
    public string OrderId { get; init; }
    public double DistanceKm { get; set; }

    public DeliveryService(string orderId, double distanceKm)
    {
        OrderId = orderId;
        DistanceKm = distanceKm;
    }

    public virtual decimal CalculateShippingFee()
    {
        return (decimal)DistanceKm * 5000m;
    }
}