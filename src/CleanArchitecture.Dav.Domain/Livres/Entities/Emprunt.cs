using CleanArchitecture.Dav.Domain.Common.Entities;

namespace CleanArchitecture.Dav.Domain.Livres.Entities;

/// <summary>
/// Représente un emprunt d'un livre.
/// </summary>
public class Emprunt : BaseEntity
{
    public Guid IdUtilisateur { get; set; }

    public Guid IdLivre { get; set; }
    
    public DateTimeOffset DateEmprunt { get; set; }
    
    public DateTimeOffset? DateRetour { get; set; } 

    public bool EstEnCours => DateRetour == null;
    
    public static Emprunt Create(Guid idLivre, Guid idUtilisateur) => new()
    {
        IdLivre = idLivre,
        IdUtilisateur = idUtilisateur,
        DateEmprunt = DateTimeOffset.UtcNow
    };
    
    public void Retour() => DateRetour = DateTimeOffset.UtcNow;
}