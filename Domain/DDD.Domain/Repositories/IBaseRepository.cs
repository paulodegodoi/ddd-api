using DDD.Domain.Entities;

namespace DDD.Domain.Repositories;

public interface IBaseRepository<T> where T : Entity
{
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Add(T obj);
    Task<T> Update(Guid id, T obj);
    Task Delete(Guid id);
}