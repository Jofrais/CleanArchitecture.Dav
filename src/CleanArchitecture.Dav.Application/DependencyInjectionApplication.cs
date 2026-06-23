using CleanArchitecture.Dav.Application.Common.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Dav.Application;

public static class DependencyInjectionApplication
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddHandlers();
        //services.AddMockRepositories();
    }

    private static void AddHandlers(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjectionApplication))
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

/*    private static void AddMockRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjectionApplication))
            .AddClasses(classes => classes.Where(x => x.Name.EndsWith("MockRepository")))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
    }*/
}