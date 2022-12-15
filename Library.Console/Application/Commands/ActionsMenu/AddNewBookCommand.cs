using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class AddNewBookCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public AddNewBookCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms.ToArray();
        if (readingRooms.Any())
        {
            System.Console.WriteLine("Виберіть залу для читання в котрій буде зберігатися книга");
            var readingRoom = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            System.Console.WriteLine("Введіть назву книги");
            string name = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть ім'я автора");
            string author = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть коли була створена книга");
            var date = GetDateTimeUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть коли була отримана книга в бібліотеку");
            var receiveDate = GetDateTimeUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть рейтинг книги");
            var rating = GetIntegerUserInput(to: 10);
            System.Console.Clear();

            _library.AddBook(
                name,
                author,
                rating,
                count: 1,
                date,
                receiveDate,
                readingRoom);

            System.Console.WriteLine(
                "Книга була додана до вибраної читальної зали в кількості 1шт.");
        }
        else
        {
            System.Console.WriteLine(
                "Бібліотека наразі не має жодної читальної зали");
        }

        System.Console.WriteLine("1. Повернутися");

        var response = GetIntegerUserInput(to: 1);

        System.Console.Clear();
        return response switch
        {
            1 => State.Actions,
            _ => throw new UnhandledStateException()
        };
    }
}