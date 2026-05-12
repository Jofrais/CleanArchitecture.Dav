using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Common.UsesCases.Queries;
using CleanArchitecture.Dav.Application.Livres.Dtos;
using CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Emprunter;
using CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Retourner;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Dav.Presentation.EndpointsDefinitions.Livres;

public class HttpLivre : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGroup("livres")
            .MapGet("/", GetLivres);
            
        app.MapGroup("livres")
            .MapPost("/{id:guid}/emprunt", EmprunterLivre);
        
        app.MapGroup("livres")
            .MapPost("/{id:guid}/retour", RetournerLivre);       
    }

    private async Task<Ok<List<LivreDto>>> GetLivres(IRequestHandler<GetQuery<LivreDto>, List<LivreDto>> handler)
    {
        var livres = await handler.Handle(new GetQuery<LivreDto>(), CancellationToken.None);
        return TypedResults.Ok(livres);
    }
    
    private async Task<Ok<LivreDto>> EmprunterLivre( IRequestHandler<EmprunterLivreCommand, LivreDto> handler, [FromRoute] Guid id, [FromBody] EmprunterLivreRequest request)
    {
        var command = new EmprunterLivreCommand(id, request.IdUtilisateur);
        var livreDto = await handler.Handle(command, CancellationToken.None);
        return TypedResults.Ok(livreDto);
    }

    private async Task<Ok<LivreDto>> RetournerLivre(IRequestHandler<RetournerLivreCommand, LivreDto> handler,
        [FromRoute] Guid id)
    {
        var command = new RetournerLivreCommand(id);
        var livreDto = await handler.Handle(command, CancellationToken.None);
        return TypedResults.Ok(livreDto);       
    }
}