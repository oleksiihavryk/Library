namespace Library.Console.Application.SeedData;
internal class ReadingRoomSeedData
{
    public string Specialization { get; }
    public int MaxPlacesCapacity { get; }
    public List<BookSeedData> BooksSeedData { get; } = new List<BookSeedData>();
    public List<ReaderSeedData> ReadersSeedData { get; } = new List<ReaderSeedData>();

    public ReadingRoomSeedData(
        string specialization, 
        int maxPlacesCapacity)
    {
        Specialization = specialization;
        MaxPlacesCapacity = maxPlacesCapacity;
    }
}