namespace CleanArchitecture.Dav.Domain.Common.Exceptions;

/// <summary>
/// Représente une exception où un objet n'a pas été trouvé.
/// </summary>
public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message,  Exception innerException) : base(message, innerException) { }
}
