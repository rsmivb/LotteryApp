using System;
using Xunit;

namespace Lottery.Repository.Tests
{
    public class MongoRepositoryTests
    {
        [Fact(DisplayName="Create database and the collection name should be Dummy class that implements MongoModel")]
        [Trait("Mongo","Repository")]
        public void CreateDatabaseShouldExistsDummyCollection()
        {
            var expextedCollectionName = nameof(Dummy);
            var repository = new MongoRepository<Dummy>(new MongoDBConfiguration { Name = "local", Url = "mongodb://localhost:27017" });

            Assert.Equal(expextedCollectionName, repository.Collection.CollectionNamespace.CollectionName);
        }
    }
    public class Dummy : MongoModel
    {
        public string DummyProperty1 { get; set; }
    }
}
