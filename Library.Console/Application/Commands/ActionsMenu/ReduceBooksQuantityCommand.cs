using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class ReduceBooksQuantityCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public ReduceBooksQuantityCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms.ToArray();
        if (readingRooms.Any())
        {
            System.Console.WriteLine($"Виберіть кімнату для читання:");
            var readingRoom = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            var books = readingRoom.Books;

            if (books.Any())
            {
                System.Console.WriteLine("Виберіть книгу:");
                var storedBook = GetItemFromMultipleVariant(variants: books
                    .Where(b => b.IsPossibleToTakeBook));
                System.Console.Clear();

                System.Console.WriteLine("Скільки ви хочете прибрати книг з читальної кімнати?");
                var quantity = GetIntegerUserInput(to: Int32.MaxValue);
                System.Console.Clear();

                _library.RemoveBook(
                    readingRoom,
                    storedBook.Book,
                    count: quantity);
                System.Console.Clear();
                System.Console.WriteLine(
                    "Введену кількість книг було прибрано з читальної кімнати.");
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
        System.Console.WriteLine("1. Back");

        var response = GetIntegerUserInput(to: 1);

        System.Console.Clear();
        return response switch
        {
            1 => State.Actions,
            _ => throw new UnhandledStateException()
        };
    }
}