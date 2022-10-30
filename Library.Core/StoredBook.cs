namespace Library.Domain;
/// <summary>
///     Stored book in library
/// </summary>
public sealed class StoredBook
{
    /// <summary>
    ///     Book model
    /// </summary>
    public Book Book { get; set; }
    /// <summary>
    ///     Count of stored books
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    ///     Get true if possible to take a book, otherwise false
    /// </summary>
    public bool IsPossibleToTakeBook => this.Count != 0;

    /// <summary>
    ///     Create default model of stored book
    /// </summary>
    /// <param name="book">
    ///     Book of model
    /// </param>
    /// <param name="count">
    ///     Book counts of model
    /// </param>
    public StoredBook(
        Book book, 
        int count)
    {
        Book = book;
        Count = count;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((StoredBook)obj);
    }
    public override int GetHashCode()
        => HashCode.Combine(Book, Count);
    public override string ToString()
        => "-------------------------------------------------------" + Environment.NewLine +
           $"Книга: " + Environment.NewLine +
           $"{Book} " + Environment.NewLine +
           $"Кількість: {Count} " + Environment.NewLine +
           "-------------------------------------------------------";

    /// <summary>
    ///     Equals strong typed implementation
    /// </summary>
    /// <param name="other">
    ///     Other stored book object
    /// </param>
    /// <returns>
    ///     Returns true if matching stored books are equals, otherwise false
    /// </returns>
    private bool Equals(StoredBook other)
    {
        return Book.Equals(other.Book) && Count == other.Count;
    }
}