using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;

namespace DDD.Application.Services;

public class BaseServices<TDto, TEntity> : IBaseServices<TDto, TEntity> where TEntity : Entity
{
    private readonly IBaseRepository<TEntity> _baseRepository;
    private readonly IMapper _mapper;

    public BaseServices(IBaseRepository<TEntity> baseRepository, IMapper mapper)
    {
        _baseRepository = baseRepository;
        _mapper = mapper;
    }

    public async Task<TDto> GetById(Guid id)
    {
        try
        {
            var entity = await _baseRepository.GetById(id);
            var dto = _mapper.Map<TDto>(entity);
            return dto;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<TDto>> GetAll()
    {
        var entities = await _baseRepository.GetAll();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto> Add(TDto obj)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(obj);
            var responseEntity = await _baseRepository.Add(entity);
            return _mapper.Map<TDto>(responseEntity);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<TDto> Update(Guid id, TDto obj)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}