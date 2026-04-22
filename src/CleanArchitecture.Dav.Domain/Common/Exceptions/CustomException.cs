using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Dav.Domain.Common.Exceptions;

public class CustomException : Exception
{
    /// <summary>
    /// Le titre de l'exception, que l'on peut utiliser pour identifier un problème particulier
    /// </summary>
    public required string Titre { get; init; }

    public CustomException()
    {
        Titre = GetType().Name;
    }

    public CustomException(string message) : base(message)
    {
        Titre = GetType().Name;
    }

    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
        Titre = GetType().Name;
    }
}
