using DeliveryAggregator.Integrations;
using DeliveryAggregator.Models;
using DeliveryAggregator.Services;

Console.WriteLine("=== Агрегатор служб доставки ===");
Console.WriteLine();

using var httpClient = new HttpClient();

var cdekApiClient = new CdekApiClient(httpClient);
var russianPostApiClient = new RussianPostApiClient(httpClient);

var deliveryService = new DeliveryService(
    cdekApiClient,
    russianPostApiClient);

var order = new Order
{
    Id = 1001,
    CustomerName = "Иван Иванов",
    Phone = "+7 900 123-45-67",
    Address = "Санкт-Петербург, Невский проспект, 10",
    TotalPrice = 5490.00m,
    Weight = 2.5,
    DeliveryProvider = "cdek",
    TrackingNumber = "123456789"
};

Console.WriteLine($"Заказ №{order.Id}");
Console.WriteLine($"Клиент: {order.CustomerName}");
Console.WriteLine($"Адрес: {order.Address}");
Console.WriteLine($"Служба доставки: {order.DeliveryProvider}");
Console.WriteLine($"Трек-номер: {order.TrackingNumber}");
Console.WriteLine();

try
{
    var status = await deliveryService.GetDeliveryStatusAsync(order);

    Console.WriteLine("Информация о доставке:");
    Console.WriteLine($"Статус: {status.Status}");
    Console.WriteLine($"Описание: {status.Description}");
    Console.WriteLine($"Дата обновления: {status.UpdatedAt}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("Работа приложения завершена.");