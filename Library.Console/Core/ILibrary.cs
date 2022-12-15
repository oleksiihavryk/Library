using Library.Domain;

namespace Library.Console.Core;
internal interface ILibrary
{
    string Name { get; set; }
    IEnumerable<Reader> Readers { get; }
    IEnumerable<StoredBook> Books { get; }
    IEnumerable<ReadingRoom> ReadingRooms { get; }

    Dictionary<Reader, IEnumerable<TakenBook>> GetReadersAndHisTakenBooks();
    Dictionary<ReadingRoom, int> GetReadingRoomsAndFreePlacesCount();
    bool CheckIfPossibleToTakeBook(Book book);
    int GetCountOfFreeBooksByAuthorInReadingRoom(string author, ReadingRoom readingRoom);
    IEnumerable<Reader> GetReadersWhichTakenBooksContainedInOnlyOneSpecimen();
    IEnumerable<Book> GetBooksWithMaximalRating(int topOf);
    Book AddBook(
        string name, 
        string author, 
        int rating,
        int count,
        DateTime date, 
        DateTime receiveDate,
        ReadingRoom readingRoom);
    StoredBook AddBook(
        ReadingRoom readingRoom,
        Book book,
        int count);
    Reader RegisterNewReader(
        string firstName,
        string lastName,
        string fatherName,
        string phone,
        string education,
        DateTime birthday,
        ReadingRoom readingRoom);
    ReadingRoom AddNewReadingRoom(
        string specialization,
        int maxPlacesCapacity);
    void RemoveBook(
        ReadingRoom readingRoom,
        Book book);
    void RemoveBook(
        ReadingRoom readingRoom,
        Book book,
        int count);
    void RemoveReader(Reader reader);
    void RemoveReadingRoom(ReadingRoom readingRoom);
    TakenBook TakeBook(
        Reader reader,
        Book book);
    StoredBook ReturnBook(
        Reader reader,
        TakenBook book);
}