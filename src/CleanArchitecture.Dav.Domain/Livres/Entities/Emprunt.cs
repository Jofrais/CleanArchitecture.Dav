namespace CleanArchitecture.Dav.Domain.Livres.Entities;

/// <summary>
/// Représente un emprunt d'un livre.
/// </summary>
public class Emprunt
{
    public Guid IdUtilisateur { get; set; }
    
    public DateTimeOffset DateEmprunt { get; set; }
    
    public DateTimeOffset? DateRetour { get; set; } 

    public bool EstEnCours => DateRetour == null;
    
    public static Emprunt Create(Guid idUtilisateur) => new()
    {
        IdUtilisateur = idUtilisateur,
        DateEmprunt = DateTimeOffset.UtcNow
    };
    
    public void Retour() => DateRetour = DateTimeOffset.UtcNow;
}