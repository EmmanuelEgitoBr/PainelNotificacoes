using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RealTimeNotificationApp.Domain.Entities
{
    public class Delivery
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public List<DeliveryStatus>? ListaStatus { get; set; }
    }
}
