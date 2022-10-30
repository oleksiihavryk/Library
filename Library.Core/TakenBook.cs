namespace Library.Domain;
/// <summary>
///     Class of book what is taken from library
/// </summary>
public sealed class TakenBook
{
    /// <summary>
    ///     Which book is taken
    /// </summary>
    public Book Book { get; }
    /// <summary>
    ///     Date when book is taken
    /// </summary>
    public DateTime When { get; }
    /// <summary>
    ///     Reading room from which book is taken
    /// </summary>
    public ReadingRoom ReadingRoom { get; }

    /// <summary>
    ///     Create model of taken book
    /// </summary>
    /// <param name="book">
    ///     Book of model
    /// </param>
    /// <param name="when">
    ///     Time when book is taken of model
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room from which book is taken
    /// </param>
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
        => "-------------------------------------------------------" + Environment.NewLine +
           $"Книга: " + Environment.NewLine +
           $"{Book}, " + Environment.NewLine +
           $"Взята у: {When}, " + Environment.NewLine +
           $"Спеціалізація зали для читання: {ReadingRoom.Specialization}" + 
           Environment.NewLine +
           "-------------------------------------------------------";

    /// <summary>
    ///     Equals strong typed implementation
    /// </summary>
    /// <param name="other">
    ///     Other taken book object
    /// </param>
    /// <returns>
    ///     Returns true if matching taken books are equals, otherwise false
    /// </returns>
    private bool Equals(TakenBook other)
        => Book.Equals(other.Book) && When.Equals(other.When) && 
           ReadingRoom.Equals(other.ReadingRoom);
}