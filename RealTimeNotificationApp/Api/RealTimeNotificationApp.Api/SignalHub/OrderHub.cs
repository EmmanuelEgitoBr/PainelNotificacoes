using Microsoft.AspNetCore.SignalR;

namespace RealTimeNotificationApp.Api.SignalHub
{
    public class OrderHub : Hub
    {
        public async Task UpdateOrderStatus(string orderId, int status)
        {
            // Envia a atualização para todos os clientes conectados
            await Clients.All.SendAsync("ReceiveOrderStatusUpdate", orderId, status);
        }
    }
}
