using DDD.Application.Dtos;
using DDD.Domain.Entities;

namespace DDD.Application.Interfaces;

public interface ICustomerServices : IBaseServices<CustomerDto, Customer>
{
    Task<CustomerDto> GetByDocument(string document);
    Task DisableCustomer(Guid id);
}