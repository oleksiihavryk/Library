namespace Library.Domain;
public sealed class StoredBook
{
    public Book Book { get; set; }
    public int Count { get; set; }
    public bool IsPossibleToTakeBook => this.Count != 0;
    
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
        => $"Книга: " + Environment.NewLine +
           $"{Book} " + Environment.NewLine +
           $"Кількість: {Count} ";
    
    private bool Equals(StoredBook other)
    {
        return Book.Equals(other.Book) && Count == other.Count;
    }
}