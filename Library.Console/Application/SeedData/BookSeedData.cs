namespace Library.Console.Application.SeedData;

internal class BookSeedData
{
    public string Name { get; }
    public string Author { get; }
    public int Rating { get; }
    public int Count { get; }
    public DateTime Date { get; }
    public DateTime ReceiveData { get; }

    public BookSeedData(
        string name,
        string author, 
        int rating, 
        int count, 
        DateTime date, 
        DateTime receiveData)
    {
        Name = name;
        Author = author;
        Rating = rating;
        Count = count;
        Date = date;
        ReceiveData = receiveData;
    }
}