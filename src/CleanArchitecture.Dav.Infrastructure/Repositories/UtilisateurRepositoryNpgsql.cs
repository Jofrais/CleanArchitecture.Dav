using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;
using CleanArchitecture.Dav.Domain.Utilisateurs.Repositories;
using CleanArchitecture.Dav.Infrastructure.DbsContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Dav.Infrastructure.Repositories;

public class UtilisateurRepositoryNpgsql : BaseRepository<Utilisateur>, IUtilisateurRepository
{
    public UtilisateurRepositoryNpgsql(CleanArchitectureDbContext cleanArchitectureDbContext) : base(cleanArchitectureDbContext)
    {
    }
}
