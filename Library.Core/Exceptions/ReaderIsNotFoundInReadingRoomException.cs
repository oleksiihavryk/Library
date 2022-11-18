using System.Collections;

namespace Library.Domain.Exceptions;

public class ReaderIsNotFoundInReadingRoomException : Exception
{
    private readonly ReadingRoom _readingRoom;
    private readonly Reader _reader;

    public override string Message => base.Message ??
                                      "Is passed reader is not register in this reading room";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Reading room"] = _readingRoom,
        ["Reader"] = _reader
    };

    public ReaderIsNotFoundInReadingRoomException(
        ReadingRoom readingRoom,
        Reader reader)
        : this(
            readingRoom,
            reader,
            message: null,
            inner: null)
    {
    }
    public ReaderIsNotFoundInReadingRoomException(
        ReadingRoom readingRoom,
        Reader reader,
        string? message)
        : this(
            readingRoom,
            reader,
            message,
            inner: null)
    {
    }
    public ReaderIsNotFoundInReadingRoomException(
        ReadingRoom readingRoom, 
        Reader reader,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _readingRoom = readingRoom;
        _reader = reader;
    }
}