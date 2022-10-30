using Library.Console.Application.SeedData;
using Library.Console.Core;
using Library.Console.Extensions;
using Library.Domain;

namespace Library.Console.Application;
internal sealed class Seeder
{
    private readonly ILibrary _library;

    internal List<ReadingRoomSeedData> DefaultSeedingData 
        => new List<ReadingRoomSeedData>()
        {
            new ReadingRoomSeedData(
                specialization: "Фізична культура",
                maxPlacesCapacity: 10)
            {
                ReadersSeedData =
                {
                    new ReaderSeedData(
                        firstName: "Антін",
                        lastName: "Прокопович",
                        fatherName: "Анатолійович",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380994400000",
                        birthday: new DateTime(2001, 3, 3)),
                    new ReaderSeedData(
                        firstName: "Павло",
                        lastName: "Артеменко",
                        fatherName: "Павлович",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380994440501",
                        birthday: new DateTime(1999, 8, 28))
                },
                BooksSeedData =
                {
                    new BookSeedData(
                        name: "Фізична Культура для підлітків",
                        author: "Сергій Панасенко",
                        rating: 4,
                        count: 20,
                        date: new DateTime(1999, 2, 3), 
                        receiveData: new DateTime(2001, 2, 19)),
                    new BookSeedData(
                        name: "Фізична Культура | Для професіонального дослідження та вивчення",
                        author: "Сергій Панасенко",
                        rating: 8,
                        count: 41,
                        date: new DateTime(1998, 3, 19),
                        receiveData: new DateTime(2003, 6, 6)),
                    new BookSeedData(
                        name: "Фізика тіла",
                        author: "Олексій Наумов",
                        rating: 5,
                        count: 1,
                        date: new DateTime(2013, 6, 23),
                        receiveData: new DateTime(2016, 1, 4)),
                    new BookSeedData(
                        name: "Все про фізичний розвиток людини",
                        author: "Грегорій Артеменко",
                        rating: 9,
                        count: 1,
                        date: new DateTime(2019, 3, 3),
                        receiveData: new DateTime(2020, 1, 9))
                }
            },
            new ReadingRoomSeedData(
                specialization: "Математичні науки",
                maxPlacesCapacity: 100)
            {
                ReadersSeedData =
                {
                    new ReaderSeedData(
                        firstName: "Олексій",
                        lastName: "Грищук",
                        fatherName: "Тарасенко",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380994423700",
                        birthday: new DateTime(2004, 12, 26)),
                    new ReaderSeedData(
                        firstName: "Матвій",
                        lastName: "Мелник",
                        fatherName: "Максимович",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380994409820",
                        birthday: new DateTime(2002, 7, 11)),
                    new ReaderSeedData(
                        firstName: "Микита",
                        lastName: "Нарський",
                        fatherName: "Микитович",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380999837000",
                        birthday: new DateTime(2002, 7, 11)),
                    new ReaderSeedData(
                        firstName: "Анна",
                        lastName: "Нарська",
                        fatherName: "Микитівна",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380664408465",
                        birthday: new DateTime(1995, 4, 12)),
                    new ReaderSeedData(
                        firstName: "Федір",
                        lastName: "Фінський",
                        fatherName: "Григорович",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380667594000",
                        birthday: new DateTime(2002, 9, 15)),
                },
                BooksSeedData =
                {
                    new BookSeedData(
                        name: "Глибоке вивчення математичних функцій на прикладі сковороди",
                        author: "Віктор Розумний",
                        rating: 10,
                        count: 1,
                        date: new DateTime(2022, 1, 1),
                        receiveData: DateTime.Now),
                    new BookSeedData(
                        name: "Моя траекторія",
                        author: "Віктор Барьяхтар",
                        rating: 9,
                        count: 1,
                        date: new DateTime(2010),
                        receiveData: new DateTime(2019, 5, 3)),
                    new BookSeedData(
                        name: "Я *** математику",
                        author: "Максим Пахомов",
                        rating: 2,
                        count: 20,
                        date: new DateTime(2012, 12, 12),
                        receiveData: new DateTime(2016, 3, 30)),
                    new BookSeedData(
                        name: "Математика в контексті аграрних наук",
                        author: "Павло Суркін",
                        rating: 3,
                        count: 2,
                        date: DateTime.Now,
                        receiveData: DateTime.Now),
                    new BookSeedData(
                        name: "Ступінь розуміння",
                        author: "Джордж Тод",
                        rating: 7,
                        count: 19,
                        date: new DateTime(1999, 1, 23),
                        receiveData: new DateTime(2015, 3, 2)),
                    new BookSeedData(
                        name: "Научна промисловість чи просто пряма?",
                        author: "Василь Чорний",
                        rating: 2,
                        count: 2,
                        date: new DateTime(2007, 2, 8),
                        receiveData: new DateTime(2011, 2, 8)),
                    new BookSeedData(
                        name: "Розуміння світу через розуміння судоку",
                        author: "Тарас Пацюк",
                        rating: 5,
                        count: 19,
                        date: new DateTime(2016, 1, 29),
                        receiveData: new DateTime(2019, 2, 23))
                }
            },
            new ReadingRoomSeedData(
                specialization: "Програмування",
                maxPlacesCapacity: 200)
            {
                ReadersSeedData =
                {
                    new ReaderSeedData(
                        firstName: "Антін",
                        lastName: "Пахомов",
                        fatherName: "Антінович",
                        education: "Харьковський Національний Університет О.М. Бекетова",
                        phone: "+380960286000",
                        birthday: new DateTime(2000, 1, 5))
                },
                BooksSeedData =
                {
                    new BookSeedData(
                        name: "Розуміння проектування баз данних з розуміння роботи електропили",
                        author: "Іван Шкуров",
                        rating: 8,
                        count: 5,
                        date: new DateTime(2022, 1, 1),
                        receiveData: new DateTime(2022, 2, 2)),
                    new BookSeedData(
                        name: "Гора змінних",
                        author: "Христина Під'яблонська",
                        rating: 4,
                        count: 1,
                        date: new DateTime(2022, 1, 7),
                        receiveData: new DateTime(2022, 5, 2))
                }
            }
        };

    internal Seeder(ILibrary library)
    {
        _library = library;
    }

    internal void SeedData()
    {
        foreach (var data in DefaultSeedingData)
        {
            var readingRoom = AddReadingRoom(data);

            foreach (var bookData in data.BooksSeedData)
                AddBook(bookData, readingRoom);

            foreach (var readerData in data.ReadersSeedData)
            {
                var reader = AddReader(readerData, readingRoom);

                TakeRandomBookByReader(reader, readingRoom);
            }
        }
    }

    private void TakeRandomBookByReader(
        Reader reader,
        ReadingRoom readingRoom)
    {
        var book = readingRoom
            .Books
            .Where(b => b.IsPossibleToTakeBook)
            .Select(b => b.Book)
            .TakeRandom();

        if (book == null)
            return;

        _library.TakeBook(reader, readingRoom, book); 
    }
    private Reader AddReader(
        ReaderSeedData readerData,
        ReadingRoom readingRoom)
        => _library.RegisterNewReader(
            firstName: readerData.FirstName,
            lastName: readerData.LastName,
            fatherName: readerData.FatherName,
            phone: readerData.Phone,
            education: readerData.Education,
            birthday: readerData.Birthday,
            readingRoom);
    private void AddBook(
        BookSeedData bookData, 
        ReadingRoom readingRoom)
        => _library.AddBook(
            name: bookData.Name,
            author: bookData.Author,
            rating: bookData.Rating,
            count: bookData.Count,
            date: bookData.Date,
            receiveDate: bookData.ReceiveData,
            readingRoom);
    private ReadingRoom AddReadingRoom(ReadingRoomSeedData data)
        => _library.AddNewReadingRoom(
            specialization: data.Specialization,
            maxPlacesCapacity: data.MaxPlacesCapacity);
}