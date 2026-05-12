namespace CleanArchitecture.Dav.Application.Common.Handlers;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}