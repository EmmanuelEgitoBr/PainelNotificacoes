namespace RealTimeNotificationApp.Api.Models
{
    public class UpdateStatusRequest
    {
        public string NumeroPedido { get; set; } = string.Empty;
        public int StatusFinal {  get; set; }
    }
}
