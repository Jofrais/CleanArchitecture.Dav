using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Common.UsesCases.Queries;
using CleanArchitecture.Dav.Application.Utilisateurs.Dtos;
using CleanArchitecture.Dav.Application.Utilisateurs.Mappings;
using CleanArchitecture.Dav.Domain.Utilisateurs.Repositories;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Dav.Application.Utilisateurs.UseCases.Queries.GetUtilisateurs;

public class GetUtilisateursHandler : IRequestHandler<GetQuery<UtilisateurDto>, List<UtilisateurDto>>
{
    private readonly ILogger<GetUtilisateursHandler> _logger;
    private readonly IUtilisateurRepository _utilisateurRepository;
    
    public GetUtilisateursHandler(ILogger<GetUtilisateursHandler> logger, IUtilisateurRepository utilisateurRepository)
    {
        _logger = logger;
        _utilisateurRepository = utilisateurRepository;
    }
    
    public async Task<List<UtilisateurDto>> Handle(GetQuery<UtilisateurDto> request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Récupération de tous les utilisateurs.");
        var utilisateurs = await _utilisateurRepository.Get();
        return utilisateurs.ToDto();
    }
}