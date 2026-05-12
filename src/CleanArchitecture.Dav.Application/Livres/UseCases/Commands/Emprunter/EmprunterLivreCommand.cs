using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Livres.Dtos;

namespace CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Emprunter;

public record EmprunterLivreCommand(Guid IdLivre, Guid IdUtilisateur) : IRequest<LivreDto>;