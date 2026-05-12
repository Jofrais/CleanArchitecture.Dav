using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Livres.Dtos;
using CleanArchitecture.Dav.Application.Livres.Mappings;
using CleanArchitecture.Dav.Domain.Common.Exceptions;
using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Retourner;

public class RetournerLivreHandler : IRequestHandler<RetournerLivreCommand, LivreDto>
{
    private readonly ILogger<RetournerLivreHandler> _logger;
    private readonly ILivreRepository _livreRepository;

    public RetournerLivreHandler(ILogger<RetournerLivreHandler> logger, ILivreRepository livreRepository)
    {
        _logger = logger;
        _livreRepository = livreRepository;
    }

    public async Task<LivreDto> Handle(RetournerLivreCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Le livre avec l'ID {IdLivre} a été retourné.", request.IdLivre);

        var livre = await _livreRepository.GetById(request.IdLivre)
                    ?? throw new EntityNotFoundException<Livre>(request.IdLivre);
        
        livre.Retourner();
        
        await _livreRepository.Update(livre);

        return livre.ToDto();
    }
}