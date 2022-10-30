using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.AdvancedInformationMenu;

internal class GetBooksAndReadersCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetBooksAndReadersCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var booksAndReaders = _library.GetReadersAndHisTakenBooks();

        if (booksAndReaders.Any())
        {
            int counterReader = 0;
            foreach (var br in booksAndReaders)
            {
                System.Console.WriteLine("========================================");
                System.Console.WriteLine(
                    $"{++counterReader}. {br.Key.FirstName} {br.Key.LastName} " +
                    $"{br.Key.FatherName} {br.Key.Birthday} - " +
                    $"{br.Key.Education}, [{br.Key.Phone}]");
                int counterBooks = 0;
                System.Console.WriteLine("Книги:");
                foreach (var b in br.Value)
                {
                    System.Console.WriteLine(
                        $"{counterReader}.{++counterBooks}." + Environment.NewLine + b);
                }
                System.Console.WriteLine("========================================");
            }
        }
        else
        {
            System.Console.WriteLine("Бібліотека наразі немає жодно читача");
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