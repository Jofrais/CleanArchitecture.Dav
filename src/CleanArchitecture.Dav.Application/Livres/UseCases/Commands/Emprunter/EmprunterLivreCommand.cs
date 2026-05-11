namespace CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Emprunter;

public record EmprunterLivreCommand(Guid IdLivre, Guid IdUtilisateur);