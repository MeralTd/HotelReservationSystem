using Application.Pipelines.Transaction;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System.Reflection;

namespace Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assembly);
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddScoped<IMessageProducer, MessageProducer>();


        return services;
    }
}