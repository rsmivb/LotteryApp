using Lottery.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : class, new()
    {
        private string _collectionName;
        private IMongoDatabase _db;

        protected IMongoCollection<T> Collection
        {
            get
            {
                return _db.GetCollection<T>(_collectionName);
            }
            set
            {
                Collection = value;
            }
        }
        public MongoRepository(AppSettings settings, string collectionName)
        {
            _db = new MongoClient(settings.Database.Url).GetDatabase(settings.Database.Name);
            _collectionName = collectionName;
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).SingleOrDefault();
        }

        public IEnumerable<T> GetByFilterAsync(Expression<Func<T, bool>> expression)
        {
            var result = Collection.FindAsync(expression).Result;
            return result.ToEnumerable();
        }

        public async Task<T> FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return await Collection.FindOneAndUpdateAsync(expression, update, option);
        }

        public void UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            Collection.UpdateOneAsync(expression, update);
        }

        public void DeleteOne(Expression<Func<T, bool>> expression)
        {
            Collection.DeleteOneAsync(expression);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            Collection.InsertManyAsync(items);
        }

        public void InsertOne(T item)
        {
            Collection.InsertOneAsync(item);
        }
    }
}
