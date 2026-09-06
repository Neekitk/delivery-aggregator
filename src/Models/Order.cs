namespace DeliveryAggregator.Models;

public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public decimal TotalPrice { get; set; }

    public double Weight { get; set; }

    public string DeliveryProvider { get; set; } = string.Empty;

    public string? TrackingNumber { get; set; }
}