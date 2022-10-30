using Library.Domain.Exceptions;

namespace Library.Domain;

/// <summary>
///     Reading room of library
/// </summary>
public sealed class ReadingRoom
{
    /// <summary>
    ///     Reading room identifier (key)
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    ///     Reading room specialization 
    /// </summary>
    public string Specialization { get; set; }
    /// <summary>
    ///     Places count in reading room
    /// </summary>
    public int MaxPlacesCapacity { get; set; }
    /// <summary>
    ///     Readers of reading room
    /// </summary>
    public List<Reader> Readers { get; } = new List<Reader>();
    /// <summary>
    ///     Stored books in reading room
    /// </summary>
    public List<StoredBook> Books { get; } = new List<StoredBook>();
    /// <summary>
    ///     Get count of free places in reading room
    /// </summary>
    public int FreePlacesCount => this.MaxPlacesCapacity - this.Readers.Count;

    /// <summary>
    ///     Get unique books what readers take
    /// </summary>
    /// <returns>
    ///     Returns unique books what readers take
    /// </returns>
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

    /// <summary>
    ///     Create reading room 
    /// </summary>
    /// <param name="specialization">
    ///     Reading room specialization
    /// </param>
    /// <param name="maxPlacesCapacity">
    ///     Reading room capacity
    /// </param>
    public ReadingRoom(
        string specialization, 
        int maxPlacesCapacity)
    {
        Id = Guid.NewGuid();
        Specialization = specialization;
        MaxPlacesCapacity = maxPlacesCapacity;
    }

    /// <summary>
    ///     Add new reader to reading room
    /// </summary>
    /// <param name="firstName">
    ///     First name of reader
    /// </param>
    /// <param name="lastName">
    ///     Last name of reader
    /// </param>
    /// <param name="fatherName">
    ///     Father name of reader
    /// </param>
    /// <param name="phone">
    ///     Phone of reader
    /// </param>
    /// <param name="education">
    ///     Reader education
    /// </param>
    /// <param name="birthday">
    ///     Reader birthday
    /// </param>
    /// <returns>
    ///     Created reader in reading room
    /// </returns>
    /// <exception cref="CannotAddNewReaderException">
    ///     Occurred when reading room is already full
    /// </exception>
    public Reader AddNewReader(
        string firstName, 
        string lastName, 
        string fatherName, 
        string phone, 
        string education, 
        DateTime birthday)
    {
        if (Readers.Count >= MaxPlacesCapacity)
            throw new CannotAddNewReaderException();

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
    /// <summary>
    ///     Remove reader from reading room
    /// </summary>
    /// <param name="reader">
    ///     Reader model
    /// </param>
    /// <exception cref="ArgumentException">
    ///     Occurred when reader is not register in reading room
    /// </exception>
    public void RemoveReader(Reader reader)
    {
        if (Readers.Contains(reader))
            throw new ArgumentException(
                message: "Is passed reader is not register in this reading room");

        Readers.Remove(reader);
        reader.ReadingRoom = null;
    }
    /// <summary>
    ///     Add book to reading room
    /// </summary>
    /// <param name="book">
    ///     Book which was be stored
    /// </param>
    /// <param name="quantity">
    ///     Quantity of books which be added
    /// </param>
    public void AddBook(Book book, int quantity)
    {
        var sb = GetStoredBookByBook(book);
        if (sb == null)
        {
            Books.Add(new StoredBook(book, quantity));
        }
        else
        {
            checked
            {
                sb.Count += quantity;
            }
        }
    } 
    /// <summary>
    ///     Remove book from reading room
    /// </summary>
    /// <param name="book">
    ///     Stored book model
    /// </param>
    /// <param name="quantity">
    ///     Book quantity
    /// </param>
    /// <exception cref="ArgumentException">
    ///     Occurred when some argument is incorrect
    /// </exception>
    public void RemoveBook(Book book, int quantity)
    {
        var sb = GetStoredBookByBook(book);

        if (sb == null)
            throw new ArgumentException(
                message: "Book not found in this reading room",
                paramName: nameof(book));

        if (quantity < 0)
            throw new ArgumentException(
                message: "Quantity cannot be less than zero",
                paramName: nameof(quantity));

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
    /// <summary>
    ///     Get count of free books by author
    /// </summary>
    /// <param name="author">
    ///     Author name
    /// </param>
    /// <returns>
    ///     Returns count of free books by author
    /// </returns>
    public int GetCountOfFreeBooksByAuthor(string author) 
        => Books
            .Where(b => b.IsPossibleToTakeBook && 
                        b.Book.Author == author)
            .Sum(b => b.Count);
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
           => "-------------------------------------------------------" + Environment.NewLine +
              $"Спеціалізація: {Specialization}, " + Environment.NewLine +
              $"Вмістимість: {MaxPlacesCapacity}, " + Environment.NewLine +
              $"Кількість свободних місць: {FreePlacesCount}" + Environment.NewLine +
              "-------------------------------------------------------";

    /// <summary>
    ///     Equals strong typed implementation
    /// </summary>
    /// <param name="other">
    ///     Other reading room object
    /// </param>
    /// <returns>
    ///     Returns true if matching reading rooms are equals, otherwise false
    /// </returns>
    private bool Equals(ReadingRoom other)
        => Id.Equals(other.Id) && Specialization == other.Specialization &&
           MaxPlacesCapacity == other.MaxPlacesCapacity && 
           Readers.Equals(other.Readers) && Books.Equals(other.Books);
    /// <summary>
    ///     Get stored book by book or return null if not found
    /// </summary>
    /// <param name="book">
    ///     Finding book
    /// </param>
    /// <returns>
    ///     Return stored book or return null if not found
    /// </returns>
    private StoredBook? GetStoredBookByBook(Book book)
        => Books.FirstOrDefault(b => b.Book.Equals(book));
}