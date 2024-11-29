using RealTimeNotificationApp.Painel.Models;
using RealTimeNotificationApp.Painel.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text;

namespace RealTimeNotificationApp.Painel.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<CompleteOrderModel> GetCompleteOrder(string orderNumber)
        {
            var response = await _httpClient.GetAsync($"/api/Pedido/resumo-completo/{orderNumber}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CompleteOrderModel>() ?? new CompleteOrderModel();
        }

        public async Task<CompleteOrderModel> CreateOrder(OrderModel order)
        {
            var json = JsonSerializer.Serialize(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Pedido/registrar-pedido", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CompleteOrderModel>() ?? new CompleteOrderModel();
        }

        public async Task<bool> UpdateStatus(UpdateStatusModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Pedido/alterar-status", content);

            if (response.IsSuccessStatusCode) { return true; }

            return false;
        }
    }
}
