namespace Library.Domain;
/// <summary>
///     Reader model
/// </summary>
public sealed class Reader
{
    /// <summary>
    ///     Reader identifier (key)
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    ///     Reader first name
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    ///     Reader last name
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    ///     Reader father name
    /// </summary>
    public string FatherName { get; set; }
    /// <summary>
    ///     Reader birthday 
    /// </summary>
    public DateTime Birthday { get; set; }
    /// <summary>
    ///     Reader phone
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    ///     Reader education
    /// </summary>
    public string Education { get; set; }
    /// <summary>
    ///     Books which reader have (taken from library)
    /// </summary>
    public List<TakenBook> Books { get; } = new List<TakenBook>();
    /// <summary>
    ///     Reading room where reader is registered
    /// </summary>
    public ReadingRoom? ReadingRoom { get; set; }

    /// <summary>
    ///     Create default model of reader
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
    ///     Phone number of reader
    /// </param>
    /// <param name="education">
    ///     Reader education (set in single string)
    /// </param>
    /// <param name="birthday">
    ///     Reader birthdate
    /// </param>
    /// <param name="readingRoom">
    ///     Reader reading room
    /// </param>
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

    /// <summary>
    ///     Check if user take on of passed books
    /// </summary>
    /// <param name="books">
    ///     Some books model
    /// </param>
    /// <returns>
    ///     Returns true if user take on of passed books, otherwise false
    /// </returns>
    public bool IsTakeOneOfPassedBooks(IEnumerable<Book> books)
        => Books
            .Select(b => b.Book)
            .Any(books.Contains);
    /// <summary>
    ///     Take book from passed reading room
    /// </summary>
    /// <param name="readingRoom">
    ///     Reading room
    /// </param>
    /// <param name="book">
    ///     Taken book
    /// </param>
    /// <returns>
    ///     Return taken book
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Occurred when passed book in reading room is not found
    /// </exception>
    public TakenBook TakeBook(
        ReadingRoom readingRoom,
        Book book)
    {
        var sb = readingRoom
            .Books
            .FirstOrDefault(b => b.Book.Equals(book));

        if (sb == null)
            throw new ArgumentException(
                paramName: nameof(book),
                message: "Stored book in reading room by passed book is not found.");

        if (sb.Count <= 0)
            throw new ArgumentException(
                message: "You cannot take chosen book because all " +
                         "this type books is already taken.",
                paramName: nameof(book));

        --sb.Count;
        var tb = new TakenBook(book, readingRoom, DateTime.Now);
        Books.Add(tb);
        
        return tb;
    }
    /// <summary>
    ///     Return book to reading room 
    /// </summary>
    /// <param name="takenBook">
    ///     Book which taken from reading room
    /// </param>
    /// <returns>
    ///     Returns stored book in reading room
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Occurred when passed taken book is not own to current reader
    /// </exception>
    public StoredBook ReturnBook(
        TakenBook takenBook)
    {
        var bookIn = Books.Any(tb => tb.Equals(takenBook));

        if (!bookIn)
            throw new ArgumentException(
                message: "Passed taken taken book is not contained in reader",
                paramName: nameof(takenBook));

        var sb = takenBook.ReadingRoom
            .Books
            .FirstOrDefault(b => b.Book.Equals(takenBook.Book));

        if (sb == null)
        {
            var newStoredBook = new StoredBook(takenBook.Book, 1);
            takenBook.ReadingRoom.Books.Add(newStoredBook);
            sb = newStoredBook;
        }
        else
        {
            ++sb.Count;
        }

        Books.Remove(takenBook);

        return sb;
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
        => "-------------------------------------------------------" + Environment.NewLine +
           $"Ім'я: {FirstName}, " + Environment.NewLine + 
           $"Фамілія: {LastName}, " + Environment.NewLine +
           $"По батькові: {FatherName}, " + Environment.NewLine +
           $"Народився у: {Birthday}, " + Environment.NewLine +
           $"Телефон: {Phone}, " + Environment.NewLine +
           $"Освіта: {Education}, " + Environment.NewLine +
           $"Спеціалізація зали для читання: {ReadingRoom?.Specialization ?? "нема"}" + 
           Environment.NewLine +
           $"Книжки: {String.Join(", ", Books.Select(b => b.Book.Name))}" 
           + Environment.NewLine +
           "-------------------------------------------------------";

    /// <summary>
    ///     Equals strong typed implementation
    /// </summary>
    /// <param name="other">
    ///     Other reader object
    /// </param>
    /// <returns>
    ///     Returns true if matching readers are equals, otherwise false
    /// </returns>
    private bool Equals(Reader other)
        => Id.Equals(other.Id) && FirstName == other.FirstName && 
           LastName == other.LastName && FatherName == other.FatherName && 
           Birthday.Equals(other.Birthday) && Phone == other.Phone && 
           Education == other.Education && Books.Equals(other.Books) && 
           Equals(ReadingRoom, other.ReadingRoom);
}