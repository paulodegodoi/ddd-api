using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastruture.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Add(T obj)
    {
        await _context.Set<T>().AddAsync(obj);
        return await _context.Set<T>().FindAsync(obj.Id);
    }

    public async Task<T> Update(Guid id, T obj)
    {
        if (await _context.Set<T>().AnyAsync(x => x.Id == id) == false)
        {
            throw new Exception($"Nenhuma entidade foi encontrada com id: {id}.");
        }

        try
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        catch (Exception e)
        {
            throw new Exception("Não foi possível atualizar a entidade.");
        }
    }

    public async Task Delete(Guid id)
    {
        var objFound = await _context.Set<T>().FindAsync(id) ?? 
                       throw new NullReferenceException($"Nenhuma entidade foi encontrada com id: {id}.");
        
        try
        {
            _context.Set<T>().Remove(objFound);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Não foi possível remover a entidade.");
        }
    }
}