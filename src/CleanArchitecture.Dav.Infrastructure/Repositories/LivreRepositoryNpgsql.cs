using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using CleanArchitecture.Dav.Infrastructure.DbsContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Dav.Infrastructure.Repositories;

public class LivreRepositoryNpgsql : BaseRepository<Livre>, ILivreRepository
{
    public LivreRepositoryNpgsql(CleanArchitectureDbContext cleanArchitectureDbContext) : base(cleanArchitectureDbContext)
    {
    }
}
