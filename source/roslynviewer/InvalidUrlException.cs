using System;

namespace roslynviewer;

internal class InvalidUrlException : Exception
{
    public InvalidUrlException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidUrlException(string message) : base(message)
    {
    }

    public InvalidUrlException()
    {
    }
}
