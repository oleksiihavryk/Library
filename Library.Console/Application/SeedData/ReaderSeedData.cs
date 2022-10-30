namespace Library.Console.Application.SeedData;

internal class ReaderSeedData
{
    public string FirstName { get; }
    public string LastName { get; }
    public string FatherName { get; }
    public string Education { get; }
    public string Phone { get; }
    public DateTime Birthday { get; }

    public ReaderSeedData(
        string firstName, 
        string lastName, 
        string fatherName, 
        string education, 
        string phone, 
        DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        FatherName = fatherName;
        Education = education;
        Phone = phone;
        Birthday = birthday;
    }
}