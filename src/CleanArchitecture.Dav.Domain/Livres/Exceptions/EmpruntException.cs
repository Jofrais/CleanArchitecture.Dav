using CleanArchitecture.Dav.Domain.Common.Exceptions;

namespace CleanArchitecture.Dav.Domain.Livres.Exceptions;

public class EmpruntException : CustomException
{
    public EmpruntException(string message) : base(message) { }
}