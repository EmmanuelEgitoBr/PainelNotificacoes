using RealTimeNotificationApp.Application.Dtos;
using System.Threading;

namespace RealTimeNotificationApp.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> RegisterOrder(OrderDto orderDto, CancellationToken cancellationToken = default);
    }
}
