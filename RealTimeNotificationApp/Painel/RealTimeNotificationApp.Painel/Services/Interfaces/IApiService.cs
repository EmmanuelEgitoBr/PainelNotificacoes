using RealTimeNotificationApp.Painel.Models;

namespace RealTimeNotificationApp.Painel.Services.Interfaces
{
    public interface IApiService
    {
        Task<CompleteOrderModel> GetCompleteOrder(string orderNumber);
        Task<CompleteOrderModel> CreateOrder(OrderModel order);
        Task<bool> UpdateStatus(UpdateStatusModel model);
    }
}
