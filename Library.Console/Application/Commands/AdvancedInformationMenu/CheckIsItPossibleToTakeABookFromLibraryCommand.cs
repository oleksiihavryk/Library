using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.AdvancedInformationMenu;

internal class CheckIsItPossibleToTakeABookFromLibraryCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public CheckIsItPossibleToTakeABookFromLibraryCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var books = _library.Books
            .Select(b => b.Book)
            .ToArray();
        if (books.Any())
        {
            System.Console.WriteLine("Вибрати книгу:");
            var book = GetItemFromMultipleVariant(books);
            System.Console.Clear();

            bool isPossible = _library.CheckIfPossibleToTakeBook(book);

            System.Console.WriteLine(
                isPossible ? 
                    $"Так, {book.Name} можна взяти в бібліотеці" : 
                    "Нажаль ні, цю книгу не можна взяти в бібліотеці");
        }
        else
        {
            System.Console.WriteLine("Наразі в біблотеці нема жодної книги");
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