using System.Net.Http.Json;
using DeliveryAggregator.Models;

namespace DeliveryAggregator.Integrations;

public class CdekApiClient
{
    private readonly HttpClient _httpClient;

    public CdekApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DeliveryStatus> GetDeliveryStatusAsync(
        string trackingNumber)
    {
        // Демонстрационный запрос к API СДЭК.
        // В реальном проекте здесь будет настоящий URL API
        // и авторизация.

        await Task.Delay(300);

        return new DeliveryStatus
        {
            TrackingNumber = trackingNumber,
            Status = "InTransit",
            Description = "Отправление находится в пути",
            UpdatedAt = DateTime.Now
        };
    }
}