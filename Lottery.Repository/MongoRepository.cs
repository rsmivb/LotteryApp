using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Repository
{
    /// <summary>
    /// Class repository responsible to manage all lottery data from Mongo DB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoRepository<T> : IRepository<T> where T : MongoModel, new()
    {
        private readonly string _collectionName;
        private readonly IMongoDatabase _db;

        public IMongoCollection<T> Collection
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

        public MongoRepository(MongoConfiguration settings)
        {
            _db = new MongoClient(settings.Url).GetDatabase(settings.Name);
            _collectionName = typeof(T).Name;
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
            var collection = _db.GetCollection<T>(_collectionName);
            if (collection != null)
            {
                _db.DropCollection(_collectionName);
            }
            _db.CreateCollection(_collectionName);
        }
    }
}
