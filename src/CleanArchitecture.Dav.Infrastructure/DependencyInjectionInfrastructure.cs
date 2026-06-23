using CleanArchitecture.Dav.Infrastructure.DbsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Dav.Infrastructure;

public static class DependencyInjectionInfrastructure
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var npgsqlConnectionString = configuration.GetConnectionString("npgsql");
        services.AddRepositories();
        services.AddDbContext<CleanArchitectureDbContext>(options =>
        {
            options.UseNpgsql(npgsqlConnectionString);
        });

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjectionInfrastructure))
            .AddClasses(classes => classes.Where(x => x.Name.EndsWith("RepositoryNpgsql")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    public static async Task MigrateDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CleanArchitectureDbContext>();
        await db.Database.MigrateAsync();

        await InsertDonnees(db);
    }

    private static async Task InsertDonnees(CleanArchitectureDbContext db)
    {
        var assembly = typeof(CleanArchitectureDbContext).Assembly;
        var resourceName = assembly.GetManifestResourceNames()
            .Single(n => n.EndsWith("insert.sql"));

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream!);
        var sql = await reader.ReadToEndAsync();
        await db.Database.ExecuteSqlRawAsync(sql);
    }
}
