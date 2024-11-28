namespace RealTimeNotificationApp.Application.Dtos
{
    public class DeliveryStatusDto(StatusDto status, DateTime dataMovimentacao)
    {
        public StatusDto Status { get; set; } = status;
        public DateTime DataMovimentacao { get; set; } = dataMovimentacao;
    }
}
