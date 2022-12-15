using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;
internal class TakeBookCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public TakeBookCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readers = _library.Readers.ToArray();
        if (!readers.Any())
        {
            System.Console.WriteLine("Бібліотека наразі немає жодно читача.");
        }
        else
        {
            System.Console.WriteLine("Виберіть читача:");
            var reader = GetItemFromMultipleVariant(readers);
            System.Console.Clear();

            if (reader.ReadingRoom == null)
            {
                System.Console.WriteLine("Бібліотека наразі немає жодно читача.");
            }
            else
            {
                var books = reader.ReadingRoom.Books;
                if (!books.Any())
                {
                    System.Console.WriteLine(
                        "Бібліотека наразі не має жодної книги у залі для читання вибраного читача.");
                }
                else
                {
                    System.Console.WriteLine("Виберіть книгу:");
                    var book = GetItemFromMultipleVariant(variants: books
                        .Where(b => b.IsPossibleToTakeBook));
                    System.Console.Clear();

                    _library.TakeBook(
                        reader,
                        book.Book);

                    System.Console.WriteLine(
                        "Книга була успішно взята для вибраного читача.");
                }
            }
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