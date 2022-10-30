using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.AdvancedInformationMenu;

internal class GetBooksCountInReadingRoomByAuthorCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetBooksCountInReadingRoomByAuthorCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms.ToArray();
        if (readingRooms.Any())
        {
            System.Console.WriteLine("Виберіть кімнату:");
            var room = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            System.Console.WriteLine("Введіть ім'я автора:");
            var author = GetStringUserInput();
            System.Console.Clear();

            var count = _library.GetCountOfFreeBooksByAuthorInReadingRoom(
                author,
                readingRoom: room);

            System.Console.WriteLine($"Кількість вільних книг по автору - {author}: {count}");
        }
        else
        {
            System.Console.WriteLine("Бібліотека наразі не має жодної читальної зали.");
        }

        System.Console.WriteLine("1. Повернутися");

        var response = GetIntegerUserInput(to: 1);

        System.Console.Clear();
        return response switch
        {
            1 => State.AdvancedInfo,
            _ => throw new UnhandledStateException()
        };
    }
}