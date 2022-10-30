using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.GenericInformationMenu;

internal class GetContainedBooksCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetContainedBooksCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var books = _library.Books.ToArray();
        if (books.Any())
        {
            System.Console.WriteLine("Всі книги:");
            System.Console.WriteLine("-----------------------------");
            int counter = 0;
            foreach (var book in books)
            {
                System.Console.WriteLine(
                    $"{++counter}."+ Environment.NewLine + book);
            }
            System.Console.WriteLine("-----------------------------");
        }
        else
        {
            System.Console.WriteLine("Наразі в бібліотеці нема жодної книги");
        }
        System.Console.WriteLine("1. Повернутися");

        var response = GetIntegerUserInput(to: 1);

        System.Console.Clear();
        return response switch
        {
            1 => State.GenericInfo,
            _ => throw new UnhandledStateException()
        };
    }
}