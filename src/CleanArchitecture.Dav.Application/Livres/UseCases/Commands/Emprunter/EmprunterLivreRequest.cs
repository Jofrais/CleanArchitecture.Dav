namespace CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Emprunter;

/// <summary>
/// On utilise cette classe pour le body JSON.
/// </summary>
public class EmprunterLivreRequest
{
    public Guid IdUtilisateur { get; init; }
}