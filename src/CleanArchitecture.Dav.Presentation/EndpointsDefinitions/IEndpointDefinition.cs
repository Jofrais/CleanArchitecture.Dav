namespace CleanArchitecture.Dav.Presentation.EndpointsDefinitions;

public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}