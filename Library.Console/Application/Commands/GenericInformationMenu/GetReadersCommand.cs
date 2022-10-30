using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.GenericInformationMenu;

internal class GetReadersCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetReadersCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readers = _library.Readers.ToArray();
        if (readers.Any())
        {
            System.Console.WriteLine("Всі читачі:");
            System.Console.WriteLine("-----------------------------");
            int counter = 0;
            foreach (var reader in readers)
            {
                System.Console.WriteLine($"{++counter}." + Environment.NewLine + reader);
            }
            System.Console.WriteLine("-----------------------------");
        }
        else
        {
            System.Console.WriteLine("Наразі в бібліотеці немає жодного читача");
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