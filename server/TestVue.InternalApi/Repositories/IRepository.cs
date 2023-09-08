using TestVue.InternalApi.Models;

namespace TestVue.InternalApi.Repositories;

public interface IRepository<TObject, TId> 
    where TObject : IObjectWithId<TId> 
    where TId : IEquatable<TId?> {
    Task<TObject?> Get(TId id);
    TObject? GetSync(TId id);
    Task Set(TObject obj);
    Task<TObject[]> GetAll();
}