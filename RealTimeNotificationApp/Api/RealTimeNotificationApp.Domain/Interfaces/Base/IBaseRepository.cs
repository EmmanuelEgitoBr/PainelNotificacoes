using System.Linq.Expressions;

namespace RealTimeNotificationApp.Domain.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T retailer);
        Task DeleteAsync(Expression<Func<T, bool>> filterExpression);
        Task DeleteAsync(T document);
        Task<T> FindAsync(Guid id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll();
        Task UpdateAsync(T retailer);
    }
}
