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
        }
        public T GetOne(FilterDefinition<T> filter)
        {
            return Collection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<T> GetByFilterAsync(FilterDefinition<T> filter)
        {
            return Collection.Find(filter).ToListAsync().Result;
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.Find(Builders<T>.Filter.Empty).ToListAsync().Result;
        }

        public async Task<T> FindOneAndUpdate(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return await Collection.FindOneAndUpdateAsync(filter, update, option);
        }

        public void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            Collection.UpdateOneAsync(filter, update);
        }

        public void DeleteOne(FilterDefinition<T> filter)
        {
            Collection.DeleteOneAsync(filter);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            Collection.InsertManyAsync(items);
        }

        public void InsertOne(T item)
        {
            Collection.InsertOneAsync(item);
        }

        public void CreateDatabase()
        {
            var collection = _db.GetCollection<T>(_collectionName).EstimatedDocumentCount();
            if (collection > 0)
            {
                _db.DropCollection(_collectionName);
            }
            _db.CreateCollection(_collectionName);
        }
    }
}
