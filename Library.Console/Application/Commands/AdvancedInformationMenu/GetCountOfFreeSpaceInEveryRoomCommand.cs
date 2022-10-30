using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.AdvancedInformationMenu;

internal class GetCountOfFreeSpaceInEveryRoomCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public GetCountOfFreeSpaceInEveryRoomCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var freeSpaceInEveryRoom = _library
            .GetReadingRoomsAndFreePlacesCount();

        if (freeSpaceInEveryRoom.Any())
        {
            System.Console.WriteLine("-----------------------------");
            int counter = 0;
            foreach (var r in freeSpaceInEveryRoom)
            {
                System.Console.WriteLine(
                    $"{++counter}. {r.Value} свободних місць у кімнаті " +
                    $"{r.Key.Specialization} з {r.Key.MaxPlacesCapacity} " +
                    $"загальною кількістю місць.");
            }
            System.Console.WriteLine("-----------------------------");
        }
        else
        {
            System.Console.WriteLine(
                "Всі кімнати зайня чи в бібліотеці немає жодної з кімнат");
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