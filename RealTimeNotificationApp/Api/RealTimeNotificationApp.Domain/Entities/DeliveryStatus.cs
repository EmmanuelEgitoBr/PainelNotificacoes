namespace RealTimeNotificationApp.Domain.Entities
{
    public class DeliveryStatus(Status status, DateTime dataMovimentacao)
    {
        public Status Status { get; set; } = status;
        public DateTime DataMovimentacao { get; set; } = dataMovimentacao;
    }
}
