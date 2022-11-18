namespace Library.Console.Exceptions;
internal class UnhandledStateException : Exception
{
    public override string Message => base.Message ??
                                      "Unhandled application state. " +
                                      "Look at stack trace to get more information. ";

    public UnhandledStateException(string? message = null)
        : base(message)
    {
    }
    public UnhandledStateException(
        string? message, 
        Exception? inner = null)
        : base(message, inner)
    {
    }
}