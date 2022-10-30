using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.GenericInformationMenu;

internal class GetReadingRoomsCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetReadingRoomsCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var rooms = _library.ReadingRooms.ToArray();
        if (rooms.Any())
        {
            System.Console.WriteLine("Всі читальні зали:");
            System.Console.WriteLine("-----------------------------");
            int counter = 0;
            foreach (var room in rooms)
            {
                System.Console.WriteLine($"{++counter}."+Environment.NewLine+room);
            }
            System.Console.WriteLine("-----------------------------");
        }
        else
        {
            System.Console.WriteLine("Наразі в бібліотеці нема жодної зали для читання");
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