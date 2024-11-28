using RealTimeNotificationApp.Application.Dtos;

namespace RealTimeNotificationApp.Application.Interfaces
{
    public interface IDeliveryService
    {
        Task<DeliveryDto> RegisterDelivery(string orderNumber, DateTime creationDate, CancellationToken cancellationToken = default);
        Task<DeliveryDto> UpdateStatusDelivery(DeliveryDto delivery, int statusFinal, CancellationToken cancellationToken = default);
    }
}
