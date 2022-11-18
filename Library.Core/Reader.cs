using Library.Domain.Exceptions;

namespace Library.Domain;
public sealed class Reader
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public string Education { get; set; }
    public List<TakenBook> Books { get; } = new List<TakenBook>();
    public ReadingRoom? ReadingRoom { get; set; }

    public Reader(
        string firstName, 
        string lastName, 
        string fatherName, 
        string phone, 
        string education, 
        DateTime birthday, 
        ReadingRoom readingRoom)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        FatherName = fatherName;
        Birthday = birthday;
        Phone = phone;
        Education = education;
        ReadingRoom = readingRoom;
    }

    public bool IsTakeOneOfPassedBooks(IEnumerable<Book> books)
        => Books
            .Select(b => b.Book)
            .Any(books.Contains);
    public TakenBook TakeBook(
        ReadingRoom readingRoom,
        Book book)
    {
        try
        {
            var sb = readingRoom.GetStoredBookByBook(book);

            if (sb.Count <= 0)
                throw new TakeBookFromReadingRoomException(
                    book,
                    readingRoom,
                    message: "You cannot take chosen book because " +
                             "all this type books is already taken.");

            checked
            {
                --sb.Count;
            }

            var tb = new TakenBook(book, readingRoom, DateTime.Now);
            Books.Add(tb);

            return tb;
        }
        catch (StoredBookIsNotFoundInReadingRoomException ex)
        {
            throw new TakeBookFromReadingRoomException(
                book,
                readingRoom,
                message: "See inner exception message to get more information about error.",
                inner: ex);
        }
    } 
    public StoredBook ReturnBook(TakenBook takenBook)
    {
        if (ReaderIsContainTakenBook(takenBook))
        {
            var book = takenBook.Book;
            StoredBook? sb = null;

            try
            {
                sb = takenBook.ReadingRoom.GetStoredBookByBook(book);
                checked
                {
                    ++sb.Count;
                }
            }
            catch (StoredBookIsNotFoundInReadingRoomException)
            {
                var newStoredBook = new StoredBook(takenBook.Book, 1);
                takenBook.ReadingRoom.Books.Add(newStoredBook);
                sb = newStoredBook;
            }

            Books.Remove(takenBook);

            return sb;
        }

        throw new TakenBookIsNotFoundInReaderException(
            takenBook,
            reader: this);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Reader)obj);
    }
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(FirstName);
        hashCode.Add(LastName);
        hashCode.Add(FatherName);
        hashCode.Add(Birthday);
        hashCode.Add(Phone);
        hashCode.Add(Education);
        hashCode.Add(Books);
        hashCode.Add(ReadingRoom);
        return hashCode.ToHashCode();
    }
    public override string ToString()
        => $"Ім'я: {FirstName}, " + Environment.NewLine +
           $"Фамілія: {LastName}, " + Environment.NewLine +
           $"По батькові: {FatherName}, " + Environment.NewLine +
           $"Телефон: {Phone}, " + Environment.NewLine +
           $"Освіта: {Education}, ";

    private bool Equals(Reader other)
        => Id.Equals(other.Id) && FirstName == other.FirstName && 
           LastName == other.LastName && FatherName == other.FatherName && 
           Birthday.Equals(other.Birthday) && Phone == other.Phone && 
           Education == other.Education && Books.Equals(other.Books) && 
           Equals(ReadingRoom, other.ReadingRoom);
    
    private bool ReaderIsContainTakenBook(TakenBook takenBook)
        => Books.Any(tb => tb.Equals(takenBook));
}