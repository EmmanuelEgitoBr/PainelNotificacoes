namespace RealTimeNotificationApp.Application.Dtos
{
    public class AddressDto
    {
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
    }
}
