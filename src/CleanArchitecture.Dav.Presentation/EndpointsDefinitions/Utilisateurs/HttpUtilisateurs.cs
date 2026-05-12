using CleanArchitecture.Dav.Application.Common.Handlers;
using CleanArchitecture.Dav.Application.Common.UsesCases.Queries;
using CleanArchitecture.Dav.Application.Utilisateurs.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CleanArchitecture.Dav.Presentation.EndpointsDefinitions.Utilisateurs;

public class HttpUtilisateurs : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGroup("/utilisateurs")
            .MapGet("/", GetAllUtilisateurs);
    }
    
    private static async Task<Ok<List<UtilisateurDto>>> GetAllUtilisateurs(IRequestHandler<GetQuery<UtilisateurDto>, List<UtilisateurDto>> handler)
    {
        var result = await handler.Handle(new GetQuery<UtilisateurDto>(), CancellationToken.None);
        return TypedResults.Ok(result);
    }
}