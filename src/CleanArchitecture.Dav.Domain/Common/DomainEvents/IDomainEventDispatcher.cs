namespace CleanArchitecture.Dav.Domain.Common.DomainEvents;

/// <summary>
/// Dispatcher pour les domain events.
/// </summary>
public interface IDomainEventDispatcher
{
    /// <summary>
    /// Répartit tous les domain events.
    /// </summary>
    /// <param name="domainEvents"></param>
    /// <returns></returns>
    Task Dispatch(List<IDomainEvent> domainEvents);
}
