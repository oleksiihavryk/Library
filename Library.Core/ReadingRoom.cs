using Library.Domain.Exceptions;

namespace Library.Domain;
public sealed class ReadingRoom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Specialization { get; set; }
    public int MaxPlacesCapacity { get; set; }
    public List<Reader> Readers { get; } = new List<Reader>();
    public List<StoredBook> Books { get; } = new List<StoredBook>();
    public int FreePlacesCount => this.MaxPlacesCapacity - this.Readers.Count;
    public IEnumerable<StoredBook> GetBooksWhichStoredOnlyInOneSpecimen
        => Books
            .Where(sb =>
                (sb.Count == 1 && Readers
                    .Any(r => r.Books
                        .Select(tb => tb.Book)
                        .Contains(sb.Book)) == false) ||
                sb.Count == 0 && Readers
                    .SelectMany(r => r.Books)
                    .Count(tb => tb.Book.Equals(sb.Book)) == 1);

    public ReadingRoom(
        string specialization, 
        int maxPlacesCapacity)
    {
        Specialization = specialization;
        MaxPlacesCapacity = maxPlacesCapacity;
    }

    public Reader AddNewReader(
        string firstName, 
        string lastName, 
        string fatherName, 
        string phone, 
        string education, 
        DateTime birthday)
    {
        if (Readers.Count >= MaxPlacesCapacity)
            throw new ReadingRoomIsFullException(readingRoom: this);

        var r = new Reader(
            firstName,
            lastName,
            fatherName,
            phone,
            education,
            birthday,
            readingRoom: this);
        Readers.Add(r);

        return r;
    }
    public void RemoveReader(Reader reader)
    {
        if (Readers.Contains(reader))
            throw new ReaderIsNotFoundInReadingRoomException(
                readingRoom: this, 
                reader);

        Readers.Remove(reader);
        reader.ReadingRoom = null;
    }
    public void AddBook(Book book, int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException(
                message: "Quantity cannot be less than zero",
                paramName: nameof(quantity));

        try
        {
            var sb = GetStoredBookByBook(book);
            checked
            {
                sb.Count += quantity;
            }
        }
        catch (StoredBookIsNotFoundInReadingRoomException)
        {
            Books.Add(new StoredBook(book, quantity));
        }
    }
    public void RemoveBook(Book book, int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException(
                message: "Quantity cannot be less than zero",
                paramName: nameof(quantity));

        var sb = GetStoredBookByBook(book);

        if (sb.Count >= quantity)
        {
            checked
            {
                sb.Count -= quantity;
            }
        }
        else
        {
            Books.Remove(sb);
        }
    }
    public int GetCountOfFreeBooksByAuthor(string author) 
        => Books
            .Where(b => b.IsPossibleToTakeBook && 
                        b.Book.Author == author)
            .Sum(b => b.Count);
    public StoredBook GetStoredBookByBook(Book book)
        => Books.FirstOrDefault(b => b.Book.Equals(book)) ?? 
           throw new StoredBookIsNotFoundInReadingRoomException(book, readingRoom: this);
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ReadingRoom)obj);
    }
    public override int GetHashCode()
        => HashCode.Combine(Id, Specialization, MaxPlacesCapacity, Readers, Books);
    public override string ToString()
        => $"Спеціалізація: {Specialization}, " + Environment.NewLine +
           $"Вмістимість: {MaxPlacesCapacity}, " + Environment.NewLine +
           $"Кількість свободних місць: {FreePlacesCount}";

    private bool Equals(ReadingRoom other)
        => Id.Equals(other.Id) && Specialization == other.Specialization &&
           MaxPlacesCapacity == other.MaxPlacesCapacity && 
           Readers.Equals(other.Readers) && Books.Equals(other.Books);
}