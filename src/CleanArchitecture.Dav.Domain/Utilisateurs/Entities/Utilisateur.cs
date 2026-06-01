using CleanArchitecture.Dav.Domain.Common.Entities;

namespace CleanArchitecture.Dav.Domain.Utilisateurs.Entities;

/// <summary>
/// Représente un utilisateur au sens métier.
/// </summary>
public class Utilisateur : BaseEntity
{
    public required string Nom { get; set; }

    public required string Prenom { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}
