﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lottery.Models
{
    public abstract class MongoModel
    {
        [BsonId]
        public ObjectId _id { get; set; }
    }
}
