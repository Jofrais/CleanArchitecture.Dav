using CleanArchitecture.Dav.Application;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using CleanArchitecture.Dav.Infrastructure;
using CleanArchitecture.Dav.Presentation.EndpointsDefinitions;

namespace CleanArchitecture.Dav.Presentation;

public static class DependencyInjectionPresentation
{
    public static void AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureLayer(configuration);
        services.AddApplicationLayer();
        services.AddEndpointsDefinitions();
    }

    public static void RegisterEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpointDefinition>>();

        foreach (var endpoint in endpoints)
        {
            endpoint.RegisterEndpoints(app);
        }
    }

    private static void AddEndpointsDefinitions(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjectionPresentation))
            .AddClasses(classes => classes.AssignableTo(typeof(IEndpointDefinition)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
    }
}