using CleanArchitecture.Dav.Domain.Common.Repositories;
using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;

namespace CleanArchitecture.Dav.Domain.Utilisateurs.Repositories;

/// <summary>
/// Contrat de repository pour l'entité User.
/// </summary>
public interface IUtilisateurRepository : IBaseRepository<Utilisateur>
{
}
