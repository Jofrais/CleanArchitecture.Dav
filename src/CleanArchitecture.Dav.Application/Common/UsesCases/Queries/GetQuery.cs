using CleanArchitecture.Dav.Application.Common.Handlers;

namespace CleanArchitecture.Dav.Application.Common.UsesCases.Queries;

public record GetQuery<T> : IRequest<List<T>>;