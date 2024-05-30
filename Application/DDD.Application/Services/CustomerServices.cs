using AutoMapper;
using DDD.Application.Dtos;
using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;

namespace DDD.Application.Services;

public class CustomerServices : BaseServices<CustomerDto, Customer>, ICustomerServices
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public CustomerServices(
        IBaseRepository<Customer> baseRepository, 
        IMapper mapper, 
        ICustomerRepository customerRepository) : base(baseRepository, mapper)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> GetByDocument(string document)
    {
        try
        {
            var customer = await _customerRepository.GetByDocument(document);
            return _mapper.Map<CustomerDto>(customer);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DisableCustomer(Guid id)
    {
        try
        {
            await _customerRepository.DisableCustomer(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}