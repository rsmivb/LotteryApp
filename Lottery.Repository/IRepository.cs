using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lottery.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        T GetOne(FilterDefinition<T> filter);

        IEnumerable<T> GetByFilterAsync(FilterDefinition<T> filter);

        IEnumerable<T> GetAll();

        Task<T> FindOneAndUpdate(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update);

        void DeleteOne(FilterDefinition<T> filter);

        void InsertMany(IEnumerable<T> items);

        void InsertOne(T item);

        void CreateDatabase();
    }
}
