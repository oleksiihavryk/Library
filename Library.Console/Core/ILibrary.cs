using Library.Domain;

namespace Library.Console.Core;

/// <summary>
///     Default library functionality
/// </summary>
internal interface ILibrary
{
    /// <summary>
    ///     Library name
    /// </summary>
    string Name { get; }
    /// <summary>
    ///     All readers in library
    /// </summary>
    IEnumerable<Reader> Readers { get; }
    /// <summary>
    ///     All books in library
    /// </summary>
    IEnumerable<StoredBook> Books { get; }
    /// <summary>
    ///     All reading rooms in library
    /// </summary>
    IEnumerable<ReadingRoom> ReadingRooms { get; }

    /// <summary>
    ///     Get dictionary of readers and his taken books
    /// </summary>
    /// <returns>
    ///     Returns dictionary of readers and his taken books
    /// </returns>
    Dictionary<Reader, IEnumerable<TakenBook>> GetReadersAndHisTakenBooks();
    /// <summary>     Get reading rooms and free places count
    /// </summary
    /// <returns>
    ///     Reading rooms and free places count
    /// </returns>
    Dictionary<ReadingRoom, int> GetReadingRoomsAndFreePlacesCount();
    /// <summary>
    ///     Check if possible to take a book
    /// </summary>
    /// <param name="book">
    ///     Identifier of book
    /// </param>
    /// <returns>
    ///     Return true is book is possible take from reading room, otherwise false
    /// </returns>
    bool CheckIfPossibleToTakeBook(Book book);
    /// <summary>
    ///     Get count of free books in reading room in 
    /// </summary>
    /// <param name="author">
    ///     Author of searching
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room
    /// </param>
    /// <returns>
    ///     Count of free books searched by author in reading room
    /// </returns>
    int GetCountOfFreeBooksByAuthorInReadingRoom(string author, ReadingRoom readingRoom);
    /// <summary>
    ///     Get readers which taken books contained in only one example
    /// </summary>
    /// <returns>
    ///     Readers which taken books contained in only one example
    /// </returns>
    IEnumerable<Reader> GetReadersWhichTakenBooksContainedInOnlyOneSpecimen();
    /// <summary>
    ///     Get books with maximal rating
    /// </summary>
    /// <param name="topOf">
    ///     Count of books with maximal rating
    /// </param>
    /// <returns>
    ///     Books with maximal rating
    /// </returns>
    IEnumerable<Book> GetBooksWithMaximalRating(int topOf);
    /// <summary>
    ///     Add book to library and set special cypher into it
    /// </summary>
    /// <param name="name">
    ///     Book name
    /// </param>
    /// <param name="author">
    ///     Book author
    /// </param>
    /// <param name="date">
    ///     Book date
    /// </param>
    /// <param name="receiveDate">
    ///     Book receive date
    /// </param>
    /// <param name="count">
    ///     Count of books in library
    /// </param>
    /// <param name="rating">
    ///     Rating of book
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room where books will be contained
    /// </param>
    /// <returns>
    ///     Return added book to library
    /// </returns>
    Book AddBook(
        string name, 
        string author, 
        int rating,
        int count,
        DateTime date, 
        DateTime receiveDate,
        ReadingRoom readingRoom);
    /// <summary>
    ///     Add new books into library
    /// </summary>
    /// <param name="readingRoom">
    ///     Reading room where book is contain
    /// </param>
    /// <param name="book">
    ///     A book to which a quantity is added
    /// </param>
    /// <param name="count">
    ///     Count of books
    /// </param>
    void AddBook(
        ReadingRoom readingRoom,
        Book book,
        int count);
    /// <summary>
    ///     Remove book from system by identifier
    /// </summary>
    /// <param name="book">
    ///     Added book into system
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room where book is contain
    /// </param>
    void RemoveBook(
        ReadingRoom readingRoom,
        Book book);
    /// <summary>
    ///     Reduce quantity of books from library
    /// </summary>
    /// <param name="book">
    ///     Existed in library book
    /// </param>
    /// <param name="count">
    ///     Count of deleted books
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room where book is contain
    /// </param>
    void RemoveBook(
        ReadingRoom readingRoom,
        Book book,
        int count);
    /// <summary>
    ///     Register new reader into library
    /// </summary>
    /// <param name="firstName">
    ///     Reader first name
    /// </param>
    /// <param name="lastName">
    ///     Reader last name
    /// </param>
    /// <param name="fatherName">
    ///     Reader father name
    /// </param>
    /// <param name="phone">
    ///     Reader phone
    /// </param>
    /// <param name="education">
    ///     Reader education
    /// </param>
    /// <param name="birthday">
    ///     Reader birthday
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room identifier
    /// </param>
    Reader RegisterNewReader(
        string firstName,
        string lastName,
        string fatherName,
        string phone,
        string education,
        DateTime birthday,
        ReadingRoom readingRoom);
    /// <summary>
    ///     Remove reader by identifier from system
    /// </summary>
    /// <param name="reader">
    ///     Reader identifier
    /// </param>
    void RemoveReader(Reader reader);
    /// <summary>
    ///     Add new reading room into library
    /// </summary>
    /// <param name="specialization">
    ///     Specialization of reading room
    /// </param>
    /// <param name="maxPlacesCapacity">
    ///     Places capacity in reading room
    /// </param>
    /// <returns>
    ///     Returns added reading room 
    /// </returns>
    ReadingRoom AddNewReadingRoom(
        string specialization,
        int maxPlacesCapacity);
    /// <summary>
    ///     Remove reading room by identifier from library
    /// </summary>
    /// <param name="readingRoom">
    ///     Reading room
    /// </param>
    void RemoveReadingRoom(ReadingRoom readingRoom);
    /// <summary>
    ///     Take a book from library
    /// </summary>
    /// <param name="reader">
    ///     Reader which take a book
    /// </param>
    /// <param name="readingRoom">
    ///     Reading room from which reader take a book
    /// </param>
    /// <param name="book">
    ///     Taken book
    /// </param>
    /// <returns>
    ///     Taken book model
    /// </returns>
    TakenBook TakeBook(
        Reader reader,
        ReadingRoom readingRoom,
        Book book);
    /// <summary>
    ///     Return book to library
    /// </summary>
    /// <param name="reader">
    ///     Reader which return a book
    /// </param>
    /// <param name="book">
    ///     Returned book
    /// </param>
    /// <returns>
    ///     Returns stored book model
    /// </returns>
    StoredBook ReturnBook(
        Reader reader,
        TakenBook book);
}