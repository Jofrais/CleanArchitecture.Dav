using CleanArchitecture.Dav.Application.Common.UsesCases.Dtos;

namespace CleanArchitecture.Dav.Application.Utilisateurs.Dtos;

public class UtilisateurDto : BaseDto
{
    public required string Nom { get; set; }

    public required string Prenom { get; set; }

    public required string Email { get; set; }
}