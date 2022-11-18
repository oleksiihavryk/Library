using System.Collections;

namespace Library.Domain.Exceptions;

public class ReadingRoomIsFullException : Exception
{
    private readonly ReadingRoom _readingRoom;

    public override string Message => base.Message ??
                                      "Reading room is full.";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Reading room"] = _readingRoom
    };

    public ReadingRoomIsFullException(ReadingRoom readingRoom)
        : this(
            readingRoom,
            message: null,
            inner: null)
    {
    }
    public ReadingRoomIsFullException(
        ReadingRoom readingRoom,
        string? message)
        : this(
            readingRoom,
            message,
            inner: null)
    {
    }
    public ReadingRoomIsFullException(
        ReadingRoom readingRoom,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _readingRoom = readingRoom;
    }
}