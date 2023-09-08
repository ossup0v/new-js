namespace TestVue.InternalApi.Models;

public interface IObjectWithId<TId> where TId : IEquatable<TId> {
    TId Id { get; }
}