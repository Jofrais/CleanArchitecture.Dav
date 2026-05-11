namespace CleanArchitecture.Dav.Domain.Common.Entities;

public class BaseEntity
{
    /// <summary>
    /// L'identifiant unique de notre entité
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// La date de création de notre entité
    /// </summary>
    public DateTimeOffset DateCreation { get; set; }

    /// <summary>
    /// La date de modification de notre entité, à jour.
    /// </summary>

    public DateTimeOffset DateModification { get; set; }
}
