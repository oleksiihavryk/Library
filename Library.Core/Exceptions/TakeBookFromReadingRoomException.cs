using System.Collections;

namespace Library.Domain.Exceptions;

public class TakeBookFromReadingRoomException : Exception
{
    private readonly Book _book;
    private readonly ReadingRoom _readingRoom;

    public override string Message => base.Message ?? 
                                      "Impossible take a book from reading room";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Book"] = _book,
        ["Reading room"] = _readingRoom
    };

    public TakeBookFromReadingRoomException(
        Book book,
        ReadingRoom readingRoom)
        : this(
            book,
            readingRoom,
            message: null,
            inner: null)
    {
    }
    public TakeBookFromReadingRoomException(
        Book book, 
        ReadingRoom readingRoom,
        string? message)
        : this(
            book,
            readingRoom,
            message,
            inner: null)
    {
    }
    public TakeBookFromReadingRoomException(
        Book book,
        ReadingRoom readingRoom,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _book = book;
        _readingRoom = readingRoom;
    }
}