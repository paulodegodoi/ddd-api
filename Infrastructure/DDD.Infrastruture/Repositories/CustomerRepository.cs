using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastruture.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Customer> GetByDocument(string document)
    {
        var customer = await _context.Customers.FirstAsync(c => c.Document.Equals(document)) ??
                       throw new NullReferenceException($"Customer não encontrado. Documento: {document}.");

        return customer;
    }

    public async Task DisableCustomer(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id) ??
                       throw new NullReferenceException($"Customer não encontrado. Id: {id}.");
        
        try
        {
            customer.IsActive = false;
            
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Não foi possível desativar o customer.");
        }
    }
}