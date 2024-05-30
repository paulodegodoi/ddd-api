using DDD.Domain.Entities;

namespace DDD.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<Customer> GetByDocument(string document);
    Task DisableCustomer(Guid id);
}