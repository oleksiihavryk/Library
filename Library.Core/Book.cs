namespace Library.Domain;

/// <summary>
///     Book model
/// </summary>
public sealed class Book
{
    /// <summary>
    ///     Book unique id (key)
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    ///     Book name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    ///     Book author
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    ///     Book date
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    ///     Book Code, a special cypher that library sets to
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    ///     Book receive date 
    /// </summary>
    public DateTime ReceiveDate { get; set; }
    /// <summary>
    ///     Rating of book
    /// </summary>
    public int Rating { get; set; } = 0;

    /// <summary>
    ///     Create default book
    /// </summary>
    /// <param name="name">
    ///     Book name
    /// </param>
    /// <param name="author">
    ///     Book author
    /// </param>
    /// <param name="date">
    ///     Book creating date
    /// </param>
    /// <param name="code">
    ///     Book code
    /// </param>
    /// <param name="receiveDate">
    ///     Book receiving date
    /// </param>
    public Book(
        string name, 
        string author, 
        string code,
        DateTime date,
        DateTime receiveDate)
    {
        Id = Guid.NewGuid();
        Code = code;
        Name = name;
        Author = author;
        Date = date;
        ReceiveDate = receiveDate;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Book)obj);
    }
    public override int GetHashCode()
        => HashCode.Combine(Id, Name, Author, Date, Code, ReceiveDate, Rating);
    public override string ToString()
        => "-------------------------------------------------------" + Environment.NewLine + 
           $"Ім'я: {Name}, " + Environment.NewLine +
           $"Автор: {Author}, " + Environment.NewLine +
           $"Створена у: {Date}, " + Environment.NewLine +
           $"Шифр книги: {Code}, " + Environment.NewLine +
           $"Надійшла до бібліотеки у: {ReceiveDate}, " + Environment.NewLine +
           $"Рейтинг: {Rating}" + Environment.NewLine +
           "-------------------------------------------------------";

    /// <summary>
    ///     Equals strong typed implementation
    /// </summary>
    /// <param name="other">
    ///     Other book object
    /// </param>
    /// <returns>
    ///     Returns true if matching books are equals, otherwise false
    /// </returns>
    private bool Equals(Book other)
        => Id.Equals(other.Id) && Name == other.Name && 
           Author == other.Author && Date.Equals(other.Date) && 
           Code == other.Code && ReceiveDate.Equals(other.ReceiveDate) && 
           Rating == other.Rating;
}