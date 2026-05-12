using CleanArchitecture.Dav.Domain.Common.Entities;
using CleanArchitecture.Dav.Domain.Livres.Exceptions;

namespace CleanArchitecture.Dav.Domain.Livres.Entities;

/// <summary>
/// Représente un livre dans la bibliothèque.
/// </summary>
public class Livre : BaseEntity
{
    public required string Titre { get; set; }
    
    public required string Auteur { get; set; }
    
    public required string ISBN { get; set; }
    
    public Emprunt? Emprunt { get; set; }
    
    public List<Emprunt> HistoriqueEmprunts { get; set; } = new();
    
    public bool EstEmprunter => Emprunt != null;
    
    public void Emprunter(Guid idUtilisateur)
    {
        if(EstEmprunter)
            throw new EmpruntException($"Impossible d'emprunter le livre '{Titre}', celui-ci est déjà emprunté.");
        
        var emprunt = Emprunt.Create(idUtilisateur);
        Emprunt = emprunt;
    }

    public void Retourner()
    {
        if (!EstEmprunter)
            throw new EmpruntException($"Impossible de rendre le livre : '{Titre}', celui-ci n'est pas emprunté.");
        
        Emprunt!.DateRetour = DateTimeOffset.UtcNow;
        HistoriqueEmprunts.Add(Emprunt!);
        Emprunt = null;
    }
}