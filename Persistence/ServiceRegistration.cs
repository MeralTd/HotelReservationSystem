using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("DBConnectionString")));

        services.AddScoped<IReservationHotelRepository, ReservationHotelRepository>();


        return services;
    }
}