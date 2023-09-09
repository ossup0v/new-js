using MongoDB.Driver;
using TestVue.InternalApi.Models;
using TestVue.InternalApi.Repositories;

namespace TestVue.Repositories;

public sealed class SpendingMongoRepository : MongoRepositoryBase<SpendingModel, string>, ISpendingRepository
{
    public SpendingMongoRepository(IMongoDatabase database) : base(database, "spending-collection")
    {
    }
}