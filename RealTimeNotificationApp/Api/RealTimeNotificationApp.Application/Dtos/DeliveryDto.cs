using System.Text.Json.Serialization;

namespace RealTimeNotificationApp.Application.Dtos
{
    public class DeliveryDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public List<DeliveryStatusDto>? ListaStatus { get; set; }
    }
}
