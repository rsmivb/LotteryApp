using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lottery.Repository
{
    public abstract class MongoModel
    {
        [BsonId]
        public ObjectId _id { get; set; }
    }
}
