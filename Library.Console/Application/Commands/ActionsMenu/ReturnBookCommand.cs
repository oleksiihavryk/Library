using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class ReturnBookCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public ReturnBookCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readers = _library.Readers.ToArray();
        if (readers.Any())
        {
            System.Console.WriteLine("Виберіть читача:");
            var reader = GetItemFromMultipleVariant(readers);
            System.Console.Clear();

            var books = reader.Books;

            if (books.Any())
            {
                System.Console.WriteLine("Виберіть книгу:");
                var book = GetItemFromMultipleVariant(books);
                System.Console.Clear();

                _library.ReturnBook(reader, book);

                System.Console.WriteLine("Вибраний читач повернув вибрану книгу");
            }
            else
            {
                System.Console.WriteLine("Читач наразі не має жодної взятої книги");
            }
        }
        else
        {
            System.Console.WriteLine("Бібліотека наразі немає жодного читача");
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