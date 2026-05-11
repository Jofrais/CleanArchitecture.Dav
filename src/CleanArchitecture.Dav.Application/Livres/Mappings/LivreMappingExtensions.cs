using CleanArchitecture.Dav.Application.Livres.Dtos;
using CleanArchitecture.Dav.Domain.Livres.Entities;

namespace CleanArchitecture.Dav.Application.Livres.Mappings;

/// <summary>
/// Classe de mapping pour les entités Livre et Emprunt
/// Nous pourrions utiliser Mapster ou AutoMapper, mais pour l'exemple, nous allons utiliser directement des classes d'extensions.
/// Il est important de noter que des packages comme Master ou AutoMapper peuvent simplifier le processus, mais au coût de masquer des erreurs de compilation.
/// Ici, si une erreur de mapping est détectée, ce sera à la compilation, ce qui facilite la détection et la résolution des problèmes.
/// </summary>
public static class LivreMappingExtensions
{
    public static LivreDto ToDto(this Livre livre)
    {
        return new LivreDto()
        {
            Titre = livre.Titre,
            Auteur = livre.Auteur,
            ISBN = livre.ISBN,
            Emprunt = livre.Emprunt?.ToDto(),
            HistoriqueEmprunts = livre.HistoriqueEmprunts?.Select(e => e.ToDto()).ToList() ?? []
        };
    }
    
    public static EmpruntDto ToDto(this Emprunt emprunt)
    {
        return new EmpruntDto()
        {
            DateEmprunt = emprunt.DateEmprunt,
            DateRetour = emprunt.DateRetour,
            IdUtilisateur = emprunt.IdUtilisateur   
        };
    }
}