using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.ActionsMenu;

internal class RegisterNewReaderCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public RegisterNewReaderCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        var readingRooms = _library.ReadingRooms.ToArray();
        if (readingRooms.Any())
        {
            System.Console.WriteLine("Виберіть залу для читання:");
            var readingRoom = GetItemFromMultipleVariant(readingRooms);
            System.Console.Clear();

            System.Console.WriteLine("Введіть ім'я читача:");
            var firstName = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть фамілію читача:");
            var lastName = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть по батькові читача:");
            var fatherName = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть номер читача:");
            var phone = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть освіту читача:");
            var education = GetStringUserInput();
            System.Console.Clear();

            System.Console.WriteLine("Введіть день народження читача:");
            var birthday = GetDateTimeUserInput();
            System.Console.Clear();

            _library.RegisterNewReader(
                firstName, 
                lastName, 
                fatherName, 
                phone, 
                education, 
                birthday, 
                readingRoom);

            System.Console.Clear();
            System.Console.WriteLine("Новий читач був зареєстрований у бібліотеці.");
        }
        else
        {
            System.Console.WriteLine(
                "Бібліотека наразі не має жодної читальної зали");
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