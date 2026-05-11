namespace CleanArchitecture.Dav.Application.Livres.Dtos;

public class EmpruntDto
{
    public Guid IdUtilisateur { get; set; }
    
    public DateTimeOffset DateEmprunt { get; set; }
    
    public DateTimeOffset? DateRetour { get; set; } 

    public bool EstEnCours => DateRetour == null;
}