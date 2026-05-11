using CleanArchitecture.Dav.Domain.Common.Entities;

namespace CleanArchitecture.Dav.Domain.Common.Exceptions;

/// <summary>
/// Exception levée lorsqu'une entité métier n'est pas trouvée.
/// </summary>
/// <typeparam name="T">Le type de l'entité métier.</typeparam>
public class EntityNotFoundException<T> : NotFoundException
    where T : BaseEntity
{
    public EntityNotFoundException(Guid id) : base($"L'entité de type {typeof(T).Name} avec l'identifiant {id} est introuvable.") { } 
}
