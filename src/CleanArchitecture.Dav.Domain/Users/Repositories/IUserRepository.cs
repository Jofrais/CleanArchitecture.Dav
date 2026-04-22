using CleanArchitecture.Dav.Domain.Common.Repositories;
using CleanArchitecture.Dav.Domain.Users.Entities;

namespace CleanArchitecture.Dav.Domain.Users.Repositories;

/// <summary>
/// Contrat de repository pour l'entité User.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
}
