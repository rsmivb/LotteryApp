using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lottery.Repository
{
    public abstract class MongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
