using System.Collections;

namespace Library.Domain.Exceptions;

public class StoredBookIsNotFoundInReadingRoomException : Exception
{
    private readonly Book _book;
    private readonly ReadingRoom _readingRoom;

    public override string Message => base.Message ?? 
                                      "Stored book in reading room by passed book is not found.";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Book"] = _book,
        ["Reading room"] = _readingRoom
    };

    public StoredBookIsNotFoundInReadingRoomException(
        Book book,
        ReadingRoom readingRoom)
        : this(
            book,
            readingRoom,
            message: null,
            inner: null)
    {
    }
    public StoredBookIsNotFoundInReadingRoomException(
        Book book,
        ReadingRoom readingRoom,
        string message)
        : this(
            book,
            readingRoom,
            message,
            inner: null)
    {
    }
    public StoredBookIsNotFoundInReadingRoomException(
        Book book, 
        ReadingRoom readingRoom,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _readingRoom = readingRoom;
        _book = book;
    }
}