namespace Library.Console.Exceptions;
/// <summary>
///     Unhandled state exception model
/// </summary>
internal class UnhandledStateException : Exception
{
    public override string Message => base.Message ??
                                      "Unhandled application state. " +
                                      "Look at stack trace to get more information. ";

    /// <summary>
    ///     Create default unhandled state exception with message
    /// </summary>
    /// <param name="message">
    ///     Message of exception
    /// </param>
    public UnhandledStateException(string? message = null)
        : base(message)
    {
    }
    /// <summary>
    ///     Create default unhandled state exception with message and inner exception
    /// </summary>
    /// <param name="message">
    ///     Message of exception
    /// </param>
    /// <param name="inner">
    ///     Inner exception
    /// </param>
    public UnhandledStateException(
        string? message, 
        Exception? inner = null)
        : base(message, inner)
    {
    }
}