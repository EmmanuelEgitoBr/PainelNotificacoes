namespace RealTimeNotificationApp.Painel.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public string NomeDestinatario { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public AddressModel? Endereco { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
