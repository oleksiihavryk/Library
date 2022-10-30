using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class AddExistedBookCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public AddExistedBookCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms;
        if (readingRooms.Any())
        {
            System.Console.WriteLine($"Виберіть кімнату для читання:");
            var readingRoom = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            var books = readingRoom.Books;
            
            if (books.Any())
            {
                System.Console.WriteLine("Виберіть книгу:");
                var storedBook = GetItemFromMultipleVariant(books);
                System.Console.Clear();

                System.Console.WriteLine("Скільки саме книг ви хочете добавити в систему?");
                var quantity = GetIntegerUserInput(to: Int32.MaxValue);
                System.Console.Clear();

                _library.AddBook(
                    readingRoom,
                    storedBook.Book, 
                    count: quantity);
                System.Console.Clear();
                System.Console.WriteLine("Кількість книг в системі оновлено.");
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