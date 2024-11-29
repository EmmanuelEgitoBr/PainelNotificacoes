using Microsoft.AspNetCore.SignalR;

namespace RealTimeNotificationApp.Api.SignalHub
{
    public class OrderHub : Hub
    {
        public async Task UpdateOrderStatus(string orderNumber, int status)
        {
            // Envia a atualização para todos os clientes conectados
            await Clients.All.SendAsync("ReceiveOrderStatusUpdate", orderNumber, status);
        }

        public async Task CreateNewOrder(string orderNumber)
        {
            // Envia a atualização para todos os clientes conectados
            await Clients.All.SendAsync("ReceiveCreationNewOrder", orderNumber);
        }
    }
}
