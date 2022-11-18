using System.Collections;
using Library.Domain;

namespace Library.Console.Exceptions;
internal class ReaderIsNotFoundInLibraryException : Exception
{
    private readonly Reader _reader;

    public override string Message => base.Message ??
                                      "Reader is not found in library system.";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Reader"] = _reader
    };

    public ReaderIsNotFoundInLibraryException(Reader reader)
        : this(
            reader,
            message: null,
            inner: null)
    {
    }
    public ReaderIsNotFoundInLibraryException(
        Reader reader,
        string? message)
        : this(
            reader,
            message,
            inner: null)
    {
    }
    public ReaderIsNotFoundInLibraryException(
        Reader reader,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _reader = reader;
    }
}