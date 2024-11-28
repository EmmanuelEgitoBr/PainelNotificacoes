using MongoDB.Driver;
using RealTimeNotificationApp.Domain.Interfaces.Base;
using RealTimeNotificationApp.Infra.Configuration;
using System.Linq.Expressions;

namespace RealTimeNotificationApp.Infra.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;
        protected readonly IMongoDatabase _database;

        public BaseRepository(MongoSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.Database);

            _database = database;
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> filterExpression)
            => await _collection.FindOneAndDeleteAsync(filterExpression);

        public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
            => await _collection.Find(filter).ToListAsync();

        public async Task<List<T>> GetAll(CancellationToken cancellationToken = default)
            => await _collection.Find(f => f != null).ToListAsync(cancellationToken);

        public async Task UpdateAsync(T newClass, Guid id, CancellationToken cancellationToken = default)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection!.ReplaceOneAsync(filter, newClass, cancellationToken: cancellationToken);
        }
    }
}
