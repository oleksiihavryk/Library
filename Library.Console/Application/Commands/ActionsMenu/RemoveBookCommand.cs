using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class RemoveBookCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public RemoveBookCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms.ToArray();

        if (readingRooms.Any())
        {
            System.Console.WriteLine("Виберіть читальну залу:");
            var readingRoom = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            var books = readingRoom.Books;
            if (books.Any())
            {
                System.Console.WriteLine("Виберіть книгу:");
                var book = GetItemFromMultipleVariant(books);
                System.Console.Clear();

                _library.RemoveBook(
                    readingRoom,
                    book.Book);

                System.Console.WriteLine("Книга була успішно видалена з системи.");
            }
            else
            {
                System.Console.WriteLine(
                    "Бібліотека наразі не має жодної книги у вибраній залі для читання.");
            }
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