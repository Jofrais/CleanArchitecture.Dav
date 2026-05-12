using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Livres.Dtos;

namespace CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Retourner;

public record RetournerLivreCommand(Guid IdLivre) : IRequest<LivreDto>;