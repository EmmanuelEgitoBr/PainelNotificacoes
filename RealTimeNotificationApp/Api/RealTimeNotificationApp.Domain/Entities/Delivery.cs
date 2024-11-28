namespace RealTimeNotificationApp.Domain.Entities
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public List<DeliveryStatus>? ListaStatus { get; set; }
    }
}
