using MongoDB.Driver;
using TestVue.InternalApi.Models;
using TestVue.InternalApi.Repositories;

namespace TestVue.Repositories;

public sealed class TestMongoRepository : MongoRepositoryBase<TestModel, string>, ITestRepository
{
    public TestMongoRepository(IMongoDatabase database) : base(database, "test-collection")
    {
    }
}