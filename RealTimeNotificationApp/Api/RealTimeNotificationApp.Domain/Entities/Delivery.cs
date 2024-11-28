namespace RealTimeNotificationApp.Domain.Entities
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public Guid NumeroPedido { get; set; }
        public List<DeliveryStatus>? Status { get; set; }
    }
}
