using MongoDB.Driver;
using TestVue.InternalApi.Models;
using TestVue.InternalApi.Repositories;

namespace TestVue.Repositories;

// ReSharper disable once TypeParameterCanBeVariant
public abstract class MongoRepositoryBase<TObject, TId> : IRepository<TObject, TId> 
    where TObject : IObjectWithId<TId> 
    where TId : IEquatable<TId?> {
    protected readonly ReplaceOptions ReplaceOptions = new () { IsUpsert = true };
    protected readonly UpdateOptions UpdateOptions = new () { IsUpsert = true };

    protected readonly IMongoCollection<TObject> Collection;

    protected MongoRepositoryBase(IMongoDatabase database, string collection) {
        Collection = database.GetCollection<TObject>(collection);
    }

    public async Task<TObject?> Get(TId id) {
        return (await Collection.FindAsync(x => x.Id.Equals(id))).FirstOrDefault();
    }

    public TObject? GetSync(TId id) {
        return Collection.FindSync(x => x.Id.Equals(id)).FirstOrDefault();
    }

    public Task Set(TObject obj) {
        return Collection.ReplaceOneAsync(x => x.Id.Equals(obj.Id), obj, ReplaceOptions);
    }

    public async Task<TObject[]> GetAll() {
        // TODO rewrite. use only 'ToArray'
        return (await (await Collection.FindAsync(x => true)).ToListAsync()).ToArray();
    }
    
    public async Task<TObject[]> GetAll(Func<TObject, bool> predicate) {
        // TODO rewrite. use only 'ToArray'
        return (await (await Collection.FindAsync(x => predicate(x))).ToListAsync()).ToArray();
    }
}