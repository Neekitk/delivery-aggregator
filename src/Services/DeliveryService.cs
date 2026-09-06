using DeliveryAggregator.Integrations;
using DeliveryAggregator.Models;

namespace DeliveryAggregator.Services;

public class DeliveryService
{
    private readonly CdekApiClient _cdekApiClient;
    private readonly RussianPostApiClient _russianPostApiClient;

    public DeliveryService(
        CdekApiClient cdekApiClient,
        RussianPostApiClient russianPostApiClient)
    {
        _cdekApiClient = cdekApiClient;
        _russianPostApiClient = russianPostApiClient;
    }

    public async Task<DeliveryStatus> GetDeliveryStatusAsync(
        Order order)
    {
        if (string.IsNullOrWhiteSpace(order.TrackingNumber))
        {
            throw new ArgumentException(
                "У заказа отсутствует трек-номер.");
        }

        return order.DeliveryProvider.ToLower() switch
        {
            "cdek" =>
                await _cdekApiClient.GetDeliveryStatusAsync(
                    order.TrackingNumber),

            "russianpost" =>
                await _russianPostApiClient.GetDeliveryStatusAsync(
                    order.TrackingNumber),

            _ => throw new ArgumentException(
                $"Неизвестная служба доставки: {order.DeliveryProvider}")
        };
    }
}