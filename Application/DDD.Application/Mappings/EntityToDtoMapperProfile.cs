using AutoMapper;
using DDD.Application.Dtos;
using DDD.Domain.Entities;

namespace DDD.Application.Mappings;

public class EntityToDtoMapperProfile : Profile
{
    public EntityToDtoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}