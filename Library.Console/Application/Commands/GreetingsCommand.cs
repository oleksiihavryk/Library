using Library.Console.Core;

namespace Library.Console.Application.Commands;

internal class GreetingsCommand : IStateCommand
{
    private readonly ILibrary _library;

    public GreetingsCommand(ILibrary library)
    {
        _library = library;
    }

    public State Execute()
    {
        System.Console.WriteLine($"Бібліотека: {_library.Name}." + Environment.NewLine +
                                 $"Доброго часу доби. " + Environment.NewLine +
                                 $"Давайте разом спробуємо знайти те що вам потрібно.");

        return State.MainMenu;
    }
}