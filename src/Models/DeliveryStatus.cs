namespace DeliveryAggregator.Models;

public class DeliveryStatus
{
    public string TrackingNumber { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }
}