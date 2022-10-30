using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.AdvancedInformationMenu;

internal class GetReadersWhatTakenBooksWhichContainedInOnlyOneExampleCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetReadersWhatTakenBooksWhichContainedInOnlyOneExampleCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readers = _library
            .GetReadersWhichTakenBooksContainedInOnlyOneSpecimen()
            .ToArray();

        if (readers.Any())
        {
            int counter = 0;
            System.Console.WriteLine(
                "Всі читачі що тримають при собі книги що є в " +
                "бібліотеці тільки в одному екземплярі: ");
            System.Console.WriteLine("-----------------------------");
            foreach (var r in readers)
                System.Console.WriteLine(
                    $"{++counter}. {r.FirstName} {r.LastName} {r.FatherName} - " +
                    $"{r.Education} [{r.Phone}]");
            System.Console.WriteLine("-----------------------------");
        }
        else
        {
            System.Console.WriteLine("Система немає таких читачів");
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