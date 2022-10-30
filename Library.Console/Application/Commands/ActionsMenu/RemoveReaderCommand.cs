using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class RemoveReaderCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public RemoveReaderCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readers = _library.Readers.ToArray();
        if (readers.Any())
        {
            System.Console.WriteLine("Виберіть читача:");
            var reader = GetItemFromMultipleVariant(readers);
            System.Console.Clear();

            _library.RemoveReader(reader);

            System.Console.WriteLine("Читач був успішно видалений з бібліотеки.");
        }
        else
        {
            System.Console.WriteLine(
                "Бібліотека наразі не має жодного читача");
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