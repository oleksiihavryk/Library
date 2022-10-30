using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.Menu;

internal class GenericInformationMenuCommand : ApplicationStateCommand
{
    public override State Execute()
    {
        System.Console.WriteLine("Загальна інформація");
        System.Console.WriteLine("1. Всі читачі в бібліотеці.");
        System.Console.WriteLine("2. Всі зали в бібліотеці.");
        System.Console.WriteLine("3. Всі книги що зберігаются в бібліотеці.");
        System.Console.WriteLine("4. Повернутися.");

        var response = GetIntegerUserInput(to: 4);

        System.Console.Clear();
        return response switch
        {
            1 => State.GetReaders,
            2 => State.GetRooms,
            3 => State.GetContainedBooks,
            4 => State.MainMenu,
            _ => throw new UnhandledStateException()
        };
    }
}