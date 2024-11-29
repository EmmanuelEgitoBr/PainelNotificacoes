using RealTimeNotificationApp.Painel.Models;
using RealTimeNotificationApp.Painel.Services.Interfaces;

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
    }
}
