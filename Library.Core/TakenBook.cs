namespace Library.Domain;
public sealed class TakenBook
{
    public Book Book { get; }
    public DateTime When { get; }
    public ReadingRoom ReadingRoom { get; }

    public TakenBook(
        Book book, 
        ReadingRoom readingRoom,
        DateTime when)
    {
        Book = book;
        When = when;
        ReadingRoom = readingRoom;
    }

    public override bool Equals(object? obj)
        => ReferenceEquals(this, obj) || obj is TakenBook other && Equals(other);
    public override int GetHashCode()
        => HashCode.Combine(Book, When, ReadingRoom);

    public override string ToString()
        => $"Книга: " + Environment.NewLine +
           $"{Book}, " + Environment.NewLine +
           $"Взята у: {When}, " + Environment.NewLine +
           $"Спеціалізація зали для читання: {ReadingRoom.Specialization}";

    private bool Equals(TakenBook other)
        => Book.Equals(other.Book) && When.Equals(other.When) && 
           ReadingRoom.Equals(other.ReadingRoom);
}