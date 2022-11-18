using System.Collections;
using Library.Domain;

namespace Library.Console.Exceptions;

internal class ReadingRoomIsNotFoundInLibraryException : Exception
{
    private readonly ReadingRoom _readingRoom;

    public override string Message => base.Message ??
                                      "Reading room is not found in library system";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Reading room"] = _readingRoom
    };

    public ReadingRoomIsNotFoundInLibraryException(ReadingRoom readingRoom)
        : this(
            readingRoom,
            message: null,
            inner: null)
    {
    }
    public ReadingRoomIsNotFoundInLibraryException(
        ReadingRoom readingRoom,
        string? message)
        : this(
            readingRoom,
            message,
            inner: null)
    {
    }
    public ReadingRoomIsNotFoundInLibraryException(
        ReadingRoom readingRoom,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _readingRoom = readingRoom;
    }
}