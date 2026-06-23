using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;
using CleanArchitecture.Dav.Infrastructure.DbsContext.Livres;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Dav.Infrastructure.DbsContext;

public class CleanArchitectureDbContext : DbContext
{
    public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options) : base(options)
    {
    }

    public DbSet<Livre> Livres { get; set; }

    public DbSet<Utilisateur> Utilisateurs { get; set; }

    public DbSet<Emprunt> Emprunts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivreEntityTypeConfiguration).Assembly);
    }
}
