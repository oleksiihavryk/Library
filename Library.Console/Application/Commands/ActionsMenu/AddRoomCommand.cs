using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class AddRoomCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public AddRoomCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        System.Console.WriteLine("Введіть спеціалізацію кімнати");
        var specialization = GetStringUserInput();
        System.Console.Clear();

        System.Console.WriteLine("Введіть максимальну кількість місць у бібліотеці");
        var maxCapacity = GetIntegerUserInput(to: Int32.MaxValue);
        System.Console.Clear();

        _library.AddNewReadingRoom(specialization, maxPlacesCapacity: maxCapacity);

        System.Console.WriteLine("Нова читальна зала була додана до бібліотеки");
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