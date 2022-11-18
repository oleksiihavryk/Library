using System.Collections;
using Library.Domain;

namespace Library.Console.Exceptions;

internal class BookIsNotFoundInLibraryException : Exception
{
    private readonly Book _book;

    public override string Message => base.Message ??
                                      "Book is not found in library system.";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Book"] = _book
    };

    public BookIsNotFoundInLibraryException(Book book)
        : this(
            book,
            message: null,
            inner: null)
    {
    }
    public BookIsNotFoundInLibraryException(
        Book book,
        string? message)
        : this(
            book,
            message,
            inner: null)
    {
    }
    public BookIsNotFoundInLibraryException(
        Book book,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _book = book;
    }
}