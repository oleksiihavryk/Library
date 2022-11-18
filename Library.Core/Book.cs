namespace Library.Domain;
public sealed class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public string Code { get; set; }
    public DateTime ReceiveDate { get; set; }
    public int Rating { get; set; } = 0;
    
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
        => $"Ім'я: {Name}, " + Environment.NewLine +
           $"Автор: {Author}, " + Environment.NewLine +
           $"Шифр книги: {Code}, ";

    private bool Equals(Book other)
        => Id.Equals(other.Id) && Name == other.Name && 
           Author == other.Author && Date.Equals(other.Date) && 
           Code == other.Code && ReceiveDate.Equals(other.ReceiveDate) && 
           Rating == other.Rating;
}