using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.Menu;

internal class MainMenuCommand : ApplicationStateCommand
{
    public override State Execute()
    {
        System.Console.WriteLine("Головне меню");
        System.Console.WriteLine("1. Загальна інформація о системі.");
        System.Console.WriteLine("2. Продвинута інформація о системі.");
        System.Console.WriteLine("3. Дії.");
        System.Console.WriteLine("4. Вихід.");

        var response = GetIntegerUserInput(to: 4);

        System.Console.Clear();
        return response switch
        {
            1 => State.GenericInfo,
            2 => State.AdvancedInfo,
            3 => State.Actions,
            4 => State.Exit,
            _ => throw new UnhandledStateException()
        };
    }
}