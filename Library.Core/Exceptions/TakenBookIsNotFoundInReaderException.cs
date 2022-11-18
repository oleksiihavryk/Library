using System.Collections;

namespace Library.Domain.Exceptions;

public class TakenBookIsNotFoundInReaderException : Exception
{
    private readonly TakenBook _takenBook;
    private readonly Reader _reader;

    public override string Message => base.Message ??
                                      "Taken book is not contained in reader";
    public override IDictionary Data => new Dictionary<string, object>()
    {
        ["Taken book"] = _takenBook,
        ["Reader"] = _reader
    };

    public TakenBookIsNotFoundInReaderException(
        TakenBook takenBook,
        Reader reader)
        : this(
            takenBook,
            reader,
            message: null,
            inner: null)
    {
    }
    public TakenBookIsNotFoundInReaderException(
        TakenBook takenBook,
        Reader reader,
        string? message)
        : this(
            takenBook,
            reader,
            message,
            inner: null)
    {
    }
    public TakenBookIsNotFoundInReaderException(
        TakenBook takenBook,
        Reader reader,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _takenBook = takenBook;
        _reader = reader;
    }
}