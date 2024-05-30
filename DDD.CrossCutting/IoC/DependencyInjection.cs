using DDD.Application.Interfaces;
using DDD.Application.Mappings;
using DDD.Application.Services;
using DDD.Domain.Repositories;
using DDD.Infrastruture.Data;
using DDD.Infrastruture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddAutoMapper(typeof(EntityToDtoMapperProfile));
        
        // services
        services.AddScoped(typeof(IBaseServices<,>), typeof(BaseServices<,>));
        services.AddScoped<ICustomerServices, CustomerServices>();
        
        // repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}