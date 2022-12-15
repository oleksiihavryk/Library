using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class RemoveRoomCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public RemoveRoomCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms.ToArray();
        if (readingRooms.Any())
        {
            System.Console.WriteLine("Виберіть кімнату для читання:");
            var readingRoom = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            _library.RemoveReadingRoom(readingRoom);

            System.Console.WriteLine("Кімната була успішно видалена з бібліотеки");
        }
        else
        {
            System.Console.WriteLine(
                "Бібліотека наразі не має жодної кімнати для читання");
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