using CleanArchitecture.Dav.Domain.Entities;

namespace CleanArchitecture.Dav.Domain.Users.Entities;

/// <summary>
/// Représente un utilisateur au sens métier.
/// </summary>
public class User : BaseEntity
{
    public required string Nom { get; set; }

    public required string Prenom { get; set; }

    public required string Email { get; set; }
}
