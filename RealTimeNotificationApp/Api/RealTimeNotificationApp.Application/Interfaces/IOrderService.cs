using RealTimeNotificationApp.Application.Dtos;
using System.Threading;

namespace RealTimeNotificationApp.Application.Interfaces
{
    public interface IOrderService
    {
        Task DeleteOrder(string orderNumber);
        Task<OrderDto> GetOrder(string orderNumber, CancellationToken cancellationToken = default);
        Task<OrderDto> RegisterOrder(OrderDto orderDto, CancellationToken cancellationToken = default);
        Task<OrderDto> UpdateContactNumber(string orderNumber, string newPhone, CancellationToken cancellationToken = default);
    }
}
