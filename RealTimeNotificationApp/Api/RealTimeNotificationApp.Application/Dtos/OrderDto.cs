using System.Text.Json.Serialization;

namespace RealTimeNotificationApp.Application.Dtos
{
    public class OrderDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        
        [JsonIgnore]
        public string NumeroPedido { get; set; } = string.Empty;
        public string NomeDestinatario { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public AddressDto? Endereco { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
