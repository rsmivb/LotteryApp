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
    /// <summary>
    /// Class repoistory resposible to manage all lottery data from database
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        public MongoRepository(AppSettings settings)
        {
            _db = new MongoClient(settings.Database.Url).GetDatabase(settings.Database.Name);
            _collectionName = settings.Lotteries.Where(lottery => lottery.Name.Equals(typeof(T).Name)).FirstOrDefault().Name;

            var collection = _db.GetCollection<T>(_collectionName);
            if (collection != null)
            {
                _db.DropCollection(_collectionName);
            }
            _db.CreateCollection(_collectionName);
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
