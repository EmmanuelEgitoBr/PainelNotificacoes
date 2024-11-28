using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Infra.Configuration;
using RealTimeNotificationApp.Infra.Repositories.Base;

namespace RealTimeNotificationApp.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(MongoSettings settings) : base(settings)
        {
        }
    }
}
