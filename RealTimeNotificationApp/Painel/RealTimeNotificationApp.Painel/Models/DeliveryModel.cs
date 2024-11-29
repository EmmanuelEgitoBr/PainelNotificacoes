namespace RealTimeNotificationApp.Painel.Models
{
    public class DeliveryModel
    {
        public Guid Id { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public List<DeliveryStatusModel>? ListaStatus { get; set; }
    }
}
