
using DDD.Domain.Entities;

namespace DDD.Application.Interfaces;

public interface IBaseServices<TDto, TEntity> where TEntity : Entity
{
    Task<TDto> GetById(Guid id);
    Task<IEnumerable<TDto>> GetAll();
    Task<TDto> Add(TDto obj);
    Task<TDto> Update(Guid id, TDto obj);
    Task Delete(Guid id);
}