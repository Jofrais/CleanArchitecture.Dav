using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Common.UsesCases.Queries;
using CleanArchitecture.Dav.Application.Livres.Dtos;
using CleanArchitecture.Dav.Application.Livres.Mappings;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Dav.Application.Livres.UseCases.Queries.GetLivres;

/// <summary>
/// Ce handler permet de récupérer tous les livres.
/// </summary>
public class GetLivresHandler : IRequestHandler<GetQuery<LivreDto>, List<LivreDto>>
{
    private readonly ILogger<GetLivresHandler> _logger;
    private readonly ILivreRepository _livreRepository;
    
    public GetLivresHandler(ILogger<GetLivresHandler> logger, ILivreRepository livreRepository)
    {
        _logger = logger;
        _livreRepository = livreRepository;
    }
    
    public async Task<List<LivreDto>> Handle(GetQuery<LivreDto> request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recherche de tous les livres.");
        var livres = await _livreRepository.Get();
        return livres.ToDto();
    }
}