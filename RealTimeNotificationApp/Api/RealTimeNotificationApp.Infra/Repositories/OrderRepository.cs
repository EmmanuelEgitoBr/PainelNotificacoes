using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Domain.Interfaces;
using RealTimeNotificationApp.Infra.Configuration;
using RealTimeNotificationApp.Infra.Repositories.Base;

namespace RealTimeNotificationApp.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MongoSettings settings) : base(settings)
        {
        }
    }
}
