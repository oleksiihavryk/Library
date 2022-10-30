using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.AdvancedInformationMenu;

internal class GetBooksWithMaximalRatingsCommand : ApplicationStateCommand
{
    private const int TopOf = 10;
    private readonly ILibrary _library;

    public GetBooksWithMaximalRatingsCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var books = _library.GetBooksWithMaximalRating(TopOf).ToArray();
        if (books.Any())
        {
            System.Console.WriteLine("Топ 10 найкращих книг в бібліотеці: ");
            int counter = 0;

            System.Console.WriteLine("-----------------------------");
            foreach (var b in books)
                System.Console.WriteLine($"{++counter}. {b.Name} by {b.Author}. [{b.Rating}/10]");
            System.Console.WriteLine("-----------------------------");
        }
        else
        {
            System.Console.WriteLine("Бібліотека наразі немає взагалі жодної книги");
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