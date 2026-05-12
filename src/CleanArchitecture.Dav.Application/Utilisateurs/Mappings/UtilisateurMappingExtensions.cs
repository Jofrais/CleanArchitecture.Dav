using CleanArchitecture.Dav.Application.Utilisateurs.Dtos;
using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;

namespace CleanArchitecture.Dav.Application.Utilisateurs.Mappings;

public static class UtilisateurMappingExtensions
{
    public static UtilisateurDto ToDto(this Utilisateur utilisateur)
    {
        return new UtilisateurDto
        {
            Id = utilisateur.Id,
            Nom = utilisateur.Nom,
            Prenom = utilisateur.Prenom,
            Email = utilisateur.Email
        };
    }
    
    public static List<UtilisateurDto> ToDto(this IEnumerable<Utilisateur> utilisateurs)
    {
        return utilisateurs.Select(u => u.ToDto()).ToList();
    }
}