namespace Library.Domain.Exceptions;

/// <summary>
///     Cannot add new reader exception model
/// </summary>
public class CannotAddNewReaderException : Exception
{
    public override string Message => base.Message ??
                                      "Cannot add new reader into library. " +
                                      "Check stack trace to get more information about exception.";

    /// <summary>
    ///     Create default exception with message
    /// </summary>
    /// <param name="message">
    ///     Message of exception
    /// </param>
    public CannotAddNewReaderException(string? message = null)
        : base(message)
    {
    }
    /// <summary>
    ///     Create default exception with message and inner exception
    /// </summary>
    /// <param name="message">
    ///     Message of exception
    /// </param>
    /// <param name="inner">
    ///     Inner of exception
    /// </param>
    public CannotAddNewReaderException(string? message, Exception? inner = null)
        : base(message, inner)
    {
    }
}