using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Infra.Configuration;
using RealTimeNotificationApp.Infra.Repositories.Base;

namespace RealTimeNotificationApp.Infra.Repositories
{
    public class DeliveryRepository : BaseRepository<Delivery>
    {
        public DeliveryRepository(MongoSettings settings) : base(settings)
        {
        }
    }
}
