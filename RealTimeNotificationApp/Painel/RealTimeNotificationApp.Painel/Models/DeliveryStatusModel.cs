using RealTimeNotificationApp.Painel.Models.Enums;

namespace RealTimeNotificationApp.Painel.Models
{
    public class DeliveryStatusModel(StatusModel status, DateTime dataMovimentacao)
    {
        public StatusModel Status { get; set; } = status;
        public DateTime DataMovimentacao { get; set; } = dataMovimentacao;
    }
}
