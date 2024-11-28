using RealTimeNotificationApp.Application.Dtos;

namespace RealTimeNotificationApp.Application.Interfaces
{
    public interface IDeliveryService
    {
        Task DeleteDelivery(string orderNumber);
        Task<DeliveryDto> GetDelivery(string orderNumber, CancellationToken cancellationToken = default);
        Task<DeliveryDto> RegisterDelivery(string orderNumber, DateTime creationDate, CancellationToken cancellationToken = default);
        Task<DeliveryDto> UpdateStatusDelivery(DeliveryDto delivery, int statusFinal, CancellationToken cancellationToken = default);
    }
}
