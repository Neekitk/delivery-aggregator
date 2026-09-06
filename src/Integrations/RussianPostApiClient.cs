using DeliveryAggregator.Models;

namespace DeliveryAggregator.Integrations;

public class RussianPostApiClient
{
    private readonly HttpClient _httpClient;

    public RussianPostApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DeliveryStatus> GetDeliveryStatusAsync(
        string trackingNumber)
    {
        // Демонстрационный запрос к API Почты России.
        // В реальном проекте здесь будет настоящий HTTPS-запрос
        // к API транспортной службы.

        await Task.Delay(300);

        return new DeliveryStatus
        {
            TrackingNumber = trackingNumber,
            Status = "Delivered",
            Description = "Отправление доставлено получателю",
            UpdatedAt = DateTime.Now
        };
    }
}