using Library.Console.Exceptions;
using Library.Domain;

namespace Library.Console.Core;
internal class Library : ILibrary
{
    private readonly List<ReadingRoom> _readingRooms = new List<ReadingRoom>();
    
    public string Name { get; set; }
    public IEnumerable<Reader> Readers => _readingRooms.SelectMany(rr => rr.Readers);
    public IEnumerable<StoredBook> Books => _readingRooms.SelectMany(rr => rr.Books);
    public IEnumerable<ReadingRoom> ReadingRooms => _readingRooms;

    internal Library(string name)
    {
        Name = name;
    }

    public Dictionary<Reader, IEnumerable<TakenBook>> GetReadersAndHisTakenBooks()
        => Readers
            .ToDictionary(
                keySelector: r => r, 
                elementSelector: r => r.Books.AsEnumerable());
    public Dictionary<ReadingRoom, int> GetReadingRoomsAndFreePlacesCount()
        => _readingRooms
            .ToDictionary(
                keySelector: rr => rr,
                elementSelector: rr => rr.FreePlacesCount);
    public bool CheckIfPossibleToTakeBook(Book book)
    {
        try
        {
            return CheckIfContainedInLibraryAndReturnsStoredValue(book).IsPossibleToTakeBook;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
    public int GetCountOfFreeBooksByAuthorInReadingRoom(
    string author, 
    ReadingRoom readingRoom) 
        => CheckIfContainedInLibraryAndReturnsStoredValue(readingRoom)
            .GetCountOfFreeBooksByAuthor(author);
    public IEnumerable<Reader> GetReadersWhichTakenBooksContainedInOnlyOneSpecimen()
    {
        var oneSpecimenBooks = _readingRooms
            .SelectMany(r => r.GetBooksWhichStoredOnlyInOneSpecimen)
            .Select(b => b.Book);

        return Readers
            .Where(r => r.IsTakeOneOfPassedBooks(oneSpecimenBooks))
            .ToArray();
    } 
    public IEnumerable<Book> GetBooksWithMaximalRating(int topOf)
        => Books
            .OrderByDescending(b => b.Book.Rating)
            .Take(topOf)
            .Select(b => b.Book)
            .ToArray();
    public Book AddBook(
        string name, 
        string author, 
        int rating,
        int count,
        DateTime date, 
        DateTime receiveDate,
        ReadingRoom readingRoom)
    {
        var code = name
            .Replace(" ", "")
            .ToUpper()
            .Substring(0, name.Length > 10 ? 10 : name.Length);
        var book = new Book(name, author, code, date, receiveDate)
        {
            Rating = rating
        };
        readingRoom.AddBook(book, quantity: count);
        return book;
    }
    public StoredBook AddBook(
        ReadingRoom readingRoom,
        Book book, 
        int count)
    {
        var b = CheckIfContainedInLibraryAndReturnsStoredValue(book);

        checked
        {
            b.Count += count;
        }

        return b;
    }
    public void RemoveBook(
        ReadingRoom readingRoom, 
        Book book)
    {
        var storedBook = CheckIfContainedInLibraryAndReturnsStoredValue(book);
        readingRoom.RemoveBook(book, storedBook.Count);
    }
    public void RemoveBook(
        ReadingRoom readingRoom, 
        Book book, 
        int count)
    {
        var storedBook = CheckIfContainedInLibraryAndReturnsStoredValue(book);

        if (count <= 0)
            throw new ArgumentException(
                paramName: nameof(count),
                message: "Count of removed books cannot be less or equals zero.");

        if (count > storedBook.Count)
            RemoveBook(readingRoom, storedBook.Book);
        else storedBook.Count -= count;
    }
    public Reader RegisterNewReader(
        string firstName, 
        string lastName,
        string fatherName, 
        string phone, 
        string education,
        DateTime birthday, 
        ReadingRoom readingRoom)
    {
        var rr = CheckIfContainedInLibraryAndReturnsStoredValue(readingRoom);
        var r = rr.AddNewReader(
            firstName,
            lastName,
            fatherName,
            phone,
            education,
            birthday);
        return r;
    }
    public void RemoveReader(Reader reader)
    {
        var r = CheckIfContainedInLibraryAndReturnsStoredValue(reader);
        var rr = r.ReadingRoom;
            
        rr?.RemoveReader(r);
    }
    public ReadingRoom AddNewReadingRoom(
        string specialization, 
        int maxPlacesCapacity)
    {
        var rr = new ReadingRoom(specialization, maxPlacesCapacity);
        _readingRooms.Add(rr);
        return rr;
    }
    public void RemoveReadingRoom(ReadingRoom readingRoom)
    {
        var rr = CheckIfContainedInLibraryAndReturnsStoredValue(readingRoom);
        _readingRooms.Remove(rr);
    }
    public TakenBook TakeBook(
        Reader reader, 
        ReadingRoom readingRoom,
        Book book)
        => reader.TakeBook(readingRoom, book);
    public StoredBook ReturnBook(
        Reader reader,
        TakenBook book)
        => reader.ReturnBook(book);

    private ReadingRoom CheckIfContainedInLibraryAndReturnsStoredValue(ReadingRoom readingRoom)
        => _readingRooms
               .FirstOrDefault(rr => rr.Equals(readingRoom)) ?? 
           throw new ReadingRoomIsNotFoundInLibraryException(readingRoom);
    private StoredBook CheckIfContainedInLibraryAndReturnsStoredValue(Book book)
        => Books
               .FirstOrDefault(sb => sb.Book.Equals(book)) ??
           throw new BookIsNotFoundInLibraryException(book);
    private Reader CheckIfContainedInLibraryAndReturnsStoredValue(Reader reader)
        => _readingRooms
               .SelectMany(c => c.Readers)
               .FirstOrDefault(r => r.Equals(reader)) ?? 
           throw new ReaderIsNotFoundInLibraryException(reader);
}