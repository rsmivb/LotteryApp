using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        T GetOne(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetByFilterAsync(Expression<Func<T, bool>> expression);

        Task<T> FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        void UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        void DeleteOne(Expression<Func<T, bool>> expression);

        void InsertMany(IEnumerable<T> items);

        void InsertOne(T item);
    }
}
